using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string Scene;

    public void ChangeScene()
    {
        Application.LoadLevel(Scene);
    }
}