using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class levelManager : MonoBehaviour
{
    public static levelManager instance; 
    public Transform respawnPoint;
    public GameObject playerPref;

    
    void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPref, respawnPoint.position, Quaternion.identity);
    }
    
}
