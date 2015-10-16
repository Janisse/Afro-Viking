using UnityEngine;
using System.Collections;

public class CanonActivable : AActivable {

	public Cannon CanonToUnactive = null;
	
	void Awake ()
	{
		if (CanonToUnactive == null)
		{
			CanonToUnactive = gameObject.GetComponent<Cannon>();
		}
	}
	
	internal override void Activate (bool activate)
	{
		base.Activate (activate);
		CanonToUnactive.isOn = !activate;
	}
}