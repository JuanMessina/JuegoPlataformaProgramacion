using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float duration = 2;
    private Coroutine shootCoroutine;
    public GameObject bala;
    public float speed = 20f;


    // Update is called once per frame
    void Update()
    {
        if (shootCoroutine == null)
        {
           shootCoroutine = StartCoroutine (Shoot());
        }

       IEnumerator Shoot()
        {
            yield return new WaitForSeconds(duration);

            bala = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            if (transform.localScale.x == -1)
            {
                bala.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            }

            else if (transform.localScale.x == 1)
            {
                bala.GetComponent<Rigidbody2D>().velocity = transform.right * -1 * speed;
            }

            
           
            shootCoroutine = null;

            yield break;
        }
    }
}
