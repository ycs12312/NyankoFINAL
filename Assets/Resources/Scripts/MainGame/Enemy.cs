using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitInfo;

public class Enemy : MonoBehaviour, IDamage
{
    public GameObject bullet = null;
    private GameObject closeEnemy = null;

    public List<GameObject> collEnemy = new List<GameObject>();
    private float fTime = 0;

    protected GameObject attackTarget;
    public Animator Anim;
    private Rigidbody2D Rigid;
    private bool Stop;

    public float HP = 0.0f;
    public float ATK = 0.0f;
    public float SPEED = 0.0f;
    public int GOLD = 0;

    private float time;
    private float spring;
    private bool diee;
    public GameObject dieee;
    public GameObject boom;

    public AudioClip clip;
  
    public AudioClip Dieclip;

    Doge doge = new Doge();
    Snake snake = new Snake();
    Marksman marksman = new Marksman();
    Bear bear = new Bear();
  

    private void Awake()
    {
        dieee = Resources.Load("Prefabs/Die") as GameObject;
        boom = Resources.Load("Prefabs/Boom") as GameObject;

        if (gameObject.name.Contains("Doge"))
        {
            HP = doge.HP;
            ATK = doge.ATK;
            SPEED = doge.SPEED;
            GOLD = doge.GOLD;
        }

        if (gameObject.name.Contains("Snake"))
        {
            HP = snake.HP;
            ATK = snake.ATK;
            SPEED = snake.SPEED;
            GOLD = snake.GOLD;
        }

        if (gameObject.name.Contains("Marksman"))
        {
            HP = marksman.HP;
            ATK = marksman.ATK;
            SPEED = marksman.SPEED;
            GOLD = marksman.GOLD;
        }

        /*
        if (gameObject.name.Contains("Bear"))
        {
            HP = bear.HP;
            ATK = bear.ATK;
            SPEED = bear.SPEED;
            GOLD = bear.GOLD;
        }
        */
    }

 

    void Start()
    {
        spring = 0.3f;
        Anim = transform.GetComponent<Animator>();
        Stop = false;
        diee = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (!Stop)
        {
            this.transform.position += Vector3.right * 0.6f * Time.deltaTime;
        }

        if (HP <= 0)
        {
            KnockBack();

            time += Time.deltaTime;
            Stop = true;
            Anim.SetTrigger("HIT");
            StartCoroutine(Die());

        }

        AnimationUpdate();

        fTime += Time.deltaTime;
        if (collEnemy.Count > 0)
        {

            GameObject target = collEnemy[0];

            //if (gameObject.tag == "Enemy")

            if (gameObject.name.Contains("Bear"))
            {
                if (target != null && fTime > 3.57f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");
                    Collider2D[] hitsCol = Physics2D.OverlapCircleAll(transform.position, 1.5f);

                    foreach (Collider2D hit in hitsCol)
                    {
                        Debug.Log(hitsCol);
                        if (hit.gameObject.tag == "Player")
                        {
                            IDamage damage = hit.GetComponent<IDamage>();
                            if (damage != null) { damage.Damage(ATK); }
                            AttackEffect();
                            GameObject Boom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
                            Boom.transform.position = new Vector3(target.transform.position.x - 0.2f, target.transform.position.y, target.transform.position.z - 1.0f);
                        }
                    }


                }
            }


            if (gameObject.name.Contains("Doge"))
            {
                if (target != null && fTime > 1.57f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");
                    IDamage damage = target.GetComponent<IDamage>();
                    if (damage != null) { damage.Damage(ATK); }

                    AttackEffect();
                    GameObject Boom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
                    Boom.transform.position = new Vector3(target.transform.position.x - 0.2f, target.transform.position.y, target.transform.position.z - 1.0f);
                    Debug.Log(target.gameObject + "개 공격");

                }
            }

            if (gameObject.name.Contains("Snake"))
            {
                if (target != null && fTime > 2.13f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");
                    IDamage damage = target.GetComponent<IDamage>();
                    if (damage != null) { damage.Damage(ATK); }

                    AttackEffect();
                    GameObject Boom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
                    Boom.transform.position = new Vector3(target.transform.position.x - 0.2f, target.transform.position.y, target.transform.position.z - 1.0f);
                    Debug.Log(target.gameObject + "뱀 공격");

                }
            }

            if (gameObject.name.Contains("Marksman"))
            {
                if (target != null && fTime > 4.0f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");

                    var aBullet = Instantiate(bullet, transform.position, Quaternion.identity);

                    Vector3 TargetDirection = (target.transform.position - transform.position).normalized;
                    aBullet.GetComponent<Bullet>().targetPosition = TargetDirection;
                    AttackEffect();
                    Debug.Log(target.gameObject + "궁수 공격");
                }
            }

           
        }

       
    }


    private void AnimationUpdate()
    {
        if (Stop)
        {
            Anim.SetBool("RUN", false);
        }
        else if (!Stop)
        {
            Anim.SetBool("RUN", true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("적 충돌");
            Stop = true;
            
            collEnemy.Add(collision.gameObject);
        }


        if (collision.gameObject.tag == "Laser")
        {
            Debug.Log("레이저 충돌");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("계속 적 충돌");
            Stop = true;

        }
    }
   
        private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject go in collEnemy)
        {
            if (go == collision.gameObject)
            {
                collEnemy.Remove(go);
                Stop = false;
                break;
            }
        }
    }

    private void AttackEffect()
    {
        SoundManager.instance.SFXPlay("Attack", clip);
   
    }

    private IEnumerator ATTACK1()
    {
        yield return new WaitForSeconds(0.7f);

        SoundManager.instance.SFXPlay("Attack", clip);
        Collider2D[] hitsCol = Physics2D.OverlapCircleAll(transform.position, 2.0f);

        foreach (Collider2D hit in hitsCol)
        {
            Debug.Log(hitsCol);
            if (hit.gameObject.tag == "Player")
            {
                IDamage damage = hit.GetComponent<IDamage>();
                if (damage != null) { damage.Damage(ATK); }

                GameObject Boom = Instantiate(boom, hit.transform.position, Quaternion.identity) as GameObject;
                Boom.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z - 1.0f);
            }
        }
    }

    public void Damage(float damage)
    {
        HP -= damage;
    }

    void KnockBack()
    {
        if (time < 0.4f)
        {
            transform.localEulerAngles = new Vector3(0, 0, 35);
            this.transform.position += Vector3.up * spring * 5.0f * Time.deltaTime;
            this.transform.position += Vector3.left * spring * 3.0f * Time.deltaTime;
        }
        else if (time < 0.8f)
        {
            this.transform.position += Vector3.down * spring * 5.0f * Time.deltaTime;
        }
        else
        {
            if (!diee)
            {
                SoundManager.instance.SFXPlay("Die", Dieclip);
                GameObject Dieee = Instantiate(dieee, transform.position, Quaternion.identity) as GameObject;
                dieee.transform.position = transform.position;

                diee = true;
            }
            //transform.localEulerAngles = new Vector3(0, 0, 0);
            spring = 0;
        }
    }


    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1.0f);

        if (gameObject.name.Contains("Doge"))
        {
            DataManager.GetInstance().money += GOLD;
        }

        if (gameObject.name.Contains("Snake"))
        {
            DataManager.GetInstance().money += GOLD;
        }

        if (gameObject.name.Contains("Marksman"))
        {
            DataManager.GetInstance().money += GOLD;
        }

        if (gameObject.name.Contains("Bear"))
        {
            DataManager.GetInstance().money += GOLD;
        }


        Destroy(gameObject);
        diee = false;
    }
}

/*
      if (DataManager.GetInstance().money >= 40)
      {
          button1.enabled = true;
      }
      else if (DataManager.GetInstance().money < 40)
      {
          button1.enabled = false;
      }


      if (DataManager.GetInstance().money >= 100)
      {
          button2.enabled = true;
      }
      else if (DataManager.GetInstance().money < 100)
      {
          button2.enabled = false;
      }
      https://icechou.tistory.com/180
      */
