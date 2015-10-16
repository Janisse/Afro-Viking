using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	public Transform playerPos = null;
	public float offsetX = 5f;

	void Update ()
	{
		transform.position += (new Vector3(playerPos.position.x + offsetX, transform.position.y, transform.position.z) - transform.position) * Time.deltaTime;
	}
}
