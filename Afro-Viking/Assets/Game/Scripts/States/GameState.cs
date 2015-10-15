using UnityEngine;
using System.Collections;

public class GameState : JState
{
	#region Properties

	#endregion

	#region State Methods
	internal override void Enter ()
	{
		base.Enter ();
		LoadLevel ("Level 1");
	}
	#endregion

	#region Events Methods
	internal override void RegisterForEvents ()
	{
		base.RegisterForEvents ();
	}

	internal override void UnregisterForEvents ()
	{
		base.UnregisterForEvents ();
	}
	#endregion

	#region Methods
	internal void LoadLevel(string a_levelName)
	{
		Application.LoadLevelAdditive (a_levelName);
	}
	#endregion
}
