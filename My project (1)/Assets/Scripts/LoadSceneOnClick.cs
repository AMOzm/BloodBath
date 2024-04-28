using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadSceneOnClick : MonoBehaviour
{
    public int sceneTwoNumber;
    // Start is called before the first frame update
    public void LoadSceneRight()
    {
        SceneManager.UnloadSceneAsync(sceneTwoNumber);
        GameManager.Instance.IncreaseScore();

    }
    public void LoadSceneWrong()
    {
        SceneManager.UnloadSceneAsync(sceneTwoNumber);
    }
}
