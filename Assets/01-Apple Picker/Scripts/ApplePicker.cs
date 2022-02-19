using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacing = 2f;
   
    void Start()
    {
    for (int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketBottomY * i);
            tBasketGo.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
