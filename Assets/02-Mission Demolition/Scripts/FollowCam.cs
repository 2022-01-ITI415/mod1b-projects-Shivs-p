using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public FollowCam S; // a FollowCam Singleton 

    // fields set in the Unity Inspector pane
    public float easing = 0.05f;
    public Vector2 minXY;
    public bool ______________________;

    // fields set dynamically
    public GameObject poi; // The point of interest
    public float camZ; // The desired z pos of the camera

    void Awake()
    {
        S = this;
        camZ = this.transform.position.z; 
    }
    void FixedUpdate()
    {
        // if there's only one line following an if, it doesn't need braces
        if (poi == null) return; //return if there is no poi 

        // Get the position of the poi 
        Vector3 destination = poi.transform.position;
        // Limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        // Interpolate from the current Camera postion toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        // Retain a destination.z of camZ
        destination.z = camZ;
        // Set the camera to the destination
        transform.position = destination;
        // Set the orthographicSize of the Camera to keep Ground in view 
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;
    }
}
