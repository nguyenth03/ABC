using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plagrom_Player : MonoBehaviour
{
    bool state = false;
    GameObject bb = null;


    void Update()
    {
       
        if (state == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                state = false;
              bb.transform.SetParent(null);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")// same name object
        {
            collision.gameObject.transform.SetParent(transform);
            state = true;
            bb = collision.gameObject;
        }
    }



}
