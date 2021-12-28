using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnitInfo;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject CatParent = null;
    [HideInInspector] public GameObject Cat1Prefab;
    [HideInInspector] public GameObject Cat1APrefab;
    [HideInInspector] public GameObject Cat2Prefab;
    [HideInInspector] public GameObject Cat3Prefab;
    [HideInInspector] public GameObject Cat4Prefab;
    [HideInInspector] public GameObject Cat4APrefab;
    [HideInInspector] public GameObject Cat5Prefab;

    public Image image1;
    public Button button1;
    public float coolTime1 = 3.0f;
    public bool isClicked1 = false;
    public bool Spawn1 = false;
    float leftTime1 = 10.0f;

    public Image image2;
    public Button button2;
    public float coolTime2 = 5.0f;
    public bool isClicked2 = false;
    float leftTime2 = 10.0f;

    public Image image3;
    public Button button3;
    public float coolTime3 = 5.0f;
    public bool isClicked3 = false;
    float leftTime3 = 10.0f;

    public Image image4;
    public Button button4;
    public float coolTime4 = 5.0f;
    public bool isClicked4 = false;
    float leftTime4 = 10.0f;

    public Image image5;
    public Button button5;
    public float coolTime5 = 5.0f;
    public bool isClicked5 = false;
    float leftTime5 = 10.0f;

    float speed = 5.0f;

    public int CAT1NUM;
    public int CAT4NUM;

    //MosterInfo info = new MosterInfo();

    private void Awake()
    {
        CatParent = new GameObject("CatParent");
        Cat1Prefab = Resources.Load("Prefabs/Cat1") as GameObject;
        Cat1APrefab = Resources.Load("Prefabs/Cat1A") as GameObject;
        Cat2Prefab = Resources.Load("Prefabs/Cat2") as GameObject;
        Cat3Prefab = Resources.Load("Prefabs/Cat3") as GameObject;
        Cat4Prefab = Resources.Load("Prefabs/Cat4") as GameObject;
        Cat4APrefab = Resources.Load("Prefabs/Cat4A") as GameObject;
        Cat5Prefab = Resources.Load("Prefabs/Cat5") as GameObject;
        CAT1NUM = PlayerPrefs.GetInt("cat1LEVEL");
        CAT4NUM = PlayerPrefs.GetInt("cat4LEVEL");
    }



    private void Start()
    {
  
        // DataManager.GetInstance().HP = 10;
        // DataManager.GetInstance().ATK = 1;
        // 프로젝트 설정에서 커스텀 축 y1 z3 넣어서 스프라이트 정렬함 오류나면 이거 수정 
    }

    private void Update()
    {
        if (isClicked1)
            if (leftTime1 > 0)
            {
                leftTime1 -= Time.deltaTime * speed;
                if (leftTime1 < 0)
                {
                    leftTime1 = 0;
                    if (button1)
                        button1.enabled = true;
                    isClicked1 = false;
                    Spawn1 = true;
                }

                float ratio = 1.0f - (leftTime1 / coolTime1);
                if (image1)
                    image1.fillAmount = ratio;
            }

        if (isClicked2)
            if (leftTime2 > 0)
            {
                leftTime2 -= Time.deltaTime * speed;
                if (leftTime2 < 0)
                {
                    leftTime2 = 0;
                    if (button2)
                        button2.enabled = true;
                    isClicked2 = false;
                }

                float ratio = 1.0f - (leftTime2 / coolTime2);
                if (image2)
                    image2.fillAmount = ratio;
            }

        if (isClicked3)
            if (leftTime3 > 0)
            {
                leftTime3 -= Time.deltaTime * speed;
                if (leftTime3 < 0)
                {
                    leftTime3 = 0;
                    if (button3)
                        button3.enabled = true;
                    isClicked3 = false;
                }

                float ratio = 1.0f - (leftTime3 / coolTime3);
                if (image3)
                    image3.fillAmount = ratio;
            }

        if (isClicked4)
            if (leftTime4 > 0)
            {
                leftTime4 -= Time.deltaTime * speed;
                if (leftTime4 < 0)
                {
                    leftTime4 = 0;
                    if (button4)
                        button4.enabled = true;
                    isClicked4 = false;
                }

                float ratio = 1.0f - (leftTime4 / coolTime4);
                if (image4)
                    image4.fillAmount = ratio;
            }

        if (isClicked5)
            if (leftTime5 > 0)
            {
                leftTime5 -= Time.deltaTime * speed;
                if (leftTime5 < 0)
                {
                    leftTime5 = 0;
                    if (button5)
                        button5.enabled = true;
                    isClicked5 = false;
                }

                float ratio = 1.0f - (leftTime5 / coolTime5);
                if (image5)
                    image5.fillAmount = ratio;
            }
        //Debug.Log(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney());

    }
    
    public void Button1()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= DataManager.GetInstance().CAT1Money)
        {
            Debug.Log("1번 버튼 쿨타임");
            leftTime1 = coolTime1;
            isClicked1 = true;
            if (button1)
                button1.enabled = false;

                if (DataManager.GetInstance().GetDisableList.Count == 0)
                {

                    for (int i = 0; i < 1; ++i)
                    {
                        DataManager.GetInstance().money -= DataManager.GetInstance().CAT1Money;

                      if (CAT1NUM < 5)
                      {
                        GameObject Obj = Instantiate(Cat1Prefab);
                        Obj.transform.position = new Vector3(6.0f, Random.Range(-0.5f, -1.3f), -0.6f);
                        Obj.transform.name = "Cat1" + DataManager.GetInstance().Count.ToString();
                        ++DataManager.GetInstance().Count;
                        Obj.SetActive(false);
                        Obj.transform.parent = CatParent.transform;
                        DataManager.GetInstance().GetDisableList.Push(Obj);
                      }
                      else if(CAT1NUM >= 5)
                      {
                        GameObject Obj = Instantiate(Cat1APrefab);
                        Obj.transform.position = new Vector3(6.0f, Random.Range(-0.5f, -1.3f), -0.6f);
                        Obj.transform.name = "Cat1" + DataManager.GetInstance().Count.ToString();
                        ++DataManager.GetInstance().Count;
                        Obj.SetActive(false);
                        Obj.transform.parent = CatParent.transform;
                        DataManager.GetInstance().GetDisableList.Push(Obj);
                      }
                    }
                }

                GameObject Cat = DataManager.GetInstance().GetDisableList.Pop();
                Cat.SetActive(true);
            }
        
    }

 

    public void Button2()
    {
        
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= DataManager.GetInstance().CAT2Money)
        {
            Debug.Log("2번 버튼 쿨타임");
            leftTime2 = coolTime2;
            isClicked2 = true;
            if (button2)
                button2.enabled = false;

            if (DataManager.GetInstance().GetDisableList.Count == 0)
            {

                for (int i = 0; i < 1; ++i)
                {
                    DataManager.GetInstance().money -= DataManager.GetInstance().CAT2Money;
                    GameObject Obj = Instantiate(Cat2Prefab);
                    Obj.transform.position = new Vector3(6.0f, Random.Range(-0.7f, -1.1f), -0.6f);
                    Obj.transform.name = "Cat2" + DataManager.GetInstance().Count.ToString();
                    ++DataManager.GetInstance().Count;
                    Obj.SetActive(false);
                    Obj.transform.parent = CatParent.transform;
                    DataManager.GetInstance().GetDisableList.Push(Obj);
                }
            }

            GameObject Cat = DataManager.GetInstance().GetDisableList.Pop();

            Cat.SetActive(true);

            DataManager.GetInstance().GetEnableList.Add(Cat);
        }
    }

    public void Button3()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= DataManager.GetInstance().CAT3Money)
        {
            Debug.Log("3번 버튼 쿨타임");
            leftTime3 = coolTime3;
            isClicked3 = true;
            if (button3)
                button3.enabled = false;

            if (DataManager.GetInstance().GetDisableList.Count == 0)
            {

                for (int i = 0; i < 1; ++i)
                {
                    DataManager.GetInstance().money -= DataManager.GetInstance().CAT3Money;
                    GameObject Obj = Instantiate(Cat3Prefab);
                    Obj.transform.position = new Vector3(6.0f, Random.Range(-0.5f, -1.3f), -0.6f);
                    Obj.transform.name = "Cat3" + DataManager.GetInstance().Count.ToString();
                    ++DataManager.GetInstance().Count;
                    Obj.SetActive(false);
                    Obj.transform.parent = CatParent.transform;
                    DataManager.GetInstance().GetDisableList.Push(Obj);
                }
            }

            GameObject Cat = DataManager.GetInstance().GetDisableList.Pop();

            Cat.SetActive(true);

            DataManager.GetInstance().GetEnableList.Add(Cat);
        }

    }

    public void Button4()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= DataManager.GetInstance().CAT4Money)
        {
            Debug.Log("4번 버튼 쿨타임");
            leftTime4 = coolTime4;
            isClicked4 = true;
            if (button4)
                button4.enabled = false;

            if (DataManager.GetInstance().GetDisableList.Count == 0)
            {

                for (int i = 0; i < 1; ++i)
                {
                    if (CAT4NUM < 5)
                    {
                        DataManager.GetInstance().money -= DataManager.GetInstance().CAT4Money;
                        GameObject Obj = Instantiate(Cat4Prefab);
                        Obj.transform.position = new Vector3(6.0f, Random.Range(-0.5f, -1.3f), -0.6f);
                        Obj.transform.name = "Cat4" + DataManager.GetInstance().Count.ToString();
                        ++DataManager.GetInstance().Count;
                        Obj.SetActive(false);
                        Obj.transform.parent = CatParent.transform;
                        DataManager.GetInstance().GetDisableList.Push(Obj);
                    }
                    if (CAT4NUM >= 5)
                    {
                        DataManager.GetInstance().money -= DataManager.GetInstance().CAT4Money;
                        GameObject Obj = Instantiate(Cat4APrefab);
                        Obj.transform.position = new Vector3(6.0f, Random.Range(-0.5f, -1.3f), -0.6f);
                        Obj.transform.name = "Cat4" + DataManager.GetInstance().Count.ToString();
                        ++DataManager.GetInstance().Count;
                        Obj.SetActive(false);
                        Obj.transform.parent = CatParent.transform;
                        DataManager.GetInstance().GetDisableList.Push(Obj);
                    }
                }
            }

            GameObject Cat = DataManager.GetInstance().GetDisableList.Pop();

            Cat.SetActive(true);

            DataManager.GetInstance().GetEnableList.Add(Cat);
        }

    }

    public void Button5()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= DataManager.GetInstance().CAT5Money)
        {
            Debug.Log("5번 버튼 쿨타임");
            leftTime5 = coolTime5;
            isClicked5 = true;
            if (button5)
                button5.enabled = false;

            if (DataManager.GetInstance().GetDisableList.Count == 0)
            {

                for (int i = 0; i < 1; ++i)
                {
                    DataManager.GetInstance().money -= DataManager.GetInstance().CAT5Money;
                    GameObject Obj = Instantiate(Cat5Prefab);
                    Obj.transform.position = new Vector3(6.0f, -0.47f, -0.7f);
                    Obj.transform.name = "Cat5" + DataManager.GetInstance().Count.ToString();
                    ++DataManager.GetInstance().Count;
                    Obj.SetActive(false);
                    Obj.transform.parent = CatParent.transform;
                    DataManager.GetInstance().GetDisableList.Push(Obj);
                }
            }

            GameObject Cat = DataManager.GetInstance().GetDisableList.Pop();

            Cat.SetActive(true);

            DataManager.GetInstance().GetEnableList.Add(Cat);
        }

    }
    /*
    IEnumerator CoolTime(float cool)
    {
        
        button.enabled = false;
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            image.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
            
        }
        
    }
    */

}
