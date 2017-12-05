using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using System.Text;

public class Button : MonoBehaviour {

    public Sprite Disactive, Active;
    [SerializeField]
    int LevelIndex;

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = Active;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = Disactive;
    }

    private void OnMouseUpAsButton()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(LevelIndex);
        //SceneManager.LoadScene(LevelIndex);
        //Scene scene = SceneManager.GetSceneByName(stringBuilder.ToString());
        //Debug.Log(LevelIndex);
        //SceneManager.LoadScene(scene.name);
        Application.LoadLevel("1");
    }
}