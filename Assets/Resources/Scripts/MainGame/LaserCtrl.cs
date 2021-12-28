using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class LaserCtrl : MonoBehaviour
{
    public float ATK = 100.0f;
    Animator Anim;
    public AudioClip clip;
    private void Start()
    {
        SoundManager.instance.SFXPlay("Attack", clip);
        Anim = transform.GetComponent<Animator>();
    }

    private void Update()
    {
        //this.transform.position += Vector3.left * 2.0f * Time.deltaTime;
        StartCoroutine(Die());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IDamage damage = collision.GetComponent<IDamage>();
            if (damage != null) { damage.Damage(ATK); }
        }

        if (collision.gameObject.tag == "LaserRange")
        {
            StartCoroutine(Die());
        }

    }


    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }


}
