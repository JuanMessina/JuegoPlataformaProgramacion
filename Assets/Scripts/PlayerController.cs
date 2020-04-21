using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float maxSpeed = 10f;
    private Rigidbody2D rb2D;
    private Animator anim;
    public bool grounded;
    public float jumpPower = 6.5f;
    bool jump;
    bool dobleSalto;
    public Transform scale;
    public int vida = 50;
    public GameObject deathEffect;





    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("Grounded", grounded);
        if (grounded)
        {
            dobleSalto = true;
        }

        if (Input.GetButtonDown("Jump"))
        {

            if (grounded)
            {

                jump = true;
                dobleSalto = true;
            }
            else if (dobleSalto)
            {
                jump = true;
                dobleSalto = false;
            }
        }


    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2D.velocity;
        fixedVelocity.x *= 0.75f;
        if (grounded)
        {
            rb2D.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");

        rb2D.AddForce(Vector2.right * speed * h);

        float limitedspeed = Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed);
        rb2D.velocity = new Vector2(limitedspeed, rb2D.velocity.y);


        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }

        if (jump == true)
        {


            rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;



        }
    }

        void OnBecameInvisible()
        {
            transform.position = new Vector3(1f, 1f, 1f);
        }

        public void EnemyJump()
        {

            jump = true;
        }

        public void EnemyKnockBack(float enemyPosX)
        {
            jump = true;
            float side = Mathf.Sign(enemyPosX - transform.position.x);
            rb2D.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
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

