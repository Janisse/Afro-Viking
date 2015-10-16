﻿using UnityEngine;
using System.Collections;

public class GameState : JState
{
	#region Properties
	private ResultPanel _resultPanel = null;
	#endregion

	#region State Methods
	internal override void Enter ()
	{
		base.Enter ();
		LoadLevel ("Level " + JEngine.Instance.gameManager.currentLevelID);

		_resultPanel = (ResultPanel)JEngine.Instance.uiManager.GetPanel ("ResultPanel");
		_resultPanel.SetDeathText (JEngine.Instance.gameManager.deathNb.ToString());
		Time.timeScale = 1f;
	}
	#endregion

	#region Events Methods
	internal override void RegisterForEvents ()
	{
		base.RegisterForEvents ();
		JEngine.Instance.eventManager.RegisterEvent("GameOver", OnGameOver);
		JEngine.Instance.eventManager.RegisterEvent("OnRestart", OnRestart);
		JEngine.Instance.eventManager.RegisterEvent("OnNextLevel", OnNextLevel);
	}

	internal override void UnregisterForEvents ()
	{
		base.UnregisterForEvents ();
		JEngine.Instance.eventManager.UnregisterEvent("GameOver", OnGameOver);
		JEngine.Instance.eventManager.UnregisterEvent("OnRestart", OnRestart);
		JEngine.Instance.eventManager.UnregisterEvent("OnNextLevel", OnNextLevel);
	}
	
	void OnGameOver(JEventArgs a_arg)
	{
		Time.timeScale = 0f;
		_resultPanel.DisplayPopup (false);	
	}

	void OnRestart(JEventArgs a_arg)
	{
		JEngine.Instance.gameManager.deathNb++;
		_resultPanel.SetDeathText (JEngine.Instance.gameManager.deathNb.ToString());
		JEngine.Instance.gameManager.changeGameMode ("CellGameMode");
	}

	void OnNextLevel(JEventArgs a_arg)
	{
		JEngine.Instance.gameManager.currentLevelID++;
		JEngine.Instance.gameManager.changeGameMode ("CellGameMode");
	}
	#endregion

	#region Methods
	internal void LoadLevel(string a_levelName)
	{
		Application.LoadLevelAdditive (a_levelName);
	}
	#endregion
}
