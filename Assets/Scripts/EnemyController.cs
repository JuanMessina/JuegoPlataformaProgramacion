using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 1f;
    private Rigidbody2D rb2D;
    public int vida = 20;
    public GameObject deathEffect;
    public PlayerController player;






    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        rb2D = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.AddForce(Vector2.right * speed);
        float limitedspeed = Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed);
        rb2D.velocity = new Vector2(limitedspeed, rb2D.velocity.y);

        if (rb2D.velocity.x > -0.01f && rb2D.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);

        }

        if (speed < 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        else if (speed > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

       
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            
            float yOffset = 0.5f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Die();



            }
           else { col.SendMessage("EnemyKnockBack"); }
          
        }
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;

        if (vida <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
