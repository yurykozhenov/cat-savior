﻿using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed = 3;
	public float jumpForce = 500;
	public bool facingRight = true;

	private Rigidbody2D rb;
	private Animator animator;

	private bool grounded;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	private Vector3 startingPosition;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (transform.position.y < 0)
		{
			transform.position = startingPosition;
			return;
		}
		
		
		
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

	void Flip()
	{
		facingRight = !facingRight;
		
		var scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}