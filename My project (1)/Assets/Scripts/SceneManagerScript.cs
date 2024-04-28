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
    public GameObject Orders;
    public GameObject guestWaitPrefab;
    //public GameObject UIOrders;
    [SerializeField] private GameManager gm;
    //public GameObject gridContainer;
    private SpriteRenderer spriteRenderer;
    public Sprite tooLong;
    private GameObject instantiatedUI;
    public float bathDelay;
    public Color newColor = Color.red;
    private bool outBath;
    private bool gameDone;
    
    
    
    
    // public bool moved;
    void Awake()
    {
        // UIOrders = FindObjectOfType<UIHolder>();
        gm = FindObjectOfType<GameManager>(); // Find the GameManager script in the scene
        if (gm == null)
        {
            Debug.LogError("GameManager script not found in the scene.");
        }
        //gridContainer = GameObject.FindGameObjectWithTag("grid");
    }
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        
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
            Vector3 emptyPosition = FindEmptyPosition();
            
            if (emptyPosition != Vector3.zero)
            {
                // gm.Remove();
                //gameObject.GetComponent<SpriteRenderer>().sprite = guestBath;
                //transform.position = emptyPosition;
                Instantiate(guestPrefab, emptyPosition, Quaternion.identity);
                
                //instantiatedUI = Instantiate(UIOrders, gridContainer.transform);
                
                //  gm.HandleObjectDestroyed();
                
                Destroy(guestWaitPrefab);
                
                // gm.waitGuests.RemoveAt(1);
                

            }
            else
            {
                Debug.LogWarning("No empty position found to instantiate the guest.");
            }
        
        
        
        }
        // else if (!gameObject.CompareTag("change")){
        //     if(gameDone == false){
        //     //Destroy(guestPrefab);
        //         Destroy(Orders);
        //         SceneManager.LoadScene(sceneNumber, LoadSceneMode.Additive);
        //         gameDone = true;

        //     //StartCoroutine(ChangeSpriteAfterDelay());
        //         Invoke("ChangeSprite", bathDelay);
        //     }
            
             
        //     // if (instantiatedUI != null)
        //     // {
        //     //     Destroy(instantiatedUI);
        //     // }
        //     //  else
        //     // {
        //     //     Debug.LogWarning("No UI prefab instance to destroy.");
        //     // }
        //     if(outBath == true && gameDone == true){
        //         Destroy(guestPrefab);
        //     }
            
        
        //  }
         else if (gameObject.CompareTag("red")){
            sceneNumber = 2;
            if(gameDone == false){
            //Destroy(guestPrefab);
                Destroy(Orders);
                SceneManager.LoadScene(sceneNumber, LoadSceneMode.Additive);
                gameDone = true;

            //StartCoroutine(ChangeSpriteAfterDelay());
                Invoke("ChangeSprite", bathDelay);
            }
            
            if(outBath == true && gameDone == true){
                Destroy(guestPrefab);
            }
            
        
         }
         else if (gameObject.CompareTag("green")){
            sceneNumber = 3;
            if(gameDone == false){
            //Destroy(guestPrefab);
                Destroy(Orders);
                SceneManager.LoadScene(sceneNumber, LoadSceneMode.Additive);
                gameDone = true;

            //StartCoroutine(ChangeSpriteAfterDelay());
                Invoke("ChangeSprite", bathDelay);
            }
            
            if(outBath == true && gameDone == true){
                Destroy(guestPrefab);
            }
            
        
         }
         else if (gameObject.CompareTag("blue")){
            sceneNumber = 4;
            if(gameDone == false){
            //Destroy(guestPrefab);
                Destroy(Orders);
                SceneManager.LoadScene(sceneNumber, LoadSceneMode.Additive);
                gameDone = true;

            //StartCoroutine(ChangeSpriteAfterDelay());
                Invoke("ChangeSprite", bathDelay);
            }
            
            if(outBath == true && gameDone == true){
                Destroy(guestPrefab);
            }
            
        
         }
}
public void ChangeSprite(){
            //yield return new WaitForSeconds(bathDelay);
            spriteRenderer.sprite = tooLong;
            spriteRenderer.color = newColor;
            outBath = true;

            }
Vector3 FindEmptyPosition()
    {
        foreach (Vector3 position in newPos)
        {
            bool positionOccupied = false;
             foreach (GameObject guest in GameObject.FindGameObjectsWithTag("red"))
            {
                if (Vector3.Distance(guest.transform.position, position) < 5f)
                {
                    positionOccupied = true;
                    break;
                }
            }

            foreach (GameObject guest in GameObject.FindGameObjectsWithTag("green"))
            {
                if (Vector3.Distance(guest.transform.position, position) < 5f)
                {
                    positionOccupied = true;
                    break;
                }
            }

            foreach (GameObject guest in GameObject.FindGameObjectsWithTag("blue"))
            {
                if (Vector3.Distance(guest.transform.position, position) < 5f)
                {
                    positionOccupied = true;
                    break;
                }
            }
            if (!positionOccupied)
            {
                return position;
            // }
            // foreach (GameObject guest in GameObject.FindGameObjectsWithTag("blue"))
            // {
            //     if (Vector3.Distance(guest.transform.position, position) < 5f) // Adjust the threshold as needed
            //     {
            //         positionOccupied = true;
            //         break;
            //     }
            // }
            // if (!positionOccupied)
            // {
            //     return position;
            // }
            // foreach (GameObject guest in GameObject.FindGameObjectsWithTag("green"))
            // {
            //     if (Vector3.Distance(guest.transform.position, position) < 5f) // Adjust the threshold as needed
            //     {
            //         positionOccupied = true;
            //         break;
            //     }
            // }
            // if (!positionOccupied)
            // {
            //     return position;
            }
        }
        return Vector3.zero;
    }
}



