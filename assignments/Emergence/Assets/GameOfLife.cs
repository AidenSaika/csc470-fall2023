using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    cell[,] cells;
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
                cells[x, y] = cellObj.GetComponent<cell>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
