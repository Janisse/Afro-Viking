using UnityEngine;
using System.Collections;

public class GameState : JState
{
	public AudioClip Death = null;
	public AudioClip Win = null;
	#region Properties
	private ResultPanel _resultPanel = null;
	#endregion

	#region State Methods
	internal override void Enter ()
	{
		base.Enter ();
		_resultPanel = (ResultPanel)JEngine.Instance.uiManager.GetPanel ("ResultPanel");
		LoadLevel ("Level " + JEngine.Instance.gameManager.currentLevelID);
		if(JEngine.Instance.gameManager.currentLevelID >= 6)
		{
			_resultPanel.SetScore("Bravo, tu as finis le jeu en étant mort " + JEngine.Instance.gameManager.deathNb.ToString() + " fois !");
		}

		_resultPanel.SetDeathText (JEngine.Instance.gameManager.deathNb.ToString());
		Time.timeScale = 1f;
	}

	internal override void Manage ()
	{
		base.Manage ();
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			JEngine.Instance.gameManager.deathNb = 0;
			JEngine.Instance.gameManager.currentLevelID = 1;
			JEngine.Instance.gameManager.changeGameMode ("MenuGameMode");
		}
	}

	internal override void Exit ()
	{
		base.Exit ();
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
		JEngine.Instance.eventManager.RegisterEvent("OnWin", OnWin);
		JEngine.Instance.eventManager.RegisterEvent("BackToMenu", BackToMenu);
	}

	internal override void UnregisterForEvents ()
	{
		base.UnregisterForEvents ();
		JEngine.Instance.eventManager.UnregisterEvent("GameOver", OnGameOver);
		JEngine.Instance.eventManager.UnregisterEvent("OnRestart", OnRestart);
		JEngine.Instance.eventManager.UnregisterEvent("OnNextLevel", OnNextLevel);
		JEngine.Instance.eventManager.UnregisterEvent("OnWin", OnWin);
		JEngine.Instance.eventManager.UnregisterEvent("BackToMenu", BackToMenu);
	}
	
	void OnGameOver(JEventArgs a_arg)
	{
		JEngine.Instance.audioManager.PlaySound2D(Death);
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
	
	void OnWin(JEventArgs a_arg)
	{
		JEngine.Instance.audioManager.PlaySound2D(Win);
		Time.timeScale = 0f;
		_resultPanel.DisplayPopup (true);
		switch(JEngine.Instance.gameManager.currentLevelID)
		{
		case 1:
			_resultPanel.SetWinText("Je me suis réveillée avant toi, rejoins moi dans l'aorte !");
			break;
		case 2:
			_resultPanel.SetWinText("Je suis allée chercher du pain dans l'estomac !");
			break;
		case 3:
			_resultPanel.SetWinText("Je suis allée profiter de la vue dans les globes occulaires !");
			break;
		case 4:
			_resultPanel.SetWinText("Je suis allée boire un verre dans le foie !");
			break;
		case 5:
			_resultPanel.SetWinText("Mon chéri te voilà, allons faire un tour dans le coeur !");
			break;
		}
	}

	void BackToMenu(JEventArgs a_arg)
	{
		JEngine.Instance.gameManager.currentLevelID = 1;
		JEngine.Instance.gameManager.deathNb = 0;
		JEngine.Instance.gameManager.changeGameMode ("MenuGameMode");
	}
	#endregion

	#region Methods
	internal void LoadLevel(string a_levelName)
	{
		Application.LoadLevelAdditive (a_levelName);
	}
	#endregion
}
