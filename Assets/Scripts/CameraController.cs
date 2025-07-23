using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
