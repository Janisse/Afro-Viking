﻿using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	#region Properties
	public Vector3 dir = Vector3.zero;
	public float speed = 1f;
	#endregion

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += dir * Time.deltaTime * speed;
	}
}