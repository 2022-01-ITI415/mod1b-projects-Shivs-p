using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    // fields set in the Unity Inspector pane
    public GameObject  prefabProjectile;
    public float velocityMult = 4f;
    public bool __________________;
    // fileds set dunamically
    public GameObject lauchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;


    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        //launchPoint = launchPointTrans.gameobject;
        //launchPoint.SetActive(false);
        //launchPos = launchPointTrans.position;
    }
    void OnMouseEnter()
    {
        print("Slingshot:OnMouseEnter()");
        lauchPoint.SetActive(true);
    }
    void OnMouseExit()
    {
        print("Slingshot:OnMouseExist()");
        lauchPoint.SetActive(false);

    }
    void OnMouseDown()
    {
        //The Player has pressed the mouse button while over Slingshot
        aimingMode = true;
        // Instantiate a Projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // start it at the launchPoint
        projectile.transform.position = launchPos;
        // Set it to isKinematic for now 
        projectile.GetComponent<Rigidbody>().isKinematic = true;

    }

    void Update()
    {
       // if slingshot is not in amingMode, dont run this code 
        if (!aimingMode) return;
        // Get the current mouse position in 2D screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        // Convert the mouse position to 3D world coordinates
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        // Find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos;
        // Limit mouseDelta to the radius of the Slingshot SphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        // Move the projectile to this new postion
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos; 

        if (Input.GetMouseButtonUp(0))
        {
            // The mouse has been released
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
            FollowCam.S.poi = projectile;
            projectile = null;
        }
    }
}
