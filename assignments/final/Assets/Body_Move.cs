using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static bool BodygetMIMIKey = false;
    public static float BodyGetCoin = 0f;
    public static bool KitchenTELE = false;
    public static bool LivingTELE = false;

    public string End1;
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
        if (other.CompareTag("Teleport1"))
        {
       
            
        }
        if (other.CompareTag("key"))
        {
            BodygetKey = true;
        }
        if (other.CompareTag("out"))
        {
            Debug.Log("End");
            SceneManager.LoadScene(End1);
        }
        if (other.CompareTag("speedup"))
        {
            aircraft.CurrentRemain += 1;
            print(aircraft.CurrentRemain);
            aircraft.getSpeedUP = true;
        }
        if (other.CompareTag("Mimi_key"))
        {
            BodygetMIMIKey = true;
        }
        if (other.CompareTag("mimiout"))
        {
            SceneManager.LoadScene("End2");
        }
        if (other.CompareTag("coin"))
        {
            BodyGetCoin += 1;
        }
    }


}
