using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imposter : MonoBehaviour
{
    public GameObject imposster;
    public float speed = 5.0f;
    public float rotationSpeed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += speed * Time.deltaTime;
        transform.position = currentPosition;


        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.z -= rotationSpeed * Time.deltaTime;
        currentRotation.y = 0f;
        currentRotation.x = 0f;
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
