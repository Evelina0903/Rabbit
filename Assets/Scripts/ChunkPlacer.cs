using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private BiomeInfo[] biomes;
    [SerializeField] private BiomeTransition[] transitions;

    [SerializeField] private int minBiomeLength;
    [SerializeField] private int maxBiomeLength;

    private List<Chunk> spawnedChunks = new List<Chunk>();
    private BiomeInfo currentBiome;
    private int biomeLength;
    private int currentLength;

    private ItemPlacer itemPlacer;

    public Vector3 PlayerSpawnPoint {get => spawnedChunks[0].PlayerSpawnPoint;}

    private void Start()
    {
        itemPlacer = GetComponent<ItemPlacer>();
    }

    private void Update() 
    {
        if (player.position.z < spawnedChunks[spawnedChunks.Count - 1].End.position.z + 20)
            UpdateChunks();
    }

    private void UpdateChunks()
    {
        SpawnChunk(RandomChunk());
        if (currentLength == biomeLength)
        {
            if (biomes.Length > 1)
            {
                BiomeInfo newBiome = NewBiome();
                SpawnChunk(FindTransition(newBiome));

                RandomBiomeLength();
                currentLength = 0;
                currentBiome = newBiome;
            }
            else
                currentLength = 0;
        }
        if (player.transform.position.z < spawnedChunks[0].End.position.z - 20)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private void SpawnChunk(Chunk chunk)
    {
        Chunk newChunk = Instantiate(chunk);

        if (spawnedChunks.Count > 0)
        {
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.transform.position - newChunk.Begin.transform.localPosition;
            itemPlacer.FillChunk(newChunk);
        }
        else
            newChunk.transform.position = new Vector3(0, 0, 0);

        spawnedChunks.Add(newChunk);
        currentLength++;
    }

    private BiomeInfo NewBiome()
    {
        BiomeInfo newBiome = RandomBiome();
        while (newBiome == currentBiome)
            newBiome = RandomBiome();

        return newBiome;
    }

    private Chunk FindTransition(BiomeInfo biome)
    {
        foreach (BiomeTransition t in transitions)
        {
            if (t.OutboundBiome == currentBiome && t.InboundBiome == biome)
            {
                return t.TransitionChunk;
            }
        }
        return null;
    }

    private void RandomBiomeLength()
    {
        biomeLength = Random.Range(minBiomeLength, maxBiomeLength + 1);
    }

    private BiomeInfo RandomBiome()
    {
        return biomes[Random.Range(0, biomes.Length)];
    }

    private Chunk RandomChunk()
    {
        return currentBiome.Chunks[Random.Range(0, currentBiome.Chunks.Length)];
    }

    public void ResetChunks()
    {
        foreach(Chunk c in spawnedChunks)
            Destroy(c.gameObject);
        spawnedChunks.Clear();

        RandomBiomeLength();
        currentLength = 0;
        currentBiome = RandomBiome();

        SpawnChunk(RandomChunk());
    }
}
