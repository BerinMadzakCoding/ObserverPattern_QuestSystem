using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
    private static readonly int MoveYHash = Animator.StringToHash("MoveY");
    private static readonly int MoveXHash = Animator.StringToHash("MoveX");

    [Header("References")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animator;

    [Header("Stats")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float rotationSpeed = 6f;
    [SerializeField] private int damage = 50;

    private InputSystem_Actions input;
    private Vector2 movementDirection = Vector2.zero;
    private Vector2 rotationDirection = Vector2.zero;

    private void Awake()
    {
        input = new InputSystem_Actions();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        movementDirection = input.Player.Move.ReadValue<Vector2>();
        rotationDirection = input.Player.Look.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        HandleMovement();
        HandleCamera();
    }

    private void HandleMovement()
    {
        Vector3 movement = new Vector3(movementDirection.x, 0f, movementDirection.y);
        movement = transform.TransformDirection(movement);
        controller.Move(speed * Time.deltaTime * movement);

        controller.Move(gravity * Time.deltaTime * Vector3.down);
        animator.SetFloat(MoveXHash, movementDirection.x);
        animator.SetFloat(MoveYHash, movementDirection.y);
        animator.SetBool(IsMovingHash, movementDirection.x != 0 || movementDirection.y != 0);
    }

    private void HandleCamera()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * new Vector3(0f, rotationDirection.x, 0f));
    }

    private void OnEnable()
    {
        input.Player.Enable();
        input.Player.Attack.performed += HandleAttack;
        input.Player.Interact.performed += HandleInteract;
    }

    private void OnDisable()
    {
        input.Player.Attack.performed -= HandleAttack;
        input.Player.Interact.performed -= HandleInteract;
        input.Player.Disable();
    }

    private void HandleInteract(InputAction.CallbackContext context)
    {
        InteractManager.Instance.TriggerInteract();
    }

    private void HandleAttack(InputAction.CallbackContext context)
    {
        if(animator.GetCurrentAnimatorStateInfo(1).IsName("Attack")) return;
        animator.SetTrigger(AttackHash);
    }

    public void HandleDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent(out EnemyController enemyController))
            {
                enemyController.DealDamage(damage);
            }
        }
    }
}
