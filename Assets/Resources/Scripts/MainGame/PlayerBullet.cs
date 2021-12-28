using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]

public class PlayerBullet : MonoBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public GameObject ExplosionParticle = null;
    private float ATK = 220.0f;
    private Enemy enemy;

    private GameObject closeEnemy = null;

    public List<GameObject> collEnemy = new List<GameObject>();
    private float fTime = 0;

    protected GameObject attackTarget;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * 3.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IDamage damage = collision.GetComponent<IDamage>();
            if (damage != null) { damage.Damage(ATK); }
            StartCoroutine(Die());
        }

    }


    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}




