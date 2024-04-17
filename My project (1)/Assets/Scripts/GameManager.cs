using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3[] guestPos;
    public GameObject[] guestList;
    // public float spawnDelay = 20f;
    public float minSpawnDelay = 10f; // Minimum delay between spawns
    public float maxSpawnDelay = 30f; // Maximum delay between spawns
    public int maxWaitGuests = 3; // Max number of guests in scene
    private List<GameObject> waitGuests = new List<GameObject>();
  
    // Start is called be]fore the first frame update
    void Start()
    {
        StartCoroutine(SpawnGuestsWithDelay());
    }
    IEnumerator SpawnGuestsWithDelay(){
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
            {
                GameObject newGuest = Instantiate(guestList[i], guestPos[i], Quaternion.identity);
                waitGuests.Add(newGuest);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
