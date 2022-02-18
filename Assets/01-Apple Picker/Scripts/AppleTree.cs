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
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement 
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
    }
}
