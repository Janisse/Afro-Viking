using UnityEngine;
using System.Collections;

public class GameButton : MonoBehaviour {

	public AActivable Button = null;
	public AActivable Activable = null;
	
	void OnCollisionEnter2D(Collision2D a_collider)
	{
		if (a_collider.gameObject.tag == "Player")
		{
			Button.Activate(true);
			Activable.Activate(true);
		}
	}
	
	void OnCollisionExit2D(Collision2D a_collider)
	{
		if (a_collider.gameObject.tag == "Player")
		{
			Button.Activate(false);
			Activable.Activate(false);
		}
	}
}