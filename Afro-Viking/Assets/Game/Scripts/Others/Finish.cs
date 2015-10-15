using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D a_collider)
	{
		if(a_collider.gameObject.tag == "Player")
		{
			JEngine.Instance.eventManager.FireEvent("OnNextLevel");
		}
	}
}
