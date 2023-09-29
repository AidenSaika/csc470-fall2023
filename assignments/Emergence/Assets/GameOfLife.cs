using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    public cell[,] cells;
    public cell CellScript;
    int LiveNabor = 0;

    // Start is called before the first frame update
    void Start()
    {
        cells = new cell[20, 20];

        for (int x=0; x < 20; x++)
        {
            for(int y=0; y<20; y++)
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
       UpdateCells();

    }

    public void UpdateCells()
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
                    cells[i, j].alive = true;
                    continue;
                }
                if (!cells[i, j].alive && LiveNabor == 3)
                {
                    cells[i, j].alive = true;
                    continue;
                    
                }
                cells[i, j].alive = false;

                cells[i, j].UpdateColor();

            }
        }
    }

}
