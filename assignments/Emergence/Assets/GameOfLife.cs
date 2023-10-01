using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject Camera1;
    public cell[,] cells;
    public float showingTime;
    public float Timecount=0;
    public float Gspeed = 5f;
    public float Gspeed2 = 5f;
    public bool startG = false;
    public TMP_Text GspeedText;
    public TMP_Text Gspeed2Text;

    // Start is called before the first frame update
    void Start()
    {
        cells = new cell[20, 20];

        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                Vector3 pos = transform.position;
                pos.x = pos.x + x * (1 + 0.1f);
                pos.z = pos.z + y * (1 + 0.1f);
                GameObject cellObj = Instantiate(cellPrefab, pos, transform.rotation);
                cells[x, y] = cellObj.GetComponentInChildren<cell>();
                cells[x, y].x = x;
                cells[x, y].y = y;
                cells[x, y].alive = (Random.value < 0.2f);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        showingTime = 1;

        GspeedText.text = Gspeed.ToString();
        Gspeed2Text.text = Gspeed2.ToString();

        if (startG)
        {
            if (Timecount < showingTime)
            {
                Timecount = Timecount + Time.deltaTime * Gspeed;
            }
            else
            {
                Timecount = 0;
                UpdateMap(Gspeed2);

            }
        }



        
    }

    public int[,] UpdateCells(int[,] tempview)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                int LiveNabor = 0;
                //LiveNabor = CellScript.CountLive(i, j);
                LiveNabor = GameObject.Find("CubeView").GetComponent<cell>().CountLive(i, j);
                if (cells[i, j].alive && (LiveNabor == 2 || LiveNabor == 3))
                {
                    tempview[i, j] = 1;
                    continue;
                }
                if (!cells[i, j].alive && LiveNabor == 3)
                {
                    tempview[i, j] = 1;
                    continue;
                }
                tempview[i, j] = 0;
            }
        }
        return tempview;
    }

    public cell[,] UpdateMap(float Gspeed2)
    {
        int[,] tempview = new int[20, 20];

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (cells[i, j].alive == true)
                {
                    tempview[i, j] = 1;
                }
                else
                {
                    tempview[i, j] = 0;
                }
            }
        }

        tempview = UpdateCells(tempview);

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (tempview[i, j] == 1)
                {
                    cells[i, j].alive = true;
                }
                else
                {
                    cells[i, j].alive = false;
                }
                cells[i, j].UpdateColor();
                cells[i, j].UpdateScale(Gspeed2);
            }
        }

        return cells;
    }

    public void PlusButtonClicked()
    {
        if (Gspeed < 10)
        {
            Gspeed++;
        }
    }
    public void MButtonClicked()
    {
        if (Gspeed >1)
        {
            Gspeed--;
        }
    }

    public void Plus2ButtonClicked()
    {
        if (Gspeed2 < 10)
        {
            Gspeed2++;
        }
    }
    public void M2ButtonClicked()
    {
        if (Gspeed2 > 1)
        {
            Gspeed2--;
        }
    }

    public void StartButtonClicked()
    {
        startG = true;
    }

    public void ResetButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void C1ButtonClicked()
    {
        Vector3 position1 = new Vector3(10f, 20f, 0f);
        Vector3 rotation1 = new Vector3(66.551f,0f,0f);
        Camera1.transform.position = position1;
        Camera1.transform.rotation = Quaternion.Euler(rotation1);
    }

    public void C2ButtonClicked()
    {
        Vector3 position2 = new Vector3(10.5f, 8.5f, -9.4f);
        Vector3 rotation2 = new Vector3(17.587f, 0f, 0f);
        Camera1.transform.position = position2;
        Camera1.transform.rotation = Quaternion.Euler(rotation2);
    }
}
