using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellController : MonoBehaviour
{
	public GameObject CellPrefab = null;
	public List <CellMotor> motors;
	int CellMotorSelected = 0;
	
	void Update ()
	{
		InputUpdate ();
	}

	void InputUpdate()
	{
		if(Input.GetKey (KeyCode.Q))
		{
			motors[CellMotorSelected].MoveHorizontaly(-1);
		}
		else if (Input.GetKey (KeyCode.D))
		{
			motors[CellMotorSelected].MoveHorizontaly(1);
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			motors[CellMotorSelected].Jump();
		}
		
		if(Input.GetKey(KeyCode.K))
		{
			if(motors[CellMotorSelected].Split())
			{
				Object newCell = Instantiate(CellPrefab as Object);
				motors.Add((newCell as GameObject).GetComponent<CellMotor>());
				CellMotorSelected = motors.Count-1;
			}
		}
		
		if(Input.GetKey(KeyCode.L))
		{
			CellMotorSelected++;
			if(CellMotorSelected == motors.Count)
				CellMotorSelected = 0;
		}
	}
}