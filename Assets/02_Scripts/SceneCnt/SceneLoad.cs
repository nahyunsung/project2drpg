using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    public void sceneLoad(string sceneName)
    {
        LoadingSceneController.LoadScene(sceneName);
    }
}
