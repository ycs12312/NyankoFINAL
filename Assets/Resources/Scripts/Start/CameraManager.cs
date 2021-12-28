using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class CameraManager : MonoBehaviour
{

    public float CameraSpeed;
    public Camera MainCamera;


    public RectTransform LeftDoorrectTransform;
    public RectTransform RightDoorrectTransform;


    public GameObject MainCanvas;
    public GameObject StageCanvas;
    public GameObject UICanvas;
    public GameObject MainMenuCanvas;
    public GameObject UpgradeCanvas;

    public GameObject LeftDoorImage;
    public GameObject RightDoorImage;
    public GameObject AttackButton;
    public GameObject StartButton1;
    public GameObject UpgradeButton1;

    public GameObject Player;

    public GameObject Stage2Image;
    public GameObject Stage3Image;

    public AudioClip SelectClip;
    public AudioClip UpgradeClip;
    public AudioClip CancelClip;
 
    public Text xp;
    public Text cash;

    public bool open;
    public float dd = 0;

    public int INTXP;
    public int INTCASH;

    public int StageNum;
    public int StageClear;
    public int InGame;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("ingame"))
            PlayerPrefs.SetInt("ingame", 0);

        MainCanvas = GameObject.Find("MainCanvas");
        StageCanvas = GameObject.Find("StageCanvas");
        UICanvas = GameObject.Find("UICanvas");
        MainMenuCanvas = GameObject.Find("MainMenuCanvas");
        UpgradeCanvas = GameObject.Find("UpgradeCanvas");

        LeftDoorImage = GameObject.Find("LeftDoorImage");
        RightDoorImage = GameObject.Find("RightDoorImage");

        AttackButton = GameObject.Find("AttackButton");
        StartButton1 = GameObject.Find("StartButton");
        UpgradeButton1 = GameObject.Find("UpgradeButton");

        Stage2Image = GameObject.Find("Stage2Image");
        Stage3Image = GameObject.Find("Stage3Image");

        //Player = Resources.Load("Prefabs/Player") as GameObject;

        Player = GameObject.Find("Player");

       LeftDoorrectTransform = LeftDoorImage.GetComponent<RectTransform>();
        RightDoorrectTransform = RightDoorImage.GetComponent<RectTransform>();

        MainCanvas.SetActive(true);
        StageCanvas.SetActive(false);
        UICanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        UpgradeCanvas.SetActive(false);

        AttackButton.SetActive(false);
        StartButton1.SetActive(false);
        UpgradeButton1.SetActive(false);

        CameraSpeed = 8.0f;

        StageNum = PlayerPrefs.GetInt("level");
        StageClear = PlayerPrefs.GetInt("clear");
        InGame = PlayerPrefs.GetInt("ingame");
        INTXP = PlayerPrefs.GetInt("xp");
        INTCASH = PlayerPrefs.GetInt("cash");
       
        Player.transform.position = new Vector3(0f, 0f, 0f);
        MainCamera.transform.position = new Vector3(0.6f, 1.0f, -9.3f);
        LeftDoorrectTransform.transform.localPosition = new Vector3(-480.0f, 0f, 0f);
        RightDoorrectTransform.transform.localPosition = new Vector3(480.0f, 0f, 0f);


      
    }

 
    // Start is called before the first frame update
    void Start()
    {
      

        //xp.text = "1000";
        // cash.text = "100";

        if (InGame == 1)
        {
          StartButton();
        }

        //GameObject PlayerCat = Instantiate(Player) as GameObject;
        // Player.transform.position = new Vector3(50.4f, 1.0f, -7.0f);


    }

    // Update is called once per frame
    void Update()
    {
        if (StageNum == 1)
        {
            Player.transform.position = new Vector3(-70.51f, 1.07f, -7.0f);
        }
        else if (StageNum == 2 )
        { 
            Player.transform.position = new Vector3(-71.09f, 1.25f, -7.0f);
        }
        else if (StageNum == 3 )
        {
            Player.transform.position = new Vector3(-70.998f, 0.859f, -7.0f);
        }


        if(StageClear >= 2)
        {
            Stage2Image.SetActive(false);
        }
        else if (StageClear >= 3)
        {
            Stage3Image.SetActive(false);
        }

        

        if (open)
        {
            if (LeftDoorrectTransform.transform.localPosition.x > -1370.0f)
                LeftDoorrectTransform.transform.localPosition += Vector3.left * 600.0f * Time.deltaTime;

            if (RightDoorrectTransform.transform.localPosition.x < 1370.0f)
                RightDoorrectTransform.transform.localPosition += Vector3.right * 600.0f * Time.deltaTime;
        }
        else if(!open)
        {
            if (LeftDoorrectTransform.transform.localPosition.x < -480.0f)
                LeftDoorrectTransform.transform.localPosition += Vector3.right * 800.0f * Time.deltaTime;

            if (RightDoorrectTransform.transform.localPosition.x > 480)
                RightDoorrectTransform.transform.localPosition += Vector3.left * 800.0f * Time.deltaTime;
        }
    }



    public void StartButton()
    {
        Reset();
        SoundManager.instance.SFXPlay("Select", SelectClip);
        MainCanvas.SetActive(false);
        UICanvas.SetActive(true);
        MainMenuCanvas.SetActive(true);
        StartButton1.SetActive(true);
        UpgradeButton1.SetActive(true);

        dd = 1;
        //close = true;
        //LeftDoorrectTransform.transform.localPosition = new Vector3(-1370.0f, 0f, 0f);
        //RightDoorrectTransform.transform.localPosition = new Vector3(1370.0f, 0f, 0f);

    }

    public void MissonButton()
    {
        Reset();
        SoundManager.instance.SFXPlay("Select", SelectClip);
        open = true;
        StageCanvas.SetActive(true);
        AttackButton.SetActive(true);
        MainCamera.transform.position = new Vector3(-71.4f, 1.0f, -9.3f);

        dd = 2;


    }

    public void UpgradeButton()
    {
        Reset();
        SoundManager.instance.SFXPlay("Select", SelectClip);
        open = true;
        UpgradeCanvas.SetActive(true);
        MainCamera.transform.position = new Vector3(-32.0f, 1.0f, -9.3f);

        dd = 3;
    }

    public void Reset()
    {
      
        AttackButton.SetActive(false);
        StartButton1.SetActive(false);
        UpgradeCanvas.SetActive(false);
        UpgradeButton1.SetActive(false);
        StageCanvas.SetActive(false);
    }


    public void ReturnButton()
    {
        SoundManager.instance.SFXPlay("Cancel", CancelClip);
        open = false;

        if (dd == 2)
            StartButton();
        else if (dd == 3)
            StartButton();


    }

    public void Stage1Button()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        StageNum = PlayerPrefs.GetInt("level");

   
    }

    public void Stage2Button()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        PlayerPrefs.SetInt("level", 2);
        PlayerPrefs.Save();
        StageNum = PlayerPrefs.GetInt("level");
        //Player.transform.position = new Vector3(-71.09f, 1.25f, -7.0f);
    }

    public void Stage3Button()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        PlayerPrefs.SetInt("level",3);
        PlayerPrefs.Save();
        StageNum = PlayerPrefs.GetInt("level");

        //Player.transform.position = new Vector3(-70.998f, 0.859f, -7.0f);
    }

    public void StageAttackButton()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        Debug.Log(StageNum);
        StageNum = PlayerPrefs.GetInt("level");
        if (StageNum == 1)
        {
            INTCASH -= 10;
            PlayerPrefs.SetInt("cash", INTCASH);
            PlayerPrefs.Save();
            Debug.Log("1번 스테이지");
            SceneManager.LoadScene("Stage1");
        }

        if (StageNum == 2)
        {
            INTCASH -= 10;
            PlayerPrefs.SetInt("cash", INTCASH);
            PlayerPrefs.Save();
            Debug.Log("2번 스테이지");
            SceneManager.LoadScene("Stage2");
        }

        if (StageNum == 3)
        {
            INTCASH -= 10;
            PlayerPrefs.SetInt("cash", INTCASH);
            PlayerPrefs.Save();
            Debug.Log("3번 스테이지");
            SceneManager.LoadScene("Stage2");
        }
    }

}
