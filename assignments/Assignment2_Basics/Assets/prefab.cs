using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefab : MonoBehaviour
{
    public GameObject TreePrefab;
    public GameObject GressPrefab;
    public GameObject CrystalPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 150; i++)
        {
            generateTree();
        }
        for (int j = 0; j < 200; j++)
        {
            generateGress();
        }
        for (int k = 0; k < 10; k++)
        {
            generateCrystal();
        }
    }
    void generateTree()
    {
        float x = Random.Range(-4, 4.9f);
        float y = 0;
        float z;
        double temp = Random.Range(0, 2);
        if (temp == 0)
            z = Random.Range(-10, -2);
        else
            z = Random.Range(2, 10);
        Vector3 pos = new Vector3(x, y, z);
        GameObject treeObj = Instantiate(TreePrefab, pos, Quaternion.identity);

        float X = 0;
        float Y = Random.Range(-180, 180);
        float Z = 0;
        Vector3 Rotate = new Vector3(X, Y, Z);
        treeObj.transform.Rotate(Rotate);
    }

    void generateGress()
    {
        float Gx = Random.Range(16, 25);
        float Gy = 0;
        float Gz = Random.Range(-10,10);
 
        Vector3 GressV = new Vector3(Gx, Gy, Gz);
        GameObject GressObj = Instantiate(GressPrefab, GressV, Quaternion.identity);

    
    }
    void generateCrystal()
    {
        float Cx = Random.Range(0, 1.3f);
        float Cy = Random.Range(7.39f,20);
        float Cz = Random.Range(-1.8f, 1.81f);

        Vector3 CrystalV = new Vector3(Cx, Cy, Cz);
        GameObject CrystalObj = Instantiate(CrystalPrefab, CrystalV, Quaternion.identity);
    }
        // Update is called once per frame
        void Update()
    {
       

    }
}









