using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    void Update()
    {
       
        transform.Translate(Vector3.up * Time.deltaTime * 1.1f);

        StartCoroutine(Dieee());
    }

    private IEnumerator Dieee()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
