using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    //float doorHeight = 0.5f;
    Vector2 screenBounds;
    //float openClamp = -3;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    private void LateUpdate() 
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        var objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x /2;
        var objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y /2;
        //öncesinde transform.localScale.y/2 kullandım.


        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        pos.y = Mathf.Clamp(pos.y, screenBounds.y * -1 /*+ doorHeight*/ + objectHeight, screenBounds.y - objectHeight);
        transform.position = pos;
    }
}
