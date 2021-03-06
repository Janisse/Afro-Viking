﻿using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	#region Properties
	public GameObject CanonFerme = null;
	public GameObject CanonOuvert = null;
	
	public Transform fireSpot = null;
	public float fireRate = 1f;
	public float delayStart = 0f;
	public Missile missilePrefab = null;
	public float missileSpeed = 1f;
	public float missileLifeTime = 5f;
	public bool isOn = true;

	private float nextMissileTime = 0f;
	private float closeCanon = 0f;
	#endregion

	#region GameObject Methods	
	void Start()
	{
		if(isOn)
		{
			ActivateCannon(isOn);
		}
	}

	void Update ()
	{
		if(closeCanon <= 0f)
		{
			CanonFerme.SetActive(true);
			CanonOuvert.SetActive(false);
		}
		else
		{
			closeCanon -= Time.deltaTime;
		}
		
		if(isOn)
		{
			nextMissileTime -= Time.deltaTime;
			if(nextMissileTime <= 0f)
			{
				FireMissile();
			}
		}
	}
	#endregion

	#region Methods
	internal void ActivateCannon(bool a_isOn)
	{
		isOn = a_isOn;
		if(isOn)
			nextMissileTime = delayStart;
	}

	internal void FireMissile()
	{
		CanonFerme.SetActive(false);
		CanonOuvert.SetActive(true);
		closeCanon = 0.5f;
		
		nextMissileTime = fireRate;
		Missile newMissile = (Missile)Instantiate (missilePrefab);
		newMissile.transform.position = fireSpot.position;
		newMissile.dir = fireSpot.forward;
		newMissile.speed = missileSpeed;
		newMissile.lifeTime = missileLifeTime;
	}
	#endregion
}
