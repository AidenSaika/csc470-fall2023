using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float speed = 0.5f;
    float speed1 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed1 = 2.5f;
        }
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            speed1 = 1;
        }

        
        if (transform.position.x > 5.25)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.back * speed1 * Time.deltaTime);
            }
        }
     
         
        if (Input.GetKey(KeyCode.DownArrow))  
        {
           transform.Translate(Vector3.forward * speed1 * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))  
        {
           transform.Translate(Vector3.left * speed1 * Time.deltaTime);
        }  
        
        if (Input.GetKey(KeyCode.RightArrow))  
        {
           transform.Translate(Vector3.right * speed1 * Time.deltaTime);
        }  

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(Vector3.back, speed);
        }
        if (Input.GetKey(KeyCode.Space) == false)
        {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 90, -180);
        }


    }
}
