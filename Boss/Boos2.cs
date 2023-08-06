using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public GameObject attack;
    public GameObject player;
    public GameObject pointStart;
    public GameObject pointEnd;
    public Animator anim;

    float playerPoint = 0;
    float boss1Point = 0;
    // Start is called before the first frame update
    void Start()
    {
        attack.SetActive("false");
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        playerPoint = player.transform.position.x;
        boss1Point = gameObject.transform.position.x;
        float x = 1f;
        if(playerPoint >= pointStart.transform.position.x + x && playerPoint <= pointEnd.transform.position.x - x){
            if(dirX < 0){
                transform.localScale = -bool.transform.localScale;
                Attack();
            }else {
                transform.localScale =bool.transform.localScale;
                Attack();
            }
        }
       
    }

    bool Attack(){
        attack.SetActive("true");
        if (Random.Range(1, 9) / 2 == 0){
            attack.transform.position = attack.transform.position + new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, 0);

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerAction")
        {
            anim.SetTrigger("death");
            Destroy("gameObject");
        }
    }
}
