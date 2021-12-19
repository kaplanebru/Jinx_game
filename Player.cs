using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    
    public float moveSpeed = 10f;
    float smoothTime = 0.3f;
    public float offset = 4f;
    public Rigidbody2D projectile;
    Vector2 currentVelocity;
    public Transform target;
    public float bulletSpeed = 20;
    int takenShuri = 0;
    float doorHeight = 0.5f;


    void Update()
    {
        Move();
        //LookAtTarget();
        Projectile();
    }
    void LateUpdate()
    {
        Boundaries();
    }

    void Move()
    {   
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = ((Vector2)transform.position - mousePos).normalized;
        mousePos += mouseDirection * offset;

        transform.position = Vector2.SmoothDamp(transform.position, 
        mousePos, ref currentVelocity, smoothTime, moveSpeed); 
    }

    void LookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
            dir.Normalize();
            float angle_z = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle_z - 90);
    }

    void OnTriggerEnter2D(Collider2D targetObj)
    {
        if(targetObj.gameObject.tag == "collectible")
        {
            takenShuri += 1;
            //Debug.Log(takenShuri);
            Destroy(targetObj.gameObject);
        }
    }

    void Projectile()
    {
        //int takenShuri = shuri.nums.Count;
        if (Input.GetButtonDown("Fire1"))
        {
            if(takenShuri > 0)
            {
                LookAtTarget(); 

                Rigidbody2D clone;
                Physics2D.gravity = Vector2.zero;
                clone = Instantiate(projectile, transform.position, transform.rotation);
                clone.velocity = transform.TransformDirection(new Vector2(0, 1) * bulletSpeed);

                takenShuri--;
            }
            else{
                Debug.Log("not enough shiruken");
            }
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



}
