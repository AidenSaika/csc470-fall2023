using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static event Action<player> UnitSelectedHappened;
    public GameObject Camera1;
    public GameObject Minefab;
    public GameObject Rockfab;
    public static GameManager SharedInstance;
    public List<player> units = new List<player>();

    public GameObject player1;
    public GameObject player2;
    public TMP_Text Fuel_1;
    public TMP_Text Fuel_2;
    public TMP_Text Target;
    public TMP_Text Coin_1;
    public TMP_Text Coin_2;
    player selectedUnit;

    float TotalCoin = 0f;

    void Awake()
    {
        if (SharedInstance != null)
        {
            Debug.Log("Error");
        }
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            generateRock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fuel_1.text = Mathf.RoundToInt(player1.GetComponent<player>().Currentfuel).ToString();
        Fuel_2.text = Mathf.RoundToInt(player2.GetComponent<player>().Currentfuel).ToString();
        Coin_1.text = Mathf.RoundToInt(player1.GetComponent<player>().currentCoin).ToString();
        Coin_2.text = Mathf.RoundToInt(player2.GetComponent<player>().currentCoin).ToString();
        TotalCoin = player1.GetComponent<player>().CoinGet + player2.GetComponent<player>().CoinGet;
        Target.text = Mathf.RoundToInt(TotalCoin).ToString();


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 999999))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
                {

                    if (selectedUnit != null)
                    {
                        selectedUnit.SetTarget(hit.point);
                        
                    }
                }
            }
        }

        if (player1.GetComponent<player>().Currentfuel==0 && player2.GetComponent<player>().Currentfuel==0)
        {
            SceneManager.LoadScene("End1");
        }

        if (TotalCoin>=500)
        {
            SceneManager.LoadScene("End2");
        }

    }

    public void SelectUnit(player unit)
    {
        foreach (player u in units)
        {
            u.selected = false;
            u.SetUnitColor();
        }
        selectedUnit = unit;
        selectedUnit.selected = true;
        selectedUnit.SetUnitColor();

        UnitSelectedHappened?.Invoke(unit);
    }

    public void C1ButtonClicked()
    {
        Vector3 position1 = new Vector3(1.91f, 3.73f, -8.94f);
        Vector3 rotation1 = new Vector3(25.917f, 0f, 0f);
        Camera1.transform.position = position1;
        Camera1.transform.rotation = Quaternion.Euler(rotation1);
    }

    public void C2ButtonClicked()
    {
        Vector3 position2 = new Vector3(-0.8163642f, 22.8f, -0.39f);
        Vector3 rotation2 = new Vector3(90f, 0f, 0f);
        Camera1.transform.position = position2;
        Camera1.transform.rotation = Quaternion.Euler(rotation2);
    }

    public void MineButtonClicked()
    {
        if (TotalCoin>=150)
        {
            generateMine();
        }
        
    }

    void generateMine()
    {
        while(true){
            float x = Random.Range(-23.88f, 24.22f);
            float y = -0.03f;
            float z = Random.Range(-12.25f, 13.77f);
            if ((x>-5 &&x<5.9)&&(y>-6&&y<6.8))
            {
                continue;
            }
            else
            {
                Vector3 pos = new Vector3(x, y, z);
                GameObject MineObj = Instantiate(Minefab, pos, Quaternion.identity);
                float X = 0;
                float Y = Random.Range(-91, 45);
                float Z = 0;
                Vector3 Rotate = new Vector3(X, Y, Z);
                MineObj.transform.Rotate(Rotate);
                break;
            }
        }
    }
    void generateRock()
    {
            float x = Random.Range(-23.88f, 24.22f);
            float y = 0.138f;
            float z = Random.Range(-12.25f, 13.77f);

            Vector3 pos = new Vector3(x, y, z);
            GameObject RockObj = Instantiate(Rockfab, pos, Quaternion.identity);
            float X = 0;
            float Y = Random.Range(-180, 180);
            float Z = 0;
            Vector3 Rotate = new Vector3(X, Y, Z);
        RockObj.transform.Rotate(Rotate);

            
        
    }

}
