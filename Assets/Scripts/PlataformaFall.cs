using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFall : MonoBehaviour
{
    public float fallDelay = 2f;
    private Rigidbody2D rb2D;
    private PolygonCollider2D pc2D;
    public float respawnDelay = 5f;
    private Vector3 start;
   

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<PolygonCollider2D>();
        start = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", respawnDelay);
        }

        
    }
    void Fall()
    {
        rb2D.isKinematic = false;
        pc2D.isTrigger = true;
        
    }

    void Respawn ()
    {
        rb2D.isKinematic = true;
        rb2D.velocity = Vector3.zero;
        pc2D.isTrigger = false;
        transform.position = start; 

    }
}
