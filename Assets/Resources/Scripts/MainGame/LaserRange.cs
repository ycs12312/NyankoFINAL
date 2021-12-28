using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRange : MonoBehaviour
{
    Vector3 pos; 
    float delta = 0.07f; 
    float speed = 40.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
      
    }
}
