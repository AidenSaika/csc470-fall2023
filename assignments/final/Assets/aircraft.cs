using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aircraft : MonoBehaviour
{
    float forwardSpeed = 15f;
    float xRotationSpeed = 40f;
    float zRotationSpeed = 40f;
    float accSpeed = 0;
    float accSpeed2 = 0;
    float gravityModifier = 0.05f;
    float yVelocity = 0;
    float Thespeed;
    float TTCoin;
    public static float CurrentRemain;
    public static float AirGetCoin;

    bool CameraChange = false;

    public CharacterController cc;
    public GameObject cameraObject;
    public GameObject fan;
    public GameObject Key;


    public static bool AirgetKey = false;
    public static bool getSpeedUP = false;
    public static bool AirgetMIMIKey = false;
    public static bool AirgetOutKey = false;
    public static bool AOutKeyG = false;

    public string End1;



    GameManager Mana;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        GameObject ManaOBJ = GameObject.Find("GameManager");
        Mana = ManaOBJ.GetComponent<GameManager>();
        CurrentRemain = Mana.GCountSPEEDup;

    }

    // Update is called once per frame
    void Update()
    {
        CoinGET();
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift)&& CurrentRemain>0)
        {

            accSpeed = 20 ;
            CurrentRemain -= 1;
        }
            
        accSpeed -= 5 * Time.deltaTime;
        accSpeed = Mathf.Max(0, accSpeed);


        forwardSpeed -= 1.5f * Time.deltaTime;
        forwardSpeed = Mathf.Max(0, forwardSpeed);

        Thespeed = forwardSpeed + accSpeed + accSpeed2;

        float XRotation = -vAxis * xRotationSpeed * Time.deltaTime;
        float ZRotation = -hAxis * zRotationSpeed * Time.deltaTime;
        transform.Rotate(-XRotation, 0, ZRotation, Space.Self);
        gameObject.transform.position += gameObject.transform.forward* Time.deltaTime * (Thespeed);




        if (!cc.isGrounded && (forwardSpeed + accSpeed + accSpeed2)<=8)
        {
            if ((forwardSpeed + accSpeed + accSpeed2) <= 6)
            {
                yVelocity += 4 * gravityModifier * Time.deltaTime;
            }
            else
            {
                yVelocity += gravityModifier * Time.deltaTime;
            }
        }
        if (cc.isGrounded) { 
            yVelocity = 0;
        }

        print(Thespeed);

        Vector3 amountToMove = gameObject.transform.forward * (Thespeed);
 
        cc.Move(amountToMove * Time.deltaTime);

        Vector3 currentPosition = transform.position;
        if (currentPosition.y > -24f)
        {
            currentPosition.y -= yVelocity;
        }
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
    void CoinGET()
    {
        TTCoin = AirGetCoin + Body_Move.BodyGetCoin;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            forwardSpeed = 30f;
            Debug.Log("TTT");
        }
        if (other.CompareTag("Bank"))
        {
            if (TTCoin >= 30)
            {
                AOutKeyG = true;
                print("outkey");
            }
        }
        if (other.CompareTag("key"))
        {
            AirgetKey = true;
        }
        if (other.CompareTag("Mimi_key"))
        {
            AirgetMIMIKey = true;
        }
        if (other.CompareTag("OutDoorKey"))
        {
            AirgetOutKey = true;
            print("outkey");
        }
        if (other.CompareTag("out"))
        {
            SceneManager.LoadScene(End1);
            Debug.Log("End");
        }
        if (other.CompareTag("speedup"))
        {
            CurrentRemain += 1;
            print(CurrentRemain);
            getSpeedUP = true;
        }
        if (other.CompareTag("mimiout"))
        {
            SceneManager.LoadScene("End2");
        }
        if (other.CompareTag("coin"))
        {
            AirGetCoin += 1;
        }
    }
}
