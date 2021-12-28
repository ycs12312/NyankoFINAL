using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTower : MonoBehaviour, IDamage
{
    public static float HP;
    public Text TowerHp;
    public float MAXHP;
    // public GameObject TowerHpPrefab;

    Vector3 pos; //현재위치
    float delta = 0.02f; // 좌(우)로 이동가능한 (x)최대값
    float speed = 100.0f; // 이동속도

    bool hit = false;

    public int StageNum;

    private void Awake()
    {
        StageNum = PlayerPrefs.GetInt("level");
        if (StageNum == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/ETower1");
            HP = 500.0f;
            MAXHP = HP;
        }

        if (StageNum == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/ETower2");
            HP = 1000.0f;
            MAXHP = HP;

        }

        if (StageNum == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/ETower1");
            HP = 1500.0f;
            MAXHP = HP;
        }

    
        pos = transform.position;


        //TowerHpPrefab = Resources.Load("Prefabs/TowerCanvas") as GameObject;
     
        //TowerHp = GetComponent<Text>();
    }


    private void Start()
    {
        //GameObject Dieee = Instantiate(TowerHpPrefab, transform.position, Quaternion.identity, transform) as GameObject;
        TowerHp = GameObject.Find("EnemyTowerHp").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
     

        if (hit)
        {
            Vector3 v = pos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
            StartCoroutine(HIT());
        }

        if (gameObject.name == "EnemyTower")
        {
            if (HP <= 0)
            {
                DataManager.GetInstance().Win = true;
              
                Vector3 v = pos;
                v.x += delta * Mathf.Sin(Time.time * speed);
                transform.position = v;
                StartCoroutine(Win());
                TowerHp.text = "";

                int iValue = PlayerPrefs.GetInt("Stage");
                if (iValue == 1)
                {
                    PlayerPrefs.SetInt("Stage", 2);
                    Debug.Log(iValue);
                }

            }
            else
            {
                TowerHp.text = "HP : " + HP.ToString() + " / " + MAXHP;
            }
        }
        
    }

    private IEnumerator HIT()
    {
        yield return new WaitForSeconds(0.5f);
        hit = false;
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(1.0f);
        DataManager.GetInstance().Win = true;
    }

    public void Damage(float damage)
    {
        HP -= damage;
        hit = true;

    }

}
