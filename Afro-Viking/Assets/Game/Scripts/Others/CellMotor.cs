using UnityEngine;
using System.Collections;

public class CellMotor : MonoBehaviour {
	
	public int JumpMax = 2;
	public float JumpForce = 50f;
	public float speed = 1f;
	public bool CanSplit = true;
	public GameObject smokePrefab = null;
	int currentJump = 0;
	
	Rigidbody2D CellRigidBody = null;
	
	void Start ()
	{
		CellRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	internal void MoveHorizontaly(float a_horizontalSpeed)
	{
		transform.Translate(new Vector3(a_horizontalSpeed * speed * Time.deltaTime,0f,0f));
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
		
		if(currentJump < JumpMax)
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