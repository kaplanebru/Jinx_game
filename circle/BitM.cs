using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitM : MonoBehaviour
{
    //Canceled script
    public Rigidbody2D pxlPb;
    float x = 0f;
    float y = 0f;
    float unit = 0.085f;
    // Start is called before the first frame update
    void Start()
    {
        //SetPixel(x, y, color);
        
        Physics2D.gravity = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnPxl(x, y);

    }

    void SpawnPxl(float x, float y)
    {

            Rigidbody2D pxl = Instantiate(pxlPb, SpawnPos(x, y), transform.rotation);
            x = x + unit;
            y = y + unit;

        //var pxl2 = Instantiate(pxlPb, SpawnPos(x, y + unit), transform.rotation);
        //var pxl3 = Instantiate(pxlPb, SpawnPos(x + unit, y), transform.rotation);
    }

    Vector2 SpawnPos(float x, float y)
    {
        var pos = new Vector2(x, y);
        return pos;
    }
}
