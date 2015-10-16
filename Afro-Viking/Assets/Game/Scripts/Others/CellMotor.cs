using UnityEngine;
using System.Collections;

public class CellMotor : MonoBehaviour {
	
	public int JumpMax = 2;
	public float JumpForce = 50f;
	public float speed = 1f;
	public float speedSprint = 4f;
	
	public bool CanSplit = true;
	public bool CanJump = true;
	public bool CanSprint = true;

	public GameObject smokePrefab = null;
	int currentJump = 0;
	
	Rigidbody2D CellRigidBody = null;
	
	void Start ()
	{
		CellRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	internal void MoveHorizontaly(float a_horizontalSpeed)
	{
		float aSpeed = speed;
		if (Input.GetKey (KeyCode.LeftShift) && CanSprint)
			aSpeed = speedSprint;
		transform.Translate(new Vector3(a_horizontalSpeed * aSpeed * Time.deltaTime,0f,0f));
	}
	
	internal void Jump ()
	{
		RaycastHit2D RH = Physics2D.CircleCast(new Vector2 (transform.position.x,transform.position.y - 0.5f - 0.01f),
		                                       0.11f,
		                                       Vector2.down);
		if (RH.distance <= 0.01f && RH.collider != null)
		{
			currentJump = 0;
		}
		
		if(currentJump < JumpMax && CanJump)
		{
			currentJump++;
			CellRigidBody.velocity = new Vector2 (CellRigidBody.velocity.x,0f);
			CellRigidBody.AddForce(new Vector2 (0f , JumpForce));
			GameObject obj = Instantiate(smokePrefab);
			obj.transform.position = transform.position - Vector3.up * 0.3f;
			Destroy(obj, 2f);
		}
	}
	
	internal bool Split()
	{
		if(CanSplit)
		{
			CanSplit = false;
			return true;
		}
		return false;
	}
	
	internal void Select(bool a_selected)
	{
	
	}
}