using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCode : MonoBehaviour
{
    public static float CoinProduce;
    // Start is called before the first frame update
    void Start()
    {
        CoinProduce = Random.Range(20, 100);

    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
