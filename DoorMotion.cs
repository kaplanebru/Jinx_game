using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    public Rigidbody2D doorPb;
    public float speed = 0.2f;
    Rigidbody2D[] doors = new Rigidbody2D[2];
    public float doorsDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        DoorSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        DoorDistance();
    }

   public void DoorDistance()
   {
        doorsDistance = doors[1].transform.position.x - doors[0].transform.position.x;
        //return doorsDistance;
       // diğer tarafta: if(doorDistance.transform.position.x == enemy)
   }

    void DoorSpawn()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var y = -screenBounds.y + 0.25f;
        Vector2 posDoor = new Vector2(0, y);
        //Vector2 posRight = new Vector2(0, y);

        Physics2D.gravity = Vector2.zero;

        for (int i = 0; i<2; i++)
        {
            doors[i] = Instantiate(doorPb);
            doors[i].transform.position = posDoor;
        }
        doors[1].transform.rotation = Quaternion.Euler(0f, 0f, -180);

        doors[0].velocity = transform.TransformDirection(new Vector2(-1, 0) * speed);
        doors[1].velocity = transform.TransformDirection(new Vector2(1, 0) * speed);

    }
    
}
