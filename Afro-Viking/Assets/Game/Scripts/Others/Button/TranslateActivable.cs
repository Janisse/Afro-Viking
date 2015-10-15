using UnityEngine;
using System.Collections;

public class TranslateActivable : AActivable
{
	public Vector3 ToTranslate = new Vector3 (0f,0f,0f);
	Vector3 initPosition;
	float t = 0;
	void Start()
	{
		initPosition = transform.position;
	}
	
	void Update()
	{
		if(isActivate && transform.position != initPosition + ToTranslate)
		{
			transform.position = new Vector3 (Mathf.Lerp(initPosition.x,(initPosition + ToTranslate).x,t),
			                                  Mathf.Lerp(initPosition.y,(initPosition + ToTranslate).y,t),
			                                  Mathf.Lerp(initPosition.z,(initPosition + ToTranslate).z,t));
			t+=Time.deltaTime;
			Mathf.Min(t,1f);
		}
		else if(!isActivate && transform.position != initPosition)
		{
			transform.position = new Vector3 (Mathf.Lerp(initPosition.x,(initPosition + ToTranslate).x,t),
			                                  Mathf.Lerp(initPosition.y,(initPosition + ToTranslate).y,t),
			                                  Mathf.Lerp(initPosition.z,(initPosition + ToTranslate).z,t));
			t-=Time.deltaTime;
			Mathf.Max(t,0f);
		}
	}
	
	internal override void Activate (bool activate)
	{
		base.Activate (activate);
		t = activate ? 0f : 1f;
	}
	
	
}
