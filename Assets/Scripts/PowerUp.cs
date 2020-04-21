using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 2f;
    public float duration = 1f;
    public GameObject efecto;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(EfectoPowerUp(col));
        }
    }

    IEnumerator EfectoPowerUp (Collider2D player)
    {
        Instantiate(efecto, transform.position, transform.rotation);
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.speed *= multiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.speed /= multiplier;
        Destroy(gameObject);
    }
}
