using UnityEngine;
using System.Collections;

public class MainMenuState : JState
{
	#region Properties

	#endregion

	#region State Methods

	#endregion

	#region Events Methods
	internal override void RegisterForEvents ()
	{
		base.RegisterForEvents ();
		JEngine.Instance.eventManager.RegisterEvent ("ContinueGame", ContinueGame);
	}

	internal override void UnregisterForEvents ()
	{
		base.UnregisterForEvents ();
		JEngine.Instance.eventManager.UnregisterEvent ("ContinueGame", ContinueGame);
	}

	internal void ContinueGame(JEventArgs args)
	{
		JEngine.Instance.gameManager.changeGameMode ("CellGameMode");
	}
	#endregion
}
