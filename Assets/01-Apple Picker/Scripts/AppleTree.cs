using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Prefab for instantiating apples 
    public GameObject appleprefab;

    // Speed at which the AppleTree moves in meters/secs
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will Change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate at which Apples will be instantiated
    public float secondBetweenAppleDrops = 1f;

    void Start()
    {
        // Dropping apples every second 
        Invoke( "DropApple", 2f );
    }
    void DropApple()
    {
       GameObject apple = Instantiate( appleprefab ) as GameObject;

       apple.transform.position = transform.position;

       Invoke( "DropApple", secondBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement 
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move right 
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move left
        }
    }
    void FixedUpdate()
    {
        // Changing Direction Randomly 
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //chnage direction 
        }
    }
}