using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // public static GameManager Instance;
    // public Vector3[] guestPos;
    // public GameObject[] guestList;
    // public float minSpawnDelay = 10f;
    // public float maxSpawnDelay = 30f;
    // public int maxWaitGuests = 3;
    // public List<GameObject> waitGuests = new List<GameObject>();
    // // public GameObject gridContainer;
    // // public GameObject UIOrders;
    // public int score;
    // [SerializeField] private TextMeshProUGUI scoreText;
    // // public List<GameObject> instantiatedUIList = new List<GameObject>();

    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // void Start()
    // {
    //     StartCoroutine(SpawnGuestsWithDelay());
    //     score = 0;
    //     scoreText.text = $"{score}";
    // }

    // public IEnumerator SpawnGuestsWithDelay()
    // {
    //     // if (guestPos.Length != guestList.Length)
    //     // {
    //     //     Debug.LogError("The number of guest positions and prefabs does not match.");
    //     //     yield break;
    //     // }

    //     for (int i = 0; i < guestList.Length; i++)
    //     {
    //         float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
    //         yield return new WaitForSeconds(randomDelay);

    //         // Get list of unoccupied positions
    //         List<Vector3> unoccupiedPositions = new List<Vector3>();
    //         foreach (Vector3 pos in guestPos)
    //         {
    //             bool positionOccupied = false;
    //             foreach (GameObject guest in waitGuests)
    //             {
    //                 if (Vector3.Distance(guest.transform.position, pos) < 0.1f)
    //                 {
    //                     positionOccupied = true;
    //                     break;
    //                 }
    //             }
    //             if (!positionOccupied)
    //             {
    //                 unoccupiedPositions.Add(pos);
    //             }
    //         }
    //         Debug.Log("Unoccupied positions: " + unoccupiedPositions.Count);

    //         // If there are open positions, randomly select one and spawn the guest
    //         if (unoccupiedPositions.Count > 0 && waitGuests.Count < maxWaitGuests)
    //         {
    //             Vector3 spawnPosition = unoccupiedPositions[Random.Range(0, unoccupiedPositions.Count)];
    //             int prefabIndex = Random.Range(0, guestList.Length);
    //             GameObject newGuest = Instantiate(guestList[prefabIndex], spawnPosition, Quaternion.identity);
    //             waitGuests.Add(newGuest);
    //         }
    //     }
    // }

    // public void RemoveFromList(GameObject guestPrefab)
    // {
    //     waitGuests.Remove(guestPrefab);
    //     Destroy(guestPrefab);
    // }
    // // public void HandleObjectDestroyed()
    // // {
    // //     Instantiate(UIOrders, gridContainer.transform);
    // // }
    // public void IncreaseScore()
    // {
    //     score++;
    //     //SaveScore();
    // }

    // // public void DecreaseScore()
    // // {
    // //     score--;
    // //     //SaveScore();
    // // }

    // void Update()
    // {
    //     scoreText.text = $"{score}";
        
    // }
     public static GameManager Instance;
    public Vector3[] guestPos;
    public GameObject[] guestList;
    public float minSpawnDelay = 10f;
    public float maxSpawnDelay = 30f;
    public int maxWaitGuests = 3;
    public List<GameObject> waitGuests = new List<GameObject>();
    public int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI EndScoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnGuestsWithDelay());
        score = 0;
        scoreText.text = $"{score}";
    }

    public IEnumerator SpawnGuestsWithDelay()
    {
        while (true) // Infinite loop
        {
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);

            // Get list of unoccupied positions
            List<Vector3> unoccupiedPositions = new List<Vector3>();
            foreach (Vector3 pos in guestPos)
            {
                bool positionOccupied = false;
                foreach (GameObject guest in waitGuests)
                {
                    if (Vector3.Distance(guest.transform.position, pos) < 0.1f)
                    {
                        positionOccupied = true;
                        break;
                    }
                }
                if (!positionOccupied)
                {
                    unoccupiedPositions.Add(pos);
                }
            }
            Debug.Log("Unoccupied positions: " + unoccupiedPositions.Count);

            // If there are open positions, randomly select one and spawn the guest
            if (unoccupiedPositions.Count > 0 && waitGuests.Count < maxWaitGuests)
            {
                Vector3 spawnPosition = unoccupiedPositions[Random.Range(0, unoccupiedPositions.Count)];
                int prefabIndex = Random.Range(0, guestList.Length);
                GameObject newGuest = Instantiate(guestList[prefabIndex], spawnPosition, Quaternion.identity);
                waitGuests.Add(newGuest);
            }
        }
    }

    public void RemoveFromList(GameObject guestPrefab)
    {
        waitGuests.Remove(guestPrefab);
        Destroy(guestPrefab);
    }

    public void IncreaseScore()
    {
        score++;
        // SaveScore();
    }

    void Update()
    {
        scoreText.text = $"{score}";
        EndScoreText.text = $"Your Score: {score}";
    }
}
