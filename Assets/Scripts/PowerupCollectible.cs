using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController controller;

    void Start()
    {
        controller = GameObject.Find("CarBody").GetComponent<PlayerController>();
    }
    
     void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object that entered the trigger : " + other);
        controller.IncreaseSpeed();
        Destroy(gameObject);
        
    }
}
