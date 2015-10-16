using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultPanel : JPanel
{
	#region Properties
	public GameObject winPopup = null;
	public GameObject loosePopup = null;
	public GameObject scorePopup = null;
	public Text deathText = null;
	public Text scoreText = null;
	#endregion

	#region Methods
	internal void DisplayPopup(bool isWin)
	{
		if(isWin)
		{
			winPopup.SetActive(true);
			loosePopup.SetActive(false);
		}
		else
		{
			winPopup.SetActive(false);
			loosePopup.SetActive(true);
		}
	}

	internal void ClearPopup()
	{
		winPopup.SetActive(false);
		loosePopup.SetActive(false);
	}

	internal void SetDeathText(string a_text)
	{
		deathText.text = a_text;
	}

	internal void SetScore(string a_text)
	{
		scorePopup.SetActive (true);
		scoreText.text = a_text;
	}
	#endregion
}
