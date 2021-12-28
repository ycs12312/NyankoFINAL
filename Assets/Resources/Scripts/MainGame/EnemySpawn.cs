using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject EnemyParent = null;
    [HideInInspector] public GameObject Eenmy1Prefab;
    [HideInInspector] public GameObject Eenmy2Prefab;
    [HideInInspector] public GameObject Eenmy3Prefab;
    [HideInInspector] public GameObject Eenmy4Prefab;

    public float coolTime1 = 3.0f;
    public bool isClicked1 = false;
    public bool Spawn1 = false;
    float leftTime1 = 10.0f;


    public float coolTime2 = 5.0f;
    public bool isClicked2 = false;
    float leftTime2 = 10.0f;

    float speed = 5.0f;
    bool boss = false;

    public int StageNum;

    private void Awake()
    {
        StageNum = PlayerPrefs.GetInt("level");
        EnemyParent = new GameObject("EnemyParent");
        Eenmy1Prefab = Resources.Load("Prefabs/Doge") as GameObject;
        Eenmy2Prefab = Resources.Load("Prefabs/Marksman") as GameObject;
        Eenmy3Prefab = Resources.Load("Prefabs/Bear") as GameObject;
        Eenmy4Prefab = Resources.Load("Prefabs/Snake") as GameObject;
    }



    private void Start()
    {
        if (StageNum == 1)
        {
            InvokeRepeating("spawnEnemy1", 7.0f, Random.Range(4.0f, 7.0f));
            InvokeRepeating("spawnEnemy2", 10.0f, Random.Range(7.0f, 10.0f));
            InvokeRepeating("spawnEnemy4", 13.0f, Random.Range(4.0f, 7.0f));
            boss = false;
        }
        if (StageNum == 2)
        {
            InvokeRepeating("spawnEnemy1", 5.0f, Random.Range(4.0f, 7.0f));
            InvokeRepeating("spawnEnemy2", 8.0f, Random.Range(7.0f, 10.0f));
            InvokeRepeating("spawnEnemy3", 10.0f, Random.Range(4.0f, 7.0f));
            InvokeRepeating("spawnEnemy4", 11.0f, Random.Range(4.0f, 7.0f));
            boss = false;
        }
        if (StageNum == 3)
        {
            InvokeRepeating("spawnEnemy1", 7.0f, Random.Range(4.0f, 7.0f));
            InvokeRepeating("spawnEnemy2", 10.0f, Random.Range(7.0f, 10.0f));
            InvokeRepeating("spawnEnemy3", 20.0f, Random.Range(4.0f, 7.0f));
            InvokeRepeating("spawnEnemy4", 13.0f, Random.Range(4.0f, 7.0f));
            boss = false;
        }
    }

    private void spawnEnemy1()
    {
        if (!DataManager.GetInstance().Win)
        {
            GameObject Obj = Instantiate(Eenmy1Prefab);
            Obj.transform.position = new Vector3(-6.0f, Random.Range(-0.5f, -1.3f), -0.6f);
            Obj.transform.name = "Doge";
            Obj.transform.parent = EnemyParent.transform;
        }
    }


    private void spawnEnemy2()
    {
        if (!DataManager.GetInstance().Win)
        {
            GameObject Obj = Instantiate(Eenmy2Prefab);
            Obj.transform.position = new Vector3(-6.0f, Random.Range(-0.5f, -1.3f), -0.6f);
            Obj.transform.name = "Marksman";
            Obj.transform.parent = EnemyParent.transform;
        }
    }


    private void spawnEnemy3()
    {
        if (!DataManager.GetInstance().Win)
        {
            if (!boss)
            {
                GameObject Obj = Instantiate(Eenmy3Prefab);
                Obj.transform.position = new Vector3(-6.0f, -0.47f, -0.6f);
                Obj.transform.name = "Bear";
                Obj.transform.parent = EnemyParent.transform;
                boss = true;
            }
        }
    }

    private void spawnEnemy4()
    {
        if (!DataManager.GetInstance().Win)
        {
            GameObject Obj = Instantiate(Eenmy4Prefab);
            Obj.transform.position = new Vector3(-6.0f, Random.Range(-0.5f, -1.3f), -0.6f);
            Obj.transform.name = "Snake";
            Obj.transform.parent = EnemyParent.transform;
        }
    }

}
