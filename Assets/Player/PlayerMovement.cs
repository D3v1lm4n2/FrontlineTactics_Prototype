using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private InputManager input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = FindObjectOfType<InputManager>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = input.MovementInput;
        rb.velocity = movement * moveSpeed;
    }
}
