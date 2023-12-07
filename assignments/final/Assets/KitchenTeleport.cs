using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTeleport : MonoBehaviour
{
    
    public Vector3 teleportLocation = new Vector3(-373.1f, -21.75f, 224.31f); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TeleportCurrentObject(new Vector3(-373.1f, -21.75f, 224.31f));


        }
    }
}
