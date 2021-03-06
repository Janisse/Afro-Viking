﻿using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	#region Properties
	public Vector3 dir = Vector3.zero;
	public float speed = 1f;
	public float lifeTime = 5f;
	#endregion

	// Use this for initialization
	void Start ()
	{
		if(lifeTime > 0)
			Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += dir * Time.deltaTime * speed;
		transform.Rotate (new Vector3(0f, 0f, 360f * Time.deltaTime));
	}
	
	void OnCollisionEnter2D(Collision2D a_collider)
	{
            		if(a_collider.gameObject.tag == "Player")
		{
			JEngine.Instance.eventManager.FireEvent("GameOver");
		}
	}
}
