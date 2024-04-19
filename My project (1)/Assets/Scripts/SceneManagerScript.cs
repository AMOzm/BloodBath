using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    
    public int sceneNumber;
    // public Vector3 originalPos;
    public Vector3[] newPos;
    // public GameObject slider;
    // public Timer timer;
    public GameObject guestPrefab;
    public GameObject guestWaitPrefab;
    public GameObject UIOrders;
    [SerializeField] private GameManager gm;
    
    
    
    // public bool moved;
    void Awake()
    {
        // UIOrders = FindObjectOfType<UIHolder>();
        gm = FindObjectOfType<GameManager>(); // Find the GameManager script in the scene
        if (gm == null)
        {
            Debug.LogError("GameManager script not found in the scene.");
        }
    }
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
                // gm.Remove();
                Instantiate(guestPrefab, emptyPosition, Quaternion.identity);
                Instantiate(UIOrders);
                
                Destroy(guestWaitPrefab);
                
                // gm.waitGuests.RemoveAt(1);
                

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


