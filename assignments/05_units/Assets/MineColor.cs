using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineColor : MonoBehaviour
{
    public Renderer MineRenderer;
    public Color HighColor;
    public Color MidColor;
    Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (MineCode.CoinProduce >= 50 && MineCode.CoinProduce < 80)
        {
            MineRenderer.material.color = MidColor;
        }
        if (MineCode.CoinProduce >= 80 && MineCode.CoinProduce <= 100)
        {
            MineRenderer.material.color = HighColor;
        }
        else
        {
            MineRenderer.material.color = defaultColor;
        }
    }
}
