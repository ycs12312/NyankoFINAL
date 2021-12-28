using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public GameObject bullet = null;
    private GameObject closeEnemy = null;

    public List<GameObject> collEnemy = new List<GameObject>();
    private float fTime = 0;

    protected GameObject attackTarget;
    public Animator Anim;
    public float HP = 10.0f;
    public float ATK = 10.0f;

    void Start()
    {
        Anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fTime += Time.deltaTime;
        if (collEnemy.Count > 0)
        {

            GameObject target = collEnemy[0];
            if (gameObject.tag == "Enemy")
            {
                if (target != null && fTime > 3.0f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");

                    IDamage damage = target.GetComponent<IDamage>();
                    if (damage != null) { damage.Damage(ATK); }

                    Debug.Log(target.gameObject + "공격중");

                }
            }
        }
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("적 충돌");
            collEnemy.Add(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("총알 충돌");
            HP -= 5.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject go in collEnemy)
        {
            if (go == collision.gameObject)
            {
                collEnemy.Remove(go);
                break;
            }
        }
    }
}
