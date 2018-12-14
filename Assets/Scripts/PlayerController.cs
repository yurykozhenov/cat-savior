using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float moveSpeed = 2.5f;
	public float jumpForce = 250;
	public bool facingRight = true;
	public int health = 100;

	private Rigidbody2D rb;
	private Animator animator;
//	private SpriteRenderer renderer;

	private bool grounded;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask whatIsGround;

	private Vector3 startingPosition;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		startingPosition = transform.position;

		ChangeHealthText();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		
		var moveHorizontal = Input.GetAxis("Horizontal");
		
		animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
		
		rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

		if (moveHorizontal < 0 && facingRight || moveHorizontal > 0 && !facingRight)
		{
			Flip();
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			rb.AddForce(Vector2.up * jumpForce);
		}
	}

	private void Flip()
	{
		facingRight = !facingRight;
		
		var scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void DamagePlayer(int damage)
	{
		health -= damage;
		
		if (health <= 0)
		{
			health = 0;
			GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>().text = "SACRIFICE ACCEPTED";
			Time.timeScale = 0;
			Destroy(gameObject);
		}

		ChangeHealthText();
	}

	private void ChangeHealthText()
	{ 
		GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>().text = $"HP: {health}";
	}
}
