#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

public class RootSceneLauncher : Editor
{
    #region Inspector Methods
    [MenuItem("JEngine/Play %m")]
    public static void RootSceneLaunch()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("/Assets/JEngine/Scenes/RootScene.unity");
        EditorApplication.isPlaying = true;
    }
    #endregion
}
#endif
