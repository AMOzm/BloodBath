using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    
    public int sceneNumber;
    // public Vector3 originalPos;
    public Vector3[] newPos;
    // public GameObject slider;
    // public Timer timer;
    public GameObject guestPrefab;
    
    
    // public bool moved;
   
    void Start(){
        // moved = false;
        //originalPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
    }
    public void OnMouseDown(){
        // if (gameObject.transform.position == originalPos){
        //     gameObject.transform.position = newPos;
        //     // moved = true;
        //     // Destroy(slider);
        //     timer.ResetTimer();
            
        // }
        if (gameObject.CompareTag("change")){
             SceneManager.LoadScene(sceneNumber);
         Debug.Log("whaaat");
         }
        else {
            Vector3 emptyPosition = FindEmptyPosition();
            
            if (emptyPosition != Vector3.zero)
            {
                Instantiate(guestPrefab, emptyPosition, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("No empty position found to instantiate the guest.");
            }
        
        
        
    }
}
Vector3 FindEmptyPosition()
    {
        foreach (Vector3 position in newPos)
        {
            bool positionOccupied = false;
            foreach (GameObject guest in GameObject.FindGameObjectsWithTag("change"))
            {
                if (Vector3.Distance(guest.transform.position, position) < 0.1f) // Adjust the threshold as needed
                {
                    positionOccupied = true;
                    break;
                }
            }
            if (!positionOccupied)
            {
                return position;
            }
        }
        return Vector3.zero;
    }
}


