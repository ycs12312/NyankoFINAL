using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int StageNum;
    public float HP;
    public float Time1;
    public float Time2;
    private int Speed;
    public int maxMoney;
    public static GameManager instance = null;
    public GameObject DefeatTarget;
    public GameObject WinTarget;
    public GameObject MenuTarget;
    public GameObject Target;
   
    public Image image1;
    public Button button1;
    public float coolTime1 = 3.0f;
    public bool isClicked1 = false;
    public bool Spawn1 = false;
    float leftTime1 = 20.0f;
    float cool = 10.0f;
    AudioSource audioSource;
    public bool shoot;

    public bool WinSound;
    public bool DefeatSound;
    public int INTXP;
    public AudioClip Winclip;
    public AudioClip Defeatclip;
    public AudioClip SelectClip;
    public AudioClip UpgradeClip;
    public AudioClip BackGroundClip;

    public int clear;
    public int level;
    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        StageNum = PlayerPrefs.GetInt("level");
        INTXP = PlayerPrefs.GetInt("xp");

        PlayerPrefs.SetInt("ingame", 1);
        PlayerPrefs.Save();
   
        DataManager.GetInstance().money = 100;
        DataManager.GetInstance().exp = 0;
        DataManager.GetInstance().level = 1;
        DataManager.GetInstance().Speed = 1;
        DataManager.GetInstance().levelmoney = 100;
        DataManager.GetInstance().CAT1Money = 40;
        DataManager.GetInstance().CAT2Money = 80;
        DataManager.GetInstance().CAT3Money = 200;
        DataManager.GetInstance().CAT4Money = 100;
        DataManager.GetInstance().CAT5Money = 400;

        WinSound = false;
        DefeatSound = false;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(this);
        }

        image1.fillAmount = 1;
    }

    public int getMoney()
    {
        return DataManager.GetInstance().money;
    }

    public int getLevel()
    {
        return DataManager.GetInstance().level;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time1 = 1.0f;
        Time2 = 1.0f;
        Target.SetActive(true);


        //StartCoroutine(CoolTime(10.0f));
    }

    // Update is called once per frame
    void Update()
    {
        level = PlayerPrefs.GetInt("level");

        //Debug.Log(getMoney());
        //Debug.Log(gameObject.GetComponent<GameManager>().getMoney());
        if (!DataManager.GetInstance().Die)
        {
            if (Time2 < Time.time)
            {
                Time1 = 0.2f;
                Time2 = Time1 + Time.time;
                DataManager.GetInstance().money += DataManager.GetInstance().Speed;
            }

        }

        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 5000)
        {
            DataManager.GetInstance().Speed = 0;
        }
        else
        {
            DataManager.GetInstance().Speed = 2;
        }

      
        if (DataManager.GetInstance().Die && !DefeatSound)
        {
            DefeatTarget.SetActive(true);

            SoundManager.instance.SFXPlay("Defeat", Defeatclip);
            DefeatSound = true;
        }

        if (DataManager.GetInstance().Win && !WinSound)
        {
            WinTarget.SetActive(true);

  
            SoundManager.instance.SFXPlay("Win", Winclip);
            WinSound = true;
            
        }


        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 100
            && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 1)
        {
            Target.SetActive(false);
        }
        else if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 200
           && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 2)
        {
            Target.SetActive(false);
        }
        else if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 200
           && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 3)
        {
            Target.SetActive(false);
        }
        else if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 300
          && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 4)
        {
            Target.SetActive(false);
        }
        else if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 400
          && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 5)
        {
            Target.SetActive(false);
        }
        else
        {
            Target.SetActive(true);
        }


      /*
        while(cool>1.0f)
        {
            cool -= Time.deltaTime;
            float ratio = (1.0f / cool);
            if (image1)
                image1.fillAmount = ratio;
        }
               */
         //   }


    }

    public void ExpButton()
    {
        Destroy(BackGroundClip);

        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 100 
            && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 1)
        {
            SoundManager.instance.SFXPlay("Upgrade", UpgradeClip);
            DataManager.GetInstance().money -= 100;
            Debug.Log("타워 업그레이드 1");
            DataManager.GetInstance().Speed = 10;
            DataManager.GetInstance().level = 2;
            DataManager.GetInstance().levelmoney = 200;
            Target.SetActive(true);

        }

        else if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 200 
            && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 2)
        {
            SoundManager.instance.SFXPlay("Upgrade", UpgradeClip);
            DataManager.GetInstance().money -= 200;
            Debug.Log("타워 업그레이드 2");
            DataManager.GetInstance().Speed = 20;
            DataManager.GetInstance().level = 3;
            DataManager.GetInstance().levelmoney = 300;
            Target.SetActive(true);
        }

        else if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 300
         && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 3)
        {
            SoundManager.instance.SFXPlay("Upgrade", UpgradeClip);
            DataManager.GetInstance().money -= 300;
            Debug.Log("타워 업그레이드 3");
            DataManager.GetInstance().Speed = 30;
            DataManager.GetInstance().level = 4;
            DataManager.GetInstance().levelmoney = 400;
            Target.SetActive(true);
        }

        else if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 400
         && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 4)
        {
            SoundManager.instance.SFXPlay("Upgrade", UpgradeClip);
            DataManager.GetInstance().money -= 400;
            Debug.Log("타워 업그레이드 3");
            DataManager.GetInstance().Speed = 40;
            DataManager.GetInstance().level = 5;
            DataManager.GetInstance().levelmoney = 500;
            Target.SetActive(true);
        }

        else if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 500
         && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLevel() == 5)
        {
            SoundManager.instance.SFXPlay("Upgrade", UpgradeClip);
            DataManager.GetInstance().money -= 500;
            Debug.Log("타워 업그레이드 3");
            DataManager.GetInstance().Speed = 50;
            DataManager.GetInstance().level = 6;
        }
    }

   
    public void MenuButton()
    {

        SoundManager.instance.SFXPlay("Select", SelectClip);
        MenuTarget.SetActive(!MenuTarget.active);

        if (Time.timeScale == 0f)
        Time.timeScale = 1f;

        else if(Time.timeScale == 1f)
        Time.timeScale = 0f;
    }

    public void ExitMenuButton()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        MenuTarget.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RetryButton()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        if (StageNum == 1)
        {

            Debug.Log("1번 스테이지");
            SceneManager.LoadScene("Stage1");
        }

        if (StageNum == 2)
        {

            Debug.Log("2번 스테이지");
            SceneManager.LoadScene("Stage2");
        }
        Time.timeScale = 1f;
    }

    public void EscapeButton()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        DataManager.GetInstance().ReS = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }


  
    IEnumerator CoolTime(float cool)
    {

        button1.enabled = false;
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            image1.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();

        }

    }

    public void winenterbutton()
    {
     
        SoundManager.instance.SFXPlay("Select", SelectClip);

        if (StageNum == 1)
        {
            INTXP += 1500;
            PlayerPrefs.SetInt("xp", INTXP);

            PlayerPrefs.SetInt("clear", 2);
            PlayerPrefs.Save();
        }
        if (StageNum == 2)
        {
            INTXP += 3000;
            PlayerPrefs.SetInt("xp", INTXP);
            PlayerPrefs.SetInt("clear", 3);
            PlayerPrefs.Save();
        }
        if (level == 3)
        {
            PlayerPrefs.SetInt("clear", 4);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("StartScene");
    }

    public void defeatbutton()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);

        SceneManager.LoadScene("StartScene");
    }
}