using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public GameObject player;
    public GameObject pointStart;
    public GameObject pointEnd;
    public Animator anim;

    float playerPoint = 0;
    float boss1Point = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerPoint = player.transform.position.x;
        boss1Point = gameObject.transform.position.x;
        float x = 1f;
        if(playerPoint >= pointStart.transform.position.x + x && playerPoint <= pointEnd.transform.position.x - x){
            if(playerPoint - boss1Point <= 1f){
                Attack(true);
            }else if(boss1Point - playerPoint <= 1f){
                Attack(false);
            }
        }else{
            Restart();
        }
       
    }

    bool Attack(bool x){
        float speed = time.deltaTime;
        if(gameObject.transform.position.y >= player.transform.position.y){
                if(true){
                    gameObject.transform.position = gameObject.transform.position + new Vector3(speed, -speed, 0);
                }else{
                    gameObject.transform.position = gameObject.transform.position + new Vector3(-speed, speed, 0);
                }
        }
    }

    void Restart(){
        if(gameObject.transform.position.y != pointStart.transform.position.y){
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, time.deltaTime, 0);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerAction")
        {
            Destroy("gameObject");
        }
    }
    //Drag trap
}
