using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitInfo;
using System.IO;

public class Cat : MonoBehaviour, IDamage
{
    public GameObject bullet = null;
    private GameObject closeEnemy = null;

    public List<GameObject> collEnemy = new List<GameObject>();
    private float fTime = 0;

    protected GameObject attackTarget;
    Animator Anim;
    //SpriteRenderer Sprite;
    private Rigidbody2D Rigid;
    private bool Stop;

    public float HP;
    public float ATK;
    public float SPEED ;
    public int LEVEL;

    private float time;
    private float spring;
    private bool diee;

    public GameObject dieee;
    public GameObject boom;
    public float i2;

    //UnitInfo unitInfo = new UnitInfo();


    public AudioClip clip;
    public AudioClip Dieclip;

    Cat1 cat1 = new Cat1();
    Cat2 cat2 = new Cat2();
    Cat3 cat3 = new Cat3();
    Cat4 cat4 = new Cat4();
    Cat5 cat5 = new Cat5();

    // public UnitInfo[] CATInfo;

    private void Awake()
    {
        dieee = Resources.Load("Prefabs/Die") as GameObject;
        boom = Resources.Load("Prefabs/Boom") as GameObject;


          /*
               string path = Application.dataPath + "playerData.Json";
               string json = File.ReadAllText(path);
               Cat1 cat1 = JsonUtility.FromJson<Cat1>(json);
           */





        if (gameObject.name.Contains("Cat1"))
        {

            LEVEL = PlayerPrefs.GetInt("cat1LEVEL");
            HP = PlayerPrefs.GetFloat("cat1HP");
            ATK = PlayerPrefs.GetFloat("cat1ATK");
            SPEED = PlayerPrefs.GetFloat("cat1SPEED");

        }

       
        if (gameObject.name.Contains("Cat2"))
        {
            LEVEL = PlayerPrefs.GetInt("cat2LEVEL");
            HP = PlayerPrefs.GetFloat("cat2HP");
            ATK = PlayerPrefs.GetFloat("cat2ATK");
            SPEED = PlayerPrefs.GetFloat("cat2SPEED");
        }

        if (gameObject.name.Contains("Cat3"))
        {
            HP = cat3.HP;
            ATK = cat3.ATK;
            SPEED = cat3.SPEED;
        }

        if (gameObject.name.Contains("Cat4"))
        {
            LEVEL = PlayerPrefs.GetInt("cat4LEVEL");
            HP = PlayerPrefs.GetFloat("cat4HP");
            ATK = PlayerPrefs.GetFloat("cat4ATK");
            SPEED = PlayerPrefs.GetFloat("cat4SPEED");
        }

        if (gameObject.name.Contains("Cat5"))
        {
            HP = cat5.HP;
            ATK = cat5.ATK;
            SPEED = cat5.SPEED;
        }
    }

    void Start()
    {
        spring = 0.3f;
        Anim = transform.GetComponent<Animator>();
        //Sprite = GetComponent<SpriteRenderer>();
        Stop = false;
        diee = false;
        //Sprite.flipX = true;
    }


    void Update()
    {

        if (!Stop)
        {
            this.transform.position += Vector3.left * SPEED * Time.deltaTime;
        }


        if(HP<=0)
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

            if (gameObject.name.Contains("Cat1"))
            {
                if (target != null && fTime > 1.57f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");
                    IDamage damage = target.GetComponent<IDamage>();
                    if (damage != null) { damage.Damage(ATK); }

                    AttackEffect();
                    GameObject Boom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
                    Boom.transform.position = new Vector3(target.transform.position.x + 0.3f, target.transform.position.y, target.transform.position.z - 1.0f);
                    //GameObject Boom = Instantiate(boom, target.transform.position, Quaternion.identity) as GameObject;
                    // Boom.transform.position = target.transform.position;

                    Debug.Log(target.gameObject + "적 공격");

                }
            }


            if (gameObject.name.Contains("Cat2"))
            {
                if (target != null && fTime > 1.57f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");
                    IDamage damage = target.GetComponent<IDamage>();
                    if (damage != null) { damage.Damage(ATK); }

                    AttackEffect();
                    GameObject Boom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
                    Boom.transform.position = new Vector3(target.transform.position.x + 0.3f, target.transform.position.y, target.transform.position.z - 1.0f);
                    //GameObject Boom = Instantiate(boom, target.transform.position, Quaternion.identity) as GameObject;
                    //Boom.transform.position = target.transform.position;

                    Debug.Log(target.gameObject + "적 공격");

                }
            }

            if (gameObject.name.Contains("Cat3"))
            {
                if (target != null && fTime > 4.0f)
                {
                    Anim.SetBool("RUN", false);

                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");


                    var aBullet = Instantiate(bullet, transform.position, Quaternion.identity);

                    Vector3 TargetDirection = (target.transform.position - transform.position).normalized;
                    aBullet.GetComponent<PlayerBullet>().targetPosition = TargetDirection;
                    SoundManager.instance.SFXPlay("Attack", clip);
                    Debug.Log(target.gameObject + "궁수 공격");
                    AttackEffect();

                }
            }

            if (gameObject.name.Contains("Cat4"))
            {
                if (target != null && fTime > 2.0f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");

                    StartCoroutine(ATTACK1());
                 
                  
                }
            }

            if (gameObject.name.Contains("Cat5"))
            {
                if (target != null && fTime > 3.57f)
                {
                    fTime = 0.0f;
                    Anim.SetTrigger("ATK");

                    StartCoroutine(ATTACK2());
                    

                }
            }


        }

    }

    private void AnimationUpdate()
    {
        if (Stop)
        {
            Anim.SetBool("RUN", false);
            //Anim.ResetTrigger("RUN");
        }
        else if (!Stop)
        {
            Anim.SetBool("RUN", true);
            //Anim.SetTrigger("RUN");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("트리거됨");
            Stop = true;
            //Anim.SetTrigger("IDLE");
            collEnemy.Add(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("총알 충돌");
        }


    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("계속 트리거됨");
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



    public void Damage(float damage)
    {
        HP -= damage;
    }

    private void KnockBack()
    {
        if (time < 0.4f)
        {
            transform.localEulerAngles = new Vector3(0, 0, -35);
            this.transform.position += Vector3.up * spring * 5.0f * Time.deltaTime;
            this.transform.position += Vector3.right * spring * 3.0f * Time.deltaTime;
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

    private void AttackEffect()
    {
        SoundManager.instance.SFXPlay("Attack", clip);
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
        diee = false;
    }

    private IEnumerator ATTACK1()
    {
        yield return new WaitForSeconds(0.7f);

        SoundManager.instance.SFXPlay("Attack",clip);
        Collider2D[] hitsCol = Physics2D.OverlapCircleAll(transform.position, 1.5f);

        foreach (Collider2D hit in hitsCol)
        {
            Debug.Log(hitsCol);
            if (hit.gameObject.tag == "Enemy")
            {
                IDamage damage = hit.GetComponent<IDamage>();
                if (damage != null) { damage.Damage(ATK); }

                GameObject Boom = Instantiate(boom, hit.transform.position, Quaternion.identity) as GameObject;

                Boom.transform.position = new Vector3(hit.transform.position.x + 0.3f, hit.transform.position.y, hit.transform.position.z - 1.0f);
            }
        }
    }

    private IEnumerator ATTACK2()
    {
        yield return new WaitForSeconds(1.0f);

        SoundManager.instance.SFXPlay("Attack", clip);
        Collider2D[] hitsCol = Physics2D.OverlapCircleAll(transform.position, 2.0f);

        foreach (Collider2D hit in hitsCol)
        {
            Debug.Log(hitsCol);
            if (hit.gameObject.tag == "Enemy")
            {
                IDamage damage = hit.GetComponent<IDamage>();
                if (damage != null) { damage.Damage(ATK); }

                GameObject Boom = Instantiate(boom, hit.transform.position, Quaternion.identity) as GameObject;
                Boom.transform.position = new Vector3(hit.transform.position.x + 0.3f, hit.transform.position.y, hit.transform.position.z - 1.0f);
            }
        }
    }


    /*
    **스프라이트 드라이브
    * https://drive.google.com/drive/folders/19R_E6G9uYfNfm4BDl687Dm7qvFWWesKp
    * https://drive.google.com/drive/folders/1KAU5PmXqnXVhIRThQSPnsvwI5PksAR5T
    https://drive.google.com/u/0/uc?id=1IwRe8yVC5SLPg_LcWyiAk1Ae0_I3Am4q&export=download
    https://www.youtube.com/watch?v=dd9ALQYYfn4

    */
}



