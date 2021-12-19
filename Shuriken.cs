using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    float objectHeight;
    float objectWidth;

    // Update is called once per frame
    void Start()
    {
        //objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x /2;
        //objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y /2;
    }
    void Update()
    {
        //Debug.Log(objectWidth);
        //Debug.Log(objectHeight);
        Bounds();
    }

    void OnCollisionEnter2D(Collision2D targetObj)
    {
        if (targetObj.gameObject.tag == "enemy")
        {
        Destroy(gameObject);
        }
    }

    void Bounds ()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        
        if (transform.position.x > screenBounds.x
         || transform.position.x < -screenBounds.x
         || transform.position.y > screenBounds.y
         || transform.position.y < -screenBounds.y)
         
         Destroy(gameObject);
    }
}
