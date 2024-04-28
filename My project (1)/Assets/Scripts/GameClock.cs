using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClock : MonoBehaviour
{
   
    private int currentHour = 9;
    private int currentMinute = 0;

    [SerializeField] private TextMeshProUGUI clockText;
    
    [SerializeField] private CanvasGroup End;
    public bool fadeIn;

    void Start()
    {
        
        UpdateClockText();
        InvokeRepeating("UpdateClock", 1f, 1f); // Update clock every second
    }

    void UpdateClock()
    {
        // Increment minute
        currentMinute++;

        // If minute reaches 60, increment hour and reset minute to 0
        if (currentMinute == 60)
        {
            currentHour++;
            currentMinute = 0;
        }

        // If hour reaches 17 (5:00 PM), reset the clock to 9:00 AM
        if (currentHour == 10)
        {
            fadeIn = true;

            // currentHour = 9;
            // currentMinute = 0;
        }

        // Update the UI text
        UpdateClockText();
    }

    void UpdateClockText()
    {
        // Format the time and update the clock text
        string hourString = currentHour.ToString().PadLeft(2, '0');
        string minuteString = currentMinute.ToString().PadLeft(2, '0');
        clockText.text = $"{hourString}:{minuteString} ";
    }
    void Update(){
        if(fadeIn){
        if(End.alpha < 1){
            End.alpha += Time.deltaTime;
            if(End.alpha >= 1){
                fadeIn = false;
            }
        }
      }
    }
}
