using UnityEngine;
using System.Collections;

public class GameButton : MonoBehaviour {

	public AActivable Button = null;
	public AActivable[] Activable = null;
	
	int HowManyEnter = 0;
	
	void OnCollisionEnter2D(Collision2D a_collider)
	{
		if (a_collider.gameObject.tag == "Player")
		{
			HowManyEnter ++;
			if(HowManyEnter == 1)
			{
				Button.Activate(true);
				for(int i = 0 ; i< Activable.Length ; ++i)
					Activable[i].Activate(true);
			}
		}
	}
	
	void OnCollisionExit2D(Collision2D a_collider)
	{
		if (a_collider.gameObject.tag == "Player")
		{
			HowManyEnter --;
			
			if(HowManyEnter == 0)
			{
				Button.Activate(false);
				for(int i = 0 ; i< Activable.Length ; ++i)
					Activable[i].Activate(false);
			}
		}
	}
}