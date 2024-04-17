using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // private AssetBundle myLoadedAssetBundle;
    // private string[] scenePaths;
    // public string sceneName;

    // void Start(){
    //     myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
    //     scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    // }
    // Start is called before the first frame update
    // public void LoadScene(string sceneName){
    //     SceneManager.LoadScene(sceneName);
    // }
    
    // public void OnMouseDown(){
    //     SceneManager.LoadScene("sceneName");
    //     Debug.Log("whaaat");
    //}
    public int sceneNumber;
    public Vector3 originalPos;
    public Vector3 newPos;
    public GameObject slider;
    // public Timer timer;
    public GameObject guestPrefab;
    // public bool moved;
   
    void Start(){
        // moved = false;
        originalPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
    }
    public void OnMouseDown(){
        // if (gameObject.transform.position == originalPos){
        //     gameObject.transform.position = newPos;
        //     // moved = true;
        //     // Destroy(slider);
        //     timer.ResetTimer();
            
        // }
        // else{
        //     SceneManager.LoadScene(sceneNumber);
        // Debug.Log("whaaat");
        // }
        Destroy(gameObject);
        Instantiate(guestPrefab, newPos, Quaternion.identity);
        
    }
}

