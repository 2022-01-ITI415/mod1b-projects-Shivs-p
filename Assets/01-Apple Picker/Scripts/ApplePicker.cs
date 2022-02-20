using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]  
    public GameObject     basketPrefab;
    public int            numBaskets = 3;
    public float          basketBottomY = -14f;
    public float          basketSpacingY = 2f;
    //public List<GameObejct> basketList;

    void Start()
    {
        //basketList = new List<GameObejct>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            //basketList.Add(tBasketGo);
        }
    }

    public void AppleDestroyed()
      {
            // Destroy  all of the falling Apples
            GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach ( GameObject tGo in tAppleArray)
            {
                Destroy(tGo);
            }

            // Destroy one of the Baskets
            // Get the index of the last Basket in basketList
           // int basketIndex = basketList.Count - 1;

            // Get a reference to that Basket GameObject
            //GameObject tBasketGo = basketList[basketIndex];

            // Remove the Basket from the List and destroy the GameObject
            //basketList.RemoveAt(basketIndex);
            //Destroy(tBasketGo);

            // Restart the game, which doesn't affect HighScore.score 
            //if (basketList.Count == 0)
        {
            SceneManager.LoadScene("00_Scene");
        }
      }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
