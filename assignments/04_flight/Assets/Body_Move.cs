using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Move : MonoBehaviour
{
    public CharacterController cc;

    public GameObject fan;

    float fowardSpeed = 10f;
    float RotationSpeed = 70f;
    float jumpForce = 15f;
    float gravityModifier = 2.5f;
    float yVelocity = 0;
    bool doublejump = true;
    float accSpeed = 0f;
    public GameObject Key;

    public static bool BodygetKey = false;


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

        transform.Rotate(0, hAxis * RotationSpeed * Time.deltaTime, 0, Space.Self);

        if (!cc.isGrounded) { 
            yVelocity += Physics.gravity.y * Time.deltaTime * gravityModifier;
            if (Input.GetKeyDown(KeyCode.Space)& doublejump)
            {
                yVelocity = jumpForce;
                doublejump = !doublejump;
            }
        }
        else
        {
            yVelocity = -1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
            doublejump = true;
        }


        Vector3 amountToMove = vAxis * transform.forward * (fowardSpeed + accSpeed);
        amountToMove.y = yVelocity;

        cc.Move(amountToMove * Time.deltaTime);



        if (Input.GetKey(KeyCode.LeftShift))
        {
            fowardSpeed = 20f;
        }
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            fowardSpeed = 10f;
        }



        accSpeed -= 10 * Time.deltaTime;
        accSpeed = Mathf.Max(0, accSpeed);
      


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            accSpeed = 30f;
            Debug.Log("TTT");
        }
        if (other.CompareTag("key"))
        {
            BodygetKey = true;
            Destroy(Key);
        }
    }


}
