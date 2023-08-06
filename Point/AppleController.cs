using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AppleController : MonoBehaviour
{
    public TMP_Text scoreText;
    private int apple = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            apple++;
            Debug.Log("Score: " + apple);
            scoreText.text = "Score: " + apple;
        }
    }
}
