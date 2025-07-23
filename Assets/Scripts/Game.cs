using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject grave;

    [SerializeField] private ChunkPlacer chunkPlacer;
    
    [SerializeField] private UIController ui;

    private Player player;
    private GameObject spawnedGrave;
    private int count;

    private void Start() 
    {
        player = playerObject.GetComponent<Player>();

        ResetGame();

        EventController.OnPointsItemPicUp.AddListener(IncCount);
        EventController.OnPlayerDie.AddListener(KillPlayer);
    }

    private void KillPlayer()
    {
        playerObject.SetActive(false);

        spawnedGrave = Instantiate(grave);
        spawnedGrave.transform.position = playerObject.transform.position;

        Rigidbody graveRB = spawnedGrave.GetComponent<Rigidbody>();
        Rigidbody playerRB = playerObject.GetComponent<Rigidbody>();

        graveRB.velocity = playerRB.velocity;
        graveRB.AddForce(new Vector3(0, 50, 0));
    }

    private void IncCount()
    {
        count++;
        ui.UpdateCountText(count);
    }

    public void ResetGame()
    {
        Destroy(spawnedGrave);

        chunkPlacer.ResetChunks();

        playerObject.SetActive(true);
        player.ResetPlayer(chunkPlacer.PlayerSpawnPoint);

        ui.ResetUI();
        count = 0;
    }
}
