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
        //print(x + ", " + y);
        alive = !alive;
        UpdateColor();
        
        print(CountLive(x,y));
    }
    public int CountLive(int X, int Y)
    {
        int aliveN = 0;
        for (int xIndex = X - 1; xIndex <= X+1;  xIndex++)
        {
            if (0 <= xIndex && xIndex < 20)
            {
                for (int yIndex = Y + 1; yIndex >= Y - 1; yIndex--)
                {
                    if (0 <= yIndex && yIndex < 20)
                    {
                        if (GOL.cells[xIndex, yIndex].alive)
                        {
                            if (xIndex == X && yIndex == Y)
                            {
                                continue;
                            }
                            else
                            {
                                aliveN++;
                            }
                        }
                    }
                    else { continue; }
                }
            }
            else { continue; }
        } 
        return aliveN;
    }

}
