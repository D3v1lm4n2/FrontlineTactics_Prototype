using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private InputManager input;
    [SerializeField] private Animator anim;

    private Rigidbody2D rb;
    private int facingDirection = 1;


    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = input.MovementInput;

        anim.SetFloat("horizontal",Mathf.Abs(movement.x));
        anim.SetFloat("vertical", Mathf.Abs(movement.y));

        if(movement.x > 0 && transform.localScale.x < 0 ||
            movement.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        
        rb.velocity = movement * moveSpeed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
