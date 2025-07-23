using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private int maxHealth = 3;

    private int health;
    private GameObject spawnedGrave;

    public float MoveSpeed {get => moveSpeed; set {moveSpeed = value;}}
    public float RotationSpeed {get => rotationSpeed;}

    private void Start()
    {
        EventController.OnBombItemPicUp.AddListener(DecHealth);
        EventController.OnHealEffectApplied.AddListener(IncHealth);
    }

    private void IncHealth()
    {
        if (health < maxHealth)
        {
            health++;
            EventController.OnPlayerHealthChange.Invoke(health);
        }
    }

    private void DecHealth()
    {
        if (health > 0)
        {
            health--;
            EventController.OnPlayerHealthChange.Invoke(health);
        }
        
        if (health <= 0)
            EventController.OnPlayerDie.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PicUpObject"))
            other.GetComponent<Item>().ApplyEffect();

        other.gameObject.SetActive(false);
    }   

    public void ResetPlayer(Vector3 spawnPoint)
    {
        health = maxHealth;
        GetComponent<MoveController>().ResetMovement();
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.SetPositionAndRotation(spawnPoint, new Quaternion(0, 180, 0, 1));
    }
}
