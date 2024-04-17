using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public float gameTime;
    private bool stopTimer;
    public GameObject guest;
    public Vector3 originalBarPos;
    // public Vector3 BarPos;
    private float time;
    // public SceneManagerScript sm;
    
    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        time = gameTime;
        originalBarPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        // BarPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTimer){
        time -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes *60);
        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerSlider.value = time;
        if (time <= 0){
            Debug.Log("is true;");
            stopTimer = true;
            Destroy(guest);
        }
        }
        // if (stopTimer == false){
        //     Debug.Log("is false;");
        //     timerText.text = textTime;
            // timerSlider.value = time;
         //}
        //  if(gameObject.transform.position != originalBarPos){
        //     Debug.Log("moved.");
        //     ResetTimer();
        //     }
        
        
    }
    // public void ResetTimer(){
        
    //     stopTimer = false;
    //     timerSlider.value = gameTime;
    //     Debug.Log("heyyy" + timerSlider.value);
    //     //timerText.text = string.Format("{0:0}:{1:00}", Mathf.FloorToInt(gameTime / 60), Mathf.FloorToInt(gameTime % 60));
    // }
}
