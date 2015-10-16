using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellController : MonoBehaviour
{
	public GameObject CellPrefab = null;
	public List <CellMotor> motors;
	public CameraMove cameraMove = null;
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
		
		if(Input.GetKeyDown(KeyCode.K))
		{
			if(motors[CellMotorSelected].Split() && motors.Count < 2)
			{
				Object newCell = Instantiate(CellPrefab as Object,motors[CellMotorSelected].transform.position + new Vector3(0.1f,0f,0f),Quaternion.identity);
				motors.Add((newCell as GameObject).GetComponent<CellMotor>());
				CellMotorSelected = motors.Count-1;
				motors[CellMotorSelected].Select(true);
				cameraMove.playerPos = motors[CellMotorSelected].transform;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.L))
		{
			motors[CellMotorSelected].Select(false);
			CellMotorSelected++;
			if(CellMotorSelected == motors.Count)
				CellMotorSelected = 0;
				
			motors[CellMotorSelected].Select(true);
			cameraMove.playerPos = motors[CellMotorSelected].transform;
		}
	}
}