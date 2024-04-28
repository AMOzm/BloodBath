using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DragDrop : MonoBehaviour
{
    
    private bool dragging = false;
    private float distance;
    private Vector3 startDist;
    private Vector3 originalPosition;
    public float distanceThreshold = 1f;
    public Transform targetObject;
    public int sceneTwoNumber;
    public LoadSceneOnClick LSOC;
   
    void Start (){
        originalPosition = transform.position;
    }
 
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
    }
 
    void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, targetObject.position) < distanceThreshold)
        {
            if(gameObject.CompareTag("RedC")){
            ChangeColor(Color.red); 
            LSOC.LoadSceneRight();
            }
            if(gameObject.CompareTag("GreenC")){
            ChangeColor(Color.green); 
            LSOC.LoadSceneWrong();
            }
            if(gameObject.CompareTag("BlueC")){
            ChangeColor(Color.blue); 
            LSOC.LoadSceneWrong();
            }
        }
        else
        {
            ChangeColor(Color.white); // Reset target object color if the dragged object is far
            transform.position = originalPosition; // Return the dragged object to its original position
        }
        dragging = false;
    }
 
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDist;
        }
    }
    void ChangeColor(Color color)
    {
        Renderer renderer = targetObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
