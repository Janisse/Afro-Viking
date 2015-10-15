using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal class JRoot : MonoBehaviour
{
    #region Properties
    public Canvas uiCanvas = null;
    public UnityEngine.UI.Text debugText = null;
    public JAudioManager audioManager = null;
    public List<string> gameModeList = null;
    public string gameModeToLoadOnStart = "MenuGameMode";
    #endregion

    #region Class Methods
    void Awake()
    {
        JEngine.Instance.root = this;

        //Init UI
        JEngine.Instance.uiManager.uiCanvas = uiCanvas;

        //Init Audio
        JEngine.Instance.audioManager = this.audioManager;

        //Start First GameMode
        JEngine.Instance.gameManager.changeGameMode(gameModeToLoadOnStart);

        //Start Debug Methods
        StartCoroutine(SetFPSCount());
    }

    void Update()
    {
        JEngine.Instance.Manage();
    }
    #endregion

    #region Debug Methods
    internal IEnumerator SetFPSCount()
    {
        while(true)
        {
            debugText.text = "FPS: " + (1.0f / Time.deltaTime).ToString("0.00");
            yield return new WaitForSeconds(0.25f);
        }
    }
    #endregion
}
