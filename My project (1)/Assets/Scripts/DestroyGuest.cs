using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGuest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guest1;
    public GameObject guest2;
    public GameObject guest3;
    public GameObject guest4;
    public GameObject guest5;
    public GameObject guest6;
    void Update(){
        DestroyObjectDelayed();
    }
    void DestroyObjectDelayed()
    //this is not something that comes with unity so call on this in update
    {
        
        Destroy(guest1, 5);
        Destroy(guest2, 3);
        Destroy(guest3, 6);
        Destroy(guest4, 2);
        Destroy(guest5, 4);
        Destroy(guest6, 7);
    }
}
