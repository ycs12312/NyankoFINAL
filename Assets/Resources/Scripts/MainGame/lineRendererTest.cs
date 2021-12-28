using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRendererTest : MonoBehaviour
{
    private LineRenderer lineRenderer;
    float LaserRange = 5.99f;

    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, new Vector3(5.99f, 0.51f, -0.716f));
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, new Vector3(LaserRange, -1.5f, -0.716f));
        if (LaserRange > 0.1f)
        {
            LaserRange -= 15.0f * Time.deltaTime;
        }
        else
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}



