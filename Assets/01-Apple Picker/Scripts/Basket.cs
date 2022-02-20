using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousepos2D = Input.mousePosition;

        //The Camera's Z screen postion sets the how far to push the mouse into 3D
        mousepos2D.z = -Camera.main.transform.position.z;

        // Convet the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousepos2D );

        //Move x position of this Basket to the x position of the Mouse 
        Vector3  pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OncollisionEnter( Collision coll )
    {
        //Find out what hit this basket
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple" )
        {
            Destroy(collideWith);
        }
    }
}
