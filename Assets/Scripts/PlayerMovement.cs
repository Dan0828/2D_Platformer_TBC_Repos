using UnityEngine;

    //Top of UML
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Vector2 moveDirection;
    private bool isGrounded;

    //below is all methods

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.zero;
    }

    private void Update()
    {
        Move();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

	private void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Move()
    {    
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        // Flip Sprite
        if(moveDirection.x > 0 && transform.localScale.x < 0 || moveDirection.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }      
    }
}
