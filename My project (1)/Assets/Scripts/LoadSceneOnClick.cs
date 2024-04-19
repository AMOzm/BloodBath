using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public int sceneTwoNumber;
    // Start is called before the first frame update
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneTwoNumber);
    }
}
