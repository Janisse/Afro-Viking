using UnityEngine;
using System.Collections;

public abstract class AActivable : MonoBehaviour {

	protected bool isActivate;
	virtual internal void Activate(bool activate)
	{
		isActivate = activate;
	}
}
