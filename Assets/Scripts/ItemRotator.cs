using System;
using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100.0f;

    private void Start() 
    {
        transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 721)/2));
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.fixedDeltaTime);
    }
}
