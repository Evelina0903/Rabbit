using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Player player;
    private Rigidbody rb;
    private Animator animator;

    private Vector3 movement;
    
    private bool isReverse = false;
    private float bonusSpeed = 0.0f;

    public Vector3 Movement {get => movement;}

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();

        EventController.OnSpeedEffectApplied.AddListener(IncSpeed);
        EventController.OnSlowEffectApplied.AddListener(DecSpeed);
        EventController.OnReverseEffectApplied.AddListener(Reverse);
    }

    private void FixedUpdate()
    {
        MoveLogic();
        RotationLogic();
    }

    private void MoveLogic()
    {
        float moveZ = -Input.GetAxis("Horizontal");
        float moveX = Input.GetAxis("Vertical");

        movement = new Vector3(moveX, 0.0f, moveZ);
        if (isReverse)
            movement *= -1;

        Vector3 velocityVec = movement * (player.MoveSpeed + bonusSpeed);
        velocityVec.y = rb.velocity.y;

        rb.velocity = velocityVec;
    }

    private void Reverse()
    {
        isReverse = !isReverse;
    }

    private void IncSpeed()
    {
        bonusSpeed += (float)(0.25 * player.MoveSpeed);
    }

    private void DecSpeed()
    {
        if (bonusSpeed > 0.25 * player.MoveSpeed)
            bonusSpeed -= (float)(0.25 * player.MoveSpeed);
    }

    private void RotationLogic()
    {
        if (movement.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(movement);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, player.RotationSpeed * Time.fixedDeltaTime);
        }
    }

    public void ResetMovement()
    {
        isReverse = false;
        bonusSpeed = 0.0f;
    }
}
