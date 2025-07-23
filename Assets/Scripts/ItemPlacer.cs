using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField] Item pointsItem;
    [SerializeField] Item bonusItem;
    [SerializeField] Item bombItem;

    [SerializeField] bool isBonusMode;
    [SerializeField] float bonusChance;

    public bool Mode {set {isBonusMode = value;}}

    private void Start()
    {
        EventController.OnGameModeChanged.AddListener(ChangeMode);
    }

    private void ChangeMode()
    {
        isBonusMode = !isBonusMode;
    }

    public void FillChunk(Chunk chunk)
    {
        List<Transform> spawnPoints = ChooseSpawnPoints(chunk.SpawnPoints, Random.Range(3, 6));
        foreach (Transform tr in spawnPoints)
        {
            if (!isBonusMode)
                SpawnItem(pointsItem, chunk, tr);
            else
                SpawnItem(RandomItem(), chunk, tr);
        }
    }

    private void SpawnItem(Item item, Chunk chunk, Transform tr)
    {
        Item newItem = Instantiate(item, chunk.transform);
        newItem.transform.localPosition = tr.localPosition;
    }

    private List<Transform> ChooseSpawnPoints(Transform[] spawnPoints, int count)
    {
        List<Transform> list = new List<Transform>(spawnPoints);

        if (count <= 0 || count > spawnPoints.Length)
            return list;

        for (int i = 0; i < spawnPoints.Length - count; i++)
            list.RemoveAt(Random.Range(0, list.Count));

        return list;
    }

    private Item RandomItem()
    {
        float pointsItemChance = 1 - bonusChance;

        if (Random.Range(0.0f, 1.0f) <= pointsItemChance)
            return pointsItem;
        if (Random.Range(0.0f, bonusChance) <= bonusChance / 2)
            return bonusItem;
        return bombItem;
    }
}
