using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public GameObject Aircraft;
    public GameObject human;
    public GameObject CurrentOBJ;
    public GameObject Key;
    public GameObject Door;
    public GameObject Out;
    public GameObject Up;
    public GameObject MIMI_DOOR;
    public GameObject MIMI_OUT;
    public GameObject MIMI_KEY;
    public GameObject OutKey; 
    public GameObject Gatesound;
    public GameObject Kitchensound;
    public GameObject sgatesound;
    public GameObject OUTKEYMENTION;

    bool isGatesound = true;
    bool isKitchensound = true;
    bool issgatesound = true;

    bool IsPlane = false;
    bool IsHuman = false;
    bool MoveChange = false;
    bool getKey = false;
    bool getmiKey = false;
    bool FirstGenerate = true;
    bool isOutMI = false;
    bool OutKG = true;
    public static bool GetBUTTON = false;

    public float GCountSPEEDup =0f;
    float CountShow = 0f;
    float Goutkey = 0;
    public  float CoinCllect;
    float GetKeyCount = 0f;
    float GetSKeyCount = 0f;

    public TMP_Text CoinText;
    public TMP_Text SpeedCount;
    public TMP_Text GetKeyText;
    public TMP_Text GetSKeyText;
    public TMP_Text OutKeyGText;

    public static GameManager Instance;

    public float delay = 4f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GCountSPEEDup = 2f;
        CurrentOBJ = generateBeginingHuman();
        IsPlane = false;
        TheKey();
        TheDoor();
        TheUp();
        TheMIMIDOOR();
        TheMIMIKEY();
    }

    // Update is called once per frame
    void Update()
    {
        if (getKey)
        {
            GetKeyCount = 1;
        }
        if (getmiKey)
        {
            GetSKeyCount = 1;
        }
        GetKeyText.text = GetKeyCount.ToString();

        GetSKeyText.text = GetSKeyCount.ToString();

        OutKeyGText.text = Goutkey.ToString();

        CountShow = GCountSPEEDup;

        SpeedCount.text = CountShow.ToString();

        GCountSPEEDup = aircraft.CurrentRemain;

        CoinGET();

        CoinText.text = CoinCllect.ToString();


        if (CountShow == 0 && FirstGenerate){
            GCountSPEEDup = GCountSPEEDup + 2;
            FirstGenerate = false;

        }

        if (Body_Move.BOutKeyG || aircraft.AOutKeyG)
        {
            if(OutKG)
            {
                OutG();
                OutKG = false;
                Goutkey = 1;
                GameObject canvas = Instantiate(OUTKEYMENTION);
                Destroy(canvas, delay);
            }
        }

        if (Body_Move.BodygetOutKey || aircraft.AirgetOutKey)
        {
            if (isGatesound)
            {
                TheGatesound();
                isGatesound = false;
            }
        }

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
            if (isKitchensound)
            {
                TheKitchensound();
                isKitchensound = false;
            }  
        }

        if (aircraft.getSpeedUP)
        {
            Destroy(Up);
        }

        ISgetMIMIkey();
        if (getmiKey)
        {
            Destroy(MIMI_KEY);
            Destroy(MIMI_DOOR);
            if (!isOutMI)
            {
                TheMIMIOUT();
                isOutMI = !isOutMI;
            }
            if (issgatesound)
            {
                Thesgatesound();
                issgatesound = false;
            }
        }

    }

    public void TeleportCurrentObject(Vector3 newPosition)
    {
        if (CurrentOBJ != null)
        {
            CurrentOBJ.transform.position = newPosition;
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
    GameObject OutG()
    {
        Vector3 pos = new Vector3(21.99f, -15.19f, -246.51f);
        OutKey = Instantiate(OutKey, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        OutKey.transform.Rotate(Rotate);
        return OutKey;
    }

    GameObject TheMIMIKEY()
    {
        Vector3 pos = new Vector3(  19.76f, 5.538062f, 142.56f);
        MIMI_KEY = Instantiate(MIMI_KEY, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        MIMI_KEY.transform.Rotate(Rotate);
        return MIMI_KEY;
    }

    GameObject TheGatesound()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Gatesound = Instantiate(Gatesound, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        Gatesound.transform.Rotate(Rotate);
        return Gatesound;
    }
    GameObject TheKitchensound()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Kitchensound = Instantiate(Kitchensound, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        Kitchensound.transform.Rotate(Rotate);
        return Kitchensound;
    }
    GameObject Thesgatesound()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        sgatesound = Instantiate(sgatesound, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        sgatesound.transform.Rotate(Rotate);
        return sgatesound;
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

    GameObject TheUp()
    {
        Vector3 pos = new Vector3(-3.41f, 0.93f, 21.82f);
        Up = Instantiate(Up, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        Up.transform.Rotate(Rotate);
        return Up;
    }

    GameObject TheMIMIDOOR()
    {
        Vector3 pos = new Vector3(-23.75f, -23.46f, -23.66f);
        MIMI_DOOR = Instantiate(MIMI_DOOR, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, -92f, 0);
        MIMI_DOOR.transform.Rotate(Rotate);
        return MIMI_DOOR;
    }
    GameObject TheMIMIOUT()
    {
        Vector3 pos = new Vector3(-23.39529f, -25.96094f, -14.3338f);
        MIMI_OUT = Instantiate(MIMI_OUT, pos, Quaternion.identity);
        Vector3 Rotate = new Vector3(0, 0, 0);
        MIMI_OUT.transform.Rotate(Rotate);
        return MIMI_OUT;
    }


    void ISgetkey()
    {
        if (aircraft.AirgetKey || Body_Move.BodygetKey)
        {
            getKey = true;
            Debug.Log("key");
        }
    }

    void ISgetMIMIkey()
    {
        if (aircraft.AirgetMIMIKey || Body_Move.BodygetMIMIKey)
        {
            getmiKey = true;
        }
    }

    void CoinGET()
    {
        CoinCllect = aircraft.AirGetCoin + Body_Move.BodyGetCoin;
    }




}
