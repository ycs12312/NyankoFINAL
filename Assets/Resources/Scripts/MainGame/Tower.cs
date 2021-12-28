using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour, IDamage
{
    public static float HP;
    public Text TowerHp;
    public float MAXHP;
    // public GameObject TowerHpPrefab;

    Animator Anim;

    Vector3 pos; //현재위치
    float delta = 0.02f; // 좌(우)로 이동가능한 (x)최대값
    float speed = 100.0f; // 이동속도

    bool hit = false;

    public GameObject laser;
    public GameObject laserrender;
    public AudioClip clip;

    private void Awake()
    {
        laser = Resources.Load("Prefabs/Laser") as GameObject;
        laserrender = Resources.Load("Prefabs/LineRENDER") as GameObject;

        pos = transform.position;
        //TowerHpPrefab = Resources.Load("Prefabs/TowerCanvas") as GameObject;
        HP = 500.0f;
        MAXHP = HP;
        //TowerHp = GetComponent<Text>();
    }


    private void Start()
    {
        Anim = transform.GetComponent<Animator>();
        // GameObject Dieee = Instantiate(TowerHpPrefab, transform.position, Quaternion.identity, transform) as GameObject;
        TowerHp = GameObject.Find("TowerHp").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        TowerHp.text = "HP : " + HP.ToString() + " / " + MAXHP;


        if (gameObject.name == "Tower")
        {
            if (HP <= 0)
            {
                DataManager.GetInstance().Die = true;
                Time.timeScale = 0f;
            }
        }

        if (hit)
        {
            Vector3 v = pos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
            StartCoroutine(HIT());
        }

    }

    private IEnumerator HIT()
    {
        yield return new WaitForSeconds(0.5f);
        hit = false;
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1.0f);
        DataManager.GetInstance().Die = true;
    }

    public void Damage(float damage)
    {
        HP -= damage;
        hit = true;
    }


    public void TowerButton()
    {
        Debug.Log("레이저");

        SoundManager.instance.SFXPlay("Attack", clip);

        Anim.SetTrigger("ATK");

        StartCoroutine(COL());


    }

    private IEnumerator COL()
    {
        GameObject Obj1 = Instantiate(laserrender);

        yield return new WaitForSeconds(0.5f);


        for (int i = 0; i < 6; i++)
        {
            GameObject Obj2 = Instantiate(laser);
            Obj2.transform.position = new Vector3(5.5f - i, 0.04f, -0.3f);
            yield return new WaitForSeconds(0.2f);

        }


    }

}

//https://darkcatgame.tistory.com/92