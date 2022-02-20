using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start()
    {
        // Find a reference to the HighScore 
        GameObject scoreGO = GameObject.Find("HighScore");

        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();

        // Set the starting number of points to zero 
        scoreGT.text = "0";

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

        // Parse the Text of the scoreGT into an int 
        int score = int.Parse(scoreGT.text);
        // Add points for catching the apple 
        score += 100;
        // Convert the score back to a string and display it 
        scoreGT.text = score.ToString();

        // Track the high score 
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
