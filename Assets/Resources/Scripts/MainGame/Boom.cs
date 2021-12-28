using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(Dieee());
    }

    private IEnumerator Dieee()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

