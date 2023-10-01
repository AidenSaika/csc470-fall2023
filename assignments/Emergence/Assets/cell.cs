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

            rend.material.SetColor("_EmissionColor", Color.yellow);
            rend.material.SetFloat("_EmissionIntensity", 9.0f);



        }
        else
        {
            rend.material.color = deadC;
            rend.material.SetColor("_EmissionColor", Color.blue);
            rend.material.SetFloat("_EmissionIntensity", 1.0f);

        }
    }

    public void UpdateScale(float speed)
    {
        float currentHeight = transform.localScale.y;

        if (alive)
        {

            float newHeight = currentHeight + (Time.deltaTime * speed);

            if (newHeight<=5){

                transform.localScale = new Vector3(1, newHeight, 1);
                Vector3 newPosition = transform.position;
                newPosition.y = transform.position.y + (newHeight - currentHeight) / 2.0f;
                transform.position = newPosition;
            }


        }
        else
        {
            float newHeight = currentHeight - (Time.deltaTime * speed);

            if (newHeight>=1){
                transform.localScale = new Vector3(1, newHeight, 1);
                Vector3 newPosition = transform.position;
                newPosition.y = transform.position.y - (currentHeight- newHeight) / 2.0f;
                transform.position = newPosition;
            }
           
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
