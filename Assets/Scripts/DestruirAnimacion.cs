using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirAnimacion : MonoBehaviour
{
    public float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestruirAnimacionCorrutina());
    }

    IEnumerator DestruirAnimacionCorrutina()
    {
        yield return new WaitForSeconds(tiempo);
        Destroy(gameObject);
        yield break;

    }
}
