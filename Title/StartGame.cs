using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : SceneMng
{
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Return))
        { 
            SceneChange();
        }
    }
}
