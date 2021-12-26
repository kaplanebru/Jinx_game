using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public float scaleAmount = 20;
    public float timeLeft = 1f;
    //float timer = 1;
    int directionX = 1;
    int directionY = 1;
    float objectHeight;
    float objectWidth;
    float doorHeight = 0.5f;
    Rigidbody2D rb;
    Vector2 screenBounds;
    bool move = true;
    bool onScale = true;

    
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ScaleTime());
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        //Timer(scaleAmount);
        Disembark();
    }

    void LateUpdate()
    {
        Boundaries();
    }

    void MoveEnemy()
    {
        if(move == true)
        {    Vector2 pos = transform.position;
            pos.x += speed * directionX * Time.deltaTime;
            pos.y += speed * directionY * Time.deltaTime;
            transform.position = pos;
            
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x /2;
            objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y /2;
        
            var pos3 = transform.position;
            if (pos3.x >= screenBounds.x - objectWidth
            || pos3.x <= -screenBounds.x + objectWidth)
            {
                directionX = -directionX;
            }
            else if(pos3.y >= screenBounds.y - objectHeight
            || pos3.y <= -screenBounds.y + objectHeight + doorHeight)
            {
                directionY = -directionY;
                //speed += 0.1f;
                //directionX *= RandomDir();
                //Debug.Log(RandomDir());
            }
        }    
    }

    int RandomDir()
    {
        int i = Random.Range(0, 7);
        if (i == 1)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
               

    void ScaleEnemy(float i)
    {
        Vector2 scaleUp = transform.localScale;
        if (scaleUp.x < screenBounds.x || scaleUp.y < screenBounds.y)
        {
            if(onScale == true)
            {
                scaleUp.x += i * Time.deltaTime;
                scaleUp.y += i * Time.deltaTime;
                transform.localScale = scaleUp;
            }
        }
        else
        {
            move = false;
            onScale = false;
            //küçülme de false yapılacak + tüm ekran beyaz olacak.
        }
    }

    IEnumerator ScaleTime()
    {
        while(true)
        {
            ScaleEnemy(scaleAmount);
            yield return new WaitForSeconds(timeLeft);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D targetObj) 
    
    {
        if(targetObj.gameObject.tag == "bullet")
        {
            Vector2 scale = transform.localScale;
            scale.x -= 0.5f;
            scale.y -= 0.5f;
            transform.localScale = scale;

            if (scale.x < 1 && scale.y < 1)
            {
                scale.x = 1;
                scale.y = 1;

                transform.localScale = scale;
            }
        }
    }
    void Disembark()
    {
        var doorGap = GameObject.Find("DoorSpawner").GetComponent<DoorMotion>().doorsDistance;
        //Debug.Log(doorGap);
        if (doorGap >= transform.localScale.x)
        {
            directionY = -1;
            var pos = transform.position;
            pos.x = 0;//doorGap/2f;
            pos.y= -screenBounds.y; 
            //buraya move.towards, lerp ya da smooth.damp(playerdaki) gelecek
            transform.position = pos;
            onScale = false;
            //speed += 0.01f; //gravity hissi versin diye
        }
    }

    void Boundaries()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        var objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x /2;
        var objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y /2;
        //öncesinde transform.localScale.y/2 kullandım.

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        pos.y = Mathf.Clamp(pos.y, screenBounds.y * -1 + doorHeight + objectHeight, screenBounds.y - objectHeight);
        transform.position = pos;
    }



    /*void Timer(float i)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            ScaleEnemy(i);
            timer = timeLeft;
        }
    }*/
}
