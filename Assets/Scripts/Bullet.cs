using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public int damage = 10;

    // Start is called before the first frame update

    

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyController enemy = col.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

        }

        if (col.gameObject.tag == "Platform")
        {
            Destroy(gameObject);

        }


    }

    void OnTriggerEnter2D(Collision2D col)
    {
       

    }
}
