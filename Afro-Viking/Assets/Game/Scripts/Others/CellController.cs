using UnityEngine;
using System.Collections;

public class CellController : MonoBehaviour {

	public float speed = 1f;
	public float JumpForce = 50f;
	
	bool Jump = false;
	bool Fire = false;
	float HorizontalSpeed = 0f;
	Rigidbody2D CellRigidBody = null;

	void Start ()
	{
		CellRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		InputUpdate ();
		MoveUpdate ();
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
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Jump = true;
		}
		
		if (Input.GetKey (KeyCode.J))
		{
			Fire = true;
		} 
	}

	void MoveUpdate ()
	{
		transform.Translate(new Vector3(HorizontalSpeed * speed * Time.deltaTime,0f,0f));

		if(Jump)
		{
			RaycastHit2D RH = Physics2D.Raycast(new Vector2 (transform.position.x,transform.position.y - 0.5f - 0.01f),
												Vector2.down);
			if (RH.distance <= 0.01f && RH.collider != null)
			{
				CellRigidBody.AddForce(new Vector2 (0f , JumpForce));
			}
			
			Jump = false;
		}
	}
}