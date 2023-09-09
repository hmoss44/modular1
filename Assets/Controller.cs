using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public Transform CamTransform;
	public Rigidbody2D rb;
	public float moveSpeed;
	public float jumpAmount;
	public float gravSpeed2;
	public Collider2D grav2;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		
		float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed * moveSpeed * Time.deltaTime;
		float sidewaysSpeed = Input.GetAxis("Horizontal") * moveSpeed * moveSpeed * Time.deltaTime;

		transform.position += (transform.forward * forwardSpeed) + (transform.right * sidewaysSpeed);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
		}


	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
		while(collision.gameObject.CompareTag("Ground"))
		{
			jumpAmount = 8f;
		}
	}

}