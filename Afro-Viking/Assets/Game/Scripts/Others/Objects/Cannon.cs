using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	#region Properties
	public Transform fireSpot = null;
	public float fireRate = 1f;
	public Missile missilePrefab = null;
	public float missileSpeed = 1f;
	public bool isOn = true;

	private float nextMissileTime = 0f;
	#endregion

	#region GameObject Methods	
	// Update is called once per frame
	void Update ()
	{
		nextMissileTime -= Time.deltaTime;
		if(nextMissileTime <= 0f)
		{
			FireMissile();
		}
	}
	#endregion

	#region Methods
	internal void FireMissile()
	{
		nextMissileTime = fireRate;
		Missile newMissile = (Missile)Instantiate (missilePrefab);
		newMissile.transform.position = fireSpot.position;
		newMissile.dir = fireSpot.forward;
		newMissile.speed = missileSpeed;
	}
	#endregion
}
