using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BresenhamsMain : MonoBehaviour
{
    /*List<int> xValues = new List<int>();
    List<int> yValues = new List<int>();*/
    public Rigidbody2D pxlPb;
    public int R = 4;
    float period = 1;
    float time = 1;

    // Start is called before the first frame update
    void Start()
    {   
        Physics2D.gravity = Vector2.zero;
        //GenerateCircle();
    }

    // Update is called once per frame
    void Update()
    {
         UpdateCircle();
    }

    void SpawnPxl(int x, int y)
    {
            Rigidbody2D pxl = Instantiate(pxlPb, SpawnPos(x, y), transform.rotation);
            //x = x + unit;
            //y = y + unit;
    }

    Vector2 SpawnPos(int x, int y)
    {
        var pos = new Vector2(x, y);
        return pos;
    }

    void Circle(int r, int xMultiplier, int yMultiplier)
    {
        SpawnPxl(0, r);
        SpawnPxl(r, 0);
        SpawnPxl(0, -r);
        SpawnPxl(-r, 0);

        int x = 0;
        int y = r;

        int decisionPoint = 3-2*r;

        Debug.Log("x = " + x + " " + "y = " + y);

        while(x<=y)
        {
            if (decisionPoint <= 0)
            {
                x+= 1;
                decisionPoint += 4*x + 6;
            }
            else if (decisionPoint > 0)
            {
                x+=1;
                y-=1;
                decisionPoint += 4 * (x-y) + 10;
            }

            SpawnPxl(x * xMultiplier, y * yMultiplier);
            SpawnPxl(y * yMultiplier, x * xMultiplier);

            // x>y ise x'e göre sıralanmalı vice versa
            //Debug.Log("x = " + x + " " + "y = " + y);
        }
    }

    void GenerateCircle()
    {
        Circle(R, 1, 1);
        Circle(R, 1, -1);
        Circle(R, -1, -1);
        Circle(R, -1, 1);
    }

    void UpdateCircle()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            GenerateCircle();
            Debug.Log("circle");
            R++;
            time = period;
            //bir önceki halka silip, yeni halkanın içine fill denebilir.
        }
    }

}
