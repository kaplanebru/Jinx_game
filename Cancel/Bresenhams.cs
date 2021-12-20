using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bresenhams : MonoBehaviour
{
    /*List<int> xValues = new List<int>();
    List<int> yValues = new List<int>();*/
    public Rigidbody2D pxlPb;
    float unit = 0.085f;
    public int R = 4;

    // Start is called before the first frame update
    void Start()
    {   
        Physics2D.gravity = Vector2.zero;
        Circle(R);
    }

    // Update is called once per frame
    void Update()
    {
         //Circle(4);
    }

    void SpawnPxl(float x, float y)
    {
            Rigidbody2D pxl = Instantiate(pxlPb, SpawnPos(x, y), transform.rotation);
    }

    Vector2 SpawnPos(float x, float y)
    {
        var pos = new Vector2(x, y);
        return pos;
    }

    void Circle(float r)
    {
        float x = 0;
        float y = r*unit;
        float decisionPoint = (3-2*r)*unit;
        SpawnPxl(x, y);
            //xValues.Add(x);
            //yValues.Add(y);
        while(x<y)
        {
            if (decisionPoint <= 0)
            {
                x+=unit;
                decisionPoint += (4*x + 6)*unit;
            }
            else
            {
                x+=unit;
                y-=unit;
                decisionPoint += 4*(x-y) + 10;
            }
            /*xValues.Add(x);
            yValues.Add(y);*/
            SpawnPxl(x, y);
            SpawnPxl(y, x);
            SpawnPxl(x, -y);
            SpawnPxl(y, -x);
            SpawnPxl(-x, -y);
            SpawnPxl(-y, -x);
            SpawnPxl(-x, y);
            SpawnPxl(-y, x);
        }

        /*for (int i = 0; i < xValues.Count; i++)
         {

             Debug.Log("x = " + xValues[i]);
             Debug.Log("y = " + yValues[i]);
         }*/
    }
}
