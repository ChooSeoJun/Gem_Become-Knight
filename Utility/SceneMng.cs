using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    public string SceneName;

    public void SceneChange()
    {
        SceneManager.LoadScene(SceneName);
    }
}
