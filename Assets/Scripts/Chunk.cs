using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform begin;
    [SerializeField] private Transform end;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform[] spawnPoints;

    public Transform Begin {get => begin;}
    public Transform End {get => end;}
    public Vector3 PlayerSpawnPoint {get => playerSpawnPoint.position;}
    public Transform[] SpawnPoints {get => spawnPoints;}
}
