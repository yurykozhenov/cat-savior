using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float moveSpeed = 2.5f;
	public float jumpForce = 250;
	public bool facingRight = true;
	public int health = 100;
	
	public Transform groundCheck;
	public float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	bool grounded;
	
	Rigidbody2D rb;
	Animator animator;

	Text gameOverText;
	Text healthText;

	static readonly int Speed = Animator.StringToHash("Speed");

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

		healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
		gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();

		ChangeHealthText();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		
		var moveHorizontal = Input.GetAxis("Horizontal");
		
		animator.SetFloat(Speed, Mathf.Abs(moveHorizontal));
		
		rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

		if (moveHorizontal < 0 && facingRight || moveHorizontal > 0 && !facingRight)
		{
			Flip();
		}
	}

	void Update()
	{
		if (Input.GetButtonDown("Jump") && grounded)
		{
			rb.AddForce(Vector2.up * jumpForce);
		}
	}

	void Flip()
	{
		facingRight = !facingRight;

		var transform1 = transform;
		var scale = transform1.localScale;
		scale.x *= -1;
		transform1.localScale = scale;
	}

	public void DamagePlayer(int damage)
	{
		health -= damage;
		
		if (health <= 0)
		{
			health = 0;
			gameOverText.text = "SACRIFICE ACCEPTED";
			Time.timeScale = 0;
			Destroy(gameObject);
		}

		ChangeHealthText();
	}

	void ChangeHealthText()
	{ 
		healthText.text = $"HP: {health}";
	}
}
