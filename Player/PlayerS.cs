using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerS : MonoBehaviour
{
    public GameObject actack;
    public GameObject bool;
    public Animator anim;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    private enum MovementState { idle, running, jumping, falling }

    public LayerMask jumpableGround;
    private float dirX = 0f;
    public float moveSpeed = 3f;
    public float jumpForce = 3f;

    //HP
    public int maxHealth = 200;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        //HP
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        Move();
        RotationPlayer();
        Attack();
    }

    void RotationPlayer(){
        Quaternion rotation = Quaternion.AngleAxis(0,Vector3.forward);
        transform.rotation = rotation;
    }

    int TakeDamege(int damege)
    {
        currentHealth -= damege;
        healthBar.SetHealth(currentHealth);
        return currentHealth;
    }

    private void Attack(){
        if(Input.GetKeyDown(KeyCode.A)){
            actack.SetActive(true);
            actack.transform.position = actack.transform.position + new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, 0);
                
        }
    }
    private void Move()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            bool.transform.localScale = bool.transform.localScale;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            transform.localScale = -bool.transform.localScale;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag=="Trap"){
            bool.SetActive(false);
        }
    }

 void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            gameObject.transform.SetParent("null");
            if (TakeDamege(2) <= 0)
            {
                RestartLevel();
            }
            TakeDamege(4);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            bool.transform.position = bool.transform.position + new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, 0);
            bool.SetActive(true);
            if (Random.Range(1, 9) / 2 == 0)
            {
                if (TakeDamege(2) <= 0)
                {
                    RestartLevel();
                }
                TakeDamege(2);
            }
            
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wind")
        {
           NextChap();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void NextChap(){
        SceneManager.LoadScene(NextScene); 
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
