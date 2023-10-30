using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraft : MonoBehaviour
{
    float forwardSpeed = 15f;
    float xRotationSpeed = 40f;
    float zRotationSpeed = 40f;
    float accSpeed = 0;
    float accSpeed2 = 0;
    bool  CameraChange = false;

    public CharacterController cc;
    float gravityModifier = 0.05f;
    float yVelocity = 0;

    public GameObject cameraObject;
    public GameObject fan;
    public GameObject Key;

    public static bool AirgetKey = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            accSpeed = 20 ;
            
        }
            
        accSpeed -= 5 * Time.deltaTime;
        accSpeed = Mathf.Max(0, accSpeed);


        forwardSpeed -= 1.5f * Time.deltaTime;
        forwardSpeed = Mathf.Max(0, forwardSpeed);
    

        float XRotation = -vAxis * xRotationSpeed * Time.deltaTime;
        float ZRotation = -hAxis * zRotationSpeed * Time.deltaTime;
        transform.Rotate(-XRotation, 0, ZRotation, Space.Self);
        gameObject.transform.position += gameObject.transform.forward* Time.deltaTime * (forwardSpeed + accSpeed + accSpeed2);

        if (!cc.isGrounded)
        {
            yVelocity = gravityModifier;
        }
        else
        {
            yVelocity = 0;
        }

        Vector3 amountToMove = gameObject.transform.forward * (forwardSpeed + accSpeed + accSpeed2);
 
        cc.Move(amountToMove * Time.deltaTime);

        Vector3 currentPosition = transform.position;
        currentPosition.y -= yVelocity;
        transform.position = currentPosition;

        if (Input.GetKeyDown(KeyCode.C))
        {
            CameraChange = !CameraChange;
        }

        if (CameraChange)
        {
            cameraObject.transform.position = transform.position - transform.forward * 10 + Vector3.up * 5;
            cameraObject.transform.LookAt(transform);
        }
        else
        {
  

            Vector3 position1 = new Vector3(0f, 4.88f, -9.13f);
            Vector3 rotation1 = new Vector3(18.537f, 0f, 0f);
            cameraObject.transform.localPosition = position1;
            cameraObject.transform.localRotation = Quaternion.Euler(rotation1);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            forwardSpeed = 30f;
            Debug.Log("TTT");
        }
        if (other.CompareTag("key"))
        {
            AirgetKey = true;
            Destroy(Key);
        }
    }
}
