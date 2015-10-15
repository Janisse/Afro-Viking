#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class JButton : MonoBehaviour
{
    #region Properties
    public string key = "";
    public string args = "";

    private Button _button;
    #endregion

    #region Class Methods
    internal void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClicked);
    }
    #endregion

    #region Button Methods
    internal void ButtonClicked()
    {
        if (JEngine.Instance.uiManager.nbPanelInTransition == 0)
        {
            JEventArgs eventArgs = new JEventArgs();
            eventArgs.strArg = args;
            JEngine.Instance.eventManager.FireEvent(key, eventArgs);
        }
    }
    #endregion

    #if UNITY_EDITOR
    #region Inspector Methods
    [MenuItem("JEngine/UI/JButton")]
    private static void AddJButtonOnInspector()
    {
        GameObject newButton = (GameObject)Instantiate(Resources.Load("Button"), Vector3.zero, Quaternion.identity);
        newButton.transform.SetParent(Selection.activeGameObject.transform);
        newButton.name = "Button";
    }
    #endregion
    #endif
}
