using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager Instance = null;
    private static GameObject Container = null;

    public static DataManager GetInstance()
    {

        if (Instance == null)
        {
            Container = new GameObject("DataManager");
            Instance = new DataManager();

            Instance = Container.AddComponent(typeof(DataManager)) as DataManager;
        }
        return Instance;

    }

    [SerializeField] private GameObject CatParent = null;
    [HideInInspector] public GameObject Cat1Prefab;

    [HideInInspector] public bool Die;
    [HideInInspector] public bool Win;
    [HideInInspector] public bool ReS;
    [HideInInspector] public int Count = 0;

    public float HP;
    public float ATK;
    public int money;
  
    public int exp;
    public int level;
    public int Speed;
    public int levelmoney;

    public int CAT1Money;
    public int CAT2Money;
    public int CAT3Money;
    public int CAT4Money;
    public int CAT5Money;


    public int CAT2Level;
    public float CAT2Hp;
    public float CAT2Speed;

    public int CAT1Level =1;

    private List<GameObject> EnemyList = new List<GameObject>();

    private List<GameObject> EnableList = new List<GameObject>();

    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }

    private Stack<GameObject> DisableList = new Stack<GameObject>();


    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }


   


  
}
