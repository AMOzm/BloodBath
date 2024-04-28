using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChoice : MonoBehaviour
{
    // Start is called before the first frame update
    public Image colorChoice;
    public Color[] choices;
    void Awake()
    {
        if (choices != null && choices.Length > 0)
        {
            // Get a random index within the array bounds
            int randomIndex = Random.Range(0, choices.Length);

            // Get the renderer component of the GameObject
            // Renderer renderer = GetComponent<Renderer>();
            //Renderer renderer = colorChoice.GetComponent<Renderer>();
            colorChoice.color = choices[randomIndex];

            
        }
        else
        {
            Debug.LogWarning("Colors array is empty or not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChoice.color == choices[0]){
            gameObject.tag = "red";
        }
        else if (colorChoice.color == choices[1]){
            gameObject.tag = "green";
        }
        else if (colorChoice.color == choices[2]){
            gameObject.tag = "blue";
        }
        
    }
}
