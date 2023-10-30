using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Aircraft;
    public GameObject human;
    public GameObject CurrentOBJ;
    public GameObject Key;
    public GameObject Door;
    public GameObject Out;

    bool IsPlane = false;
    bool IsHuman = false;
    bool MoveChange = false;
    bool getKey = false;
    bool isOut = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentOBJ = generateBeginingHuman();
        IsPlane = false;
        TheKey();
        TheDoor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MoveChange = !MoveChange;
        }
        if (MoveChange && !IsPlane)
        {
            IsPlane = true;
            IsHuman = false;
            if (IsPlane)
            {
                Destroy(CurrentOBJ);
                CurrentOBJ = generatePlane();
                ;
            }
        }
        if (!MoveChange && !IsHuman)
        {
            IsPlane = false;
            IsHuman = true;
            if (IsHuman)
            {
                Destroy(CurrentOBJ);
                CurrentOBJ = generateHuman();

            }
        }
        ISgetkey();
        if (getKey)
        {
            Destroy(Key);
            Destroy(Door);
            if (!isOut)
            {
                TheOut();
                isOut = !isOut;
            }

        }

    }


    GameObject generateBeginingHuman()
    {
        Vector3 pos = new Vector3(0, 5, 0);
        GameObject humanOBJ = Instantiate(human, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        humanOBJ.transform.Rotate(Rotate);
        return humanOBJ;
    }

    GameObject generatePlane()
    {
        Vector3 pos = CurrentOBJ.transform.position;
        GameObject AircraftOBJ = Instantiate(Aircraft, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, CurrentOBJ.transform.eulerAngles.y, 0);
        AircraftOBJ.transform.Rotate(Rotate);
        return AircraftOBJ;
    }
    GameObject generateHuman()
    {
        Vector3 pos = CurrentOBJ.transform.position;
        GameObject humanOBJ = Instantiate(human, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, CurrentOBJ.transform.eulerAngles.y, 0);
        humanOBJ.transform.Rotate(Rotate);
        return humanOBJ;
    }
    GameObject TheKey()
    {
        Vector3 pos = new Vector3(-25.05f, 45.05f, -21.3f);
        Key = Instantiate(Key, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0,0,0);
        Key.transform.Rotate(Rotate);
        return Key;
    }

    GameObject TheDoor()
    {
        Vector3 pos = new Vector3(7.5f, -25.8f, -31f);
        Door = Instantiate(Door, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        Door.transform.Rotate(Rotate);
        return Door;
    }
    GameObject TheOut()
    {
        Vector3 pos = new Vector3(33.23837f, -23.51944f, -256.9805f);
        Out = Instantiate(Out, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        Out.transform.Rotate(Rotate);
        return Out;
    }


    void ISgetkey()
    {
        if (aircraft.AirgetKey || Body_Move.BodygetKey)
        {
            getKey = true;
            Debug.Log("key");
        }
    }
        

}
