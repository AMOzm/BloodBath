using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyFromList : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm == null)
        {
            Debug.LogError("GameManager script not found in the scene.");
        }
    }

    void OnDestroy()
    {
        if (gm != null)
        {
            gm.RemoveFromList(gameObject);
        }
    }

}
