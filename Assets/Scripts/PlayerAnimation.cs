using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float basePlayerSpeed = 5.0f;

    private Animator animator;
    private Player player;
    private MoveController moveController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        animator.SetBool("isWalk", (moveController.Movement.magnitude > 0.1f));
        animator.speed = player.MoveSpeed / basePlayerSpeed + 0.5f;
    }
}
