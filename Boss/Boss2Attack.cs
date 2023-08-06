using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    float dirX, speed,move;
    void Update(){
        speed = 0.001f
        dirX = Input.GetAxisRaw("Horizontal");
        if (dirX > 0f)
        {
            move = gameObject.transform.position.x + 3f;
            Move(dirX);
        }else{
            move = gameObject.transform.position.x - 3f;
            Move(dirX);
        }   
        Destroy(dirX);
    }


    void Move(float d){
        if(d > 0){
            while(gameObject.transform.position.x <= move){
                gameObject.transform.position = gameObject.transform.position + new Vector3(speed, 0, 0);
            }
            Destroy("gameObject");
        }else{
            while(gameObject.transform.position.x >= move){
                gameObject.transform.position = gameObject.transform.position + new Vector3(-speed, 0, 0);
            }
            Destroy("gameObject");
        }

    }

}