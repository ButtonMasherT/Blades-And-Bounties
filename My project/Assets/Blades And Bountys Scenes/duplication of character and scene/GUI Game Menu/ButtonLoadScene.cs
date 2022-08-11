using System.Collections;

using UnityEngine;

public class ButtonLoadScene : MonoBehaviour
{
    public string _sceneName = string.Empty;

    [System.Obsolete]
    public void OnButtonPressed()
    {
        Application.LoadLevel(_sceneName);
    }
} 

