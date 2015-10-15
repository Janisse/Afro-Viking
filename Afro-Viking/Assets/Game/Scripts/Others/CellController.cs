using UnityEngine;
using System.Collections;

public class CellController : MonoBehaviour {

	public float speed = 1f;
	public float JumpForce = 50f;
	public int JumpMax = 2;
	
	int currentJump = 0;
	float HorizontalSpeed = 0f;
	Rigidbody2D CellRigidBody = null;

	void Start ()
	{
		CellRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		InputUpdate ();
	}

	void InputUpdate()
	{
		if (Input.GetKey (KeyCode.Q))
		{
			HorizontalSpeed = -1f;
		}
		else if (Input.GetKey (KeyCode.D))
		{
			HorizontalSpeed = 1f;
		} 
		else
		{
			HorizontalSpeed = 0f;
		}
		
		transform.Translate(new Vector3(HorizontalSpeed * speed * Time.deltaTime,0f,0f));
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}

	void Jump ()
	{
		RaycastHit2D RH = Physics2D.Raycast(new Vector2 (transform.position.x,transform.position.y - 0.5f - 0.01f),
											Vector2.down);
		if (RH.distance <= 0.01f && RH.collider != null)
		{
			currentJump = 0;
		}
		
		if(currentJump < JumpMax)
		{
			currentJump++;
			CellRigidBody.velocity = new Vector2 (CellRigidBody.velocity.x,0f);
			CellRigidBody.AddForce(new Vector2 (0f , JumpForce));
		}
	}
}