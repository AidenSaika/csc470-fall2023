using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{
    GameOfLife GOL;
    public bool alive = false;
    public int x = -1;
    public int y = -1;
    public Color aliveC;
    public Color deadC;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GOLobj = GameObject.Find("GameOfLifeOBJ");
        GOL = GOLobj.GetComponent<GameOfLife>();
        rend = gameObject.GetComponentInChildren<Renderer>();
        UpdateColor();

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void UpdateColor()
    {
        if (alive)
        {
            rend.material.color = aliveC;
        }
        else
        {
            rend.material.color = deadC;
        }
    }
    
    private void OnMouseDown()
    {
        alive = !alive;
        UpdateColor();
        //Debug.Log(x + ", " + y + "alive: " + alive);
        Debug.Log(CountLive());
    }
    int CountLive()
    {
        int alive = 0;
        for (int xIndex = x - 1; xIndex <= x+1; xIndex++)
        {
            for (int yIndex = y - 1; yIndex <= y + 1; yIndex++)
            {
                if(GOL.cells[xIndex, yIndex].alive)
                {
                    alive++;
                }
            }
        } 

        return alive;
    }

}
