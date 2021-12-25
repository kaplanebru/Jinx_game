using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShuriken : MonoBehaviour
{
    public Rigidbody2D takeShuri;
    public float countDown = 3;
    //float time = 1;
    Vector2 screenBounds;
    float doorHeight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(SpawnShuri());
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnShuri();
    }

    IEnumerator SpawnShuri()
    {
        while(true)
        {
            var randomPos = new Vector2(Random.Range(screenBounds.x - 1, -screenBounds.x + 1), Random.Range(screenBounds.y -1, - screenBounds.y +1 + doorHeight));
            Physics2D.gravity = Vector2.zero;
            Rigidbody2D clone;
            clone = Instantiate(takeShuri, randomPos, transform.rotation);
            yield return new WaitForSeconds(countDown);
        }
    }

    /*void SpawnShuri()
    {
        //var time = countDown;
        time -= Time.deltaTime;
        if (time < 0)
        {
            var randomPos = new Vector2(Random.Range(screenBounds.x - 1, -screenBounds.x + 1), Random.Range(screenBounds.y -1, - screenBounds.y +1 + doorHeight));
            Physics2D.gravity = Vector2.zero;
            Rigidbody2D clone;
            clone = Instantiate(takeShuri, randomPos, transform.rotation);
            time = countDown;
        }
    }*/
}
