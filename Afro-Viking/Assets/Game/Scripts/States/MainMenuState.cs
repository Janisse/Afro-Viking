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
		JEngine.Instance.eventManager.RegisterEvent ("Quit", Quit);
	}

	internal override void UnregisterForEvents ()
	{
		base.UnregisterForEvents ();
		JEngine.Instance.eventManager.UnregisterEvent ("ContinueGame", ContinueGame);
		JEngine.Instance.eventManager.UnregisterEvent ("Quit", Quit);
	}

	internal void ContinueGame(JEventArgs args)
	{
		JEngine.Instance.gameManager.changeGameMode ("CellGameMode");
	}

	internal void Quit(JEventArgs args)
	{
		Application.Quit ();
	}
	#endregion
}
