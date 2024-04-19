using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Vector3[] guestPos;
    public GameObject[] guestList;
    // public float spawnDelay = 20f;
    public float minSpawnDelay = 10f; // Minimum delay between spawns
    public float maxSpawnDelay = 30f; // Maximum delay between spawns
    public int maxWaitGuests = 3; // Max number of guests in scene
    public List<GameObject> waitGuests = new List<GameObject>();
    //public GameObject newGuest;
    // public int waitGuests = new int();
  
    // Start is called be]fore the first frame update
    void Start()
    {
        StartCoroutine(SpawnGuestsWithDelay());
        
    }
    public IEnumerator SpawnGuestsWithDelay(){
        if (guestPos.Length != guestList.Length)
        {
            Debug.LogError("The number of guest positions and prefabs does not match.");
            yield break;
        }
         for (int i = 0; i < guestPos.Length; i++)
        {
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);
            if (waitGuests.Count < maxWaitGuests)
            // if (waitGuests < maxWaitGuests)
            {
                GameObject newGuest = Instantiate(guestList[i], guestPos[i], Quaternion.identity);
                //newGuest = Instantiate(guestList[i], guestPos[i], Quaternion.identity);
                waitGuests.Add(newGuest);
                // Instantiate(guestList[i], guestPos[i], Quaternion.identity);
                // waitGuests ++;
            }
        }
    }
    public void RemoveFromList(GameObject guestPrefab)
    {
        waitGuests.Remove(guestPrefab);
    }
    //  public void Remove(){
    //     waitGuests --;
    //  }

    // Update is called once per frame
    void Update()
    {
        
    }
}
