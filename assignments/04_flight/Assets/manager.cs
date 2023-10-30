using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Aircraft;
    public GameObject human;
    public GameObject CurrentOBJ;
    public GameObject Key;

    bool IsPlane = false;
    bool IsHuman = false;
    bool MoveChange = false;

    bool getKey = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentOBJ = generateBeginingHuman();
        IsPlane = false;
        TheKey();
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



    void ISgetkey()
    {
        if (aircraft.AirgetKey || Body_Move.BodygetKey)
        {
            getKey = true;
            Debug.Log("key");
        }
    }
        

}
