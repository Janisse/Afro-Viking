using UnityEngine;
using System.Collections;

public class ResultPanel : JPanel
{
	#region Properties
	public GameObject winPopup = null;
	public GameObject loosePopup = null;
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
	#endregion
}
