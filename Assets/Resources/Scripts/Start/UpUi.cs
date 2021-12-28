using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpUi : MonoBehaviour
{
    public Text INFOtext;

    public Text Cat1Text;
    public Text Cat1CostText;

    public Text Cat2Text;
    public Text Cat2CostText;

    public Text Cat4Text;
    public Text Cat4CostText;


    public int CatNum = 1;

    public int INTXP;

    public int cat1Level;
    public float cat1ATK;
    public float cat1HP;

    public int cat2Level;
    public float cat2ATK;
    public float cat2HP;

    public int cat4Level;
    public float cat4ATK;
    public float cat4HP;

    public AudioClip UpgradeClip;
    public AudioClip SelectClip;

    private void Awake()
    {
        CatNum = 1;
        INTXP = PlayerPrefs.GetInt("xp");
        cat1Level = PlayerPrefs.GetInt("cat1LEVEL");
        cat1HP = PlayerPrefs.GetFloat("cat1HP");
        cat1ATK = PlayerPrefs.GetFloat("cat1ATK");

        cat2Level = PlayerPrefs.GetInt("cat2LEVEL");
        cat2HP = PlayerPrefs.GetFloat("cat2HP");
        cat2ATK = PlayerPrefs.GetFloat("cat2ATK");

        cat4Level = PlayerPrefs.GetInt("cat4LEVEL");
        cat4HP = PlayerPrefs.GetFloat("cat4HP");
        cat4ATK = PlayerPrefs.GetFloat("cat4ATK");

    }
    // Start is called before the first frame update
    void Start()
    {
        INFOtext = GameObject.Find("INFOtext").GetComponent<Text>();

        Cat2CostText = GameObject.Find("Cat2CostText").GetComponent<Text>();
        Cat2Text = GameObject.Find("Cat2Text").GetComponent<Text>();

        Cat4CostText = GameObject.Find("Cat4CostText").GetComponent<Text>();
        Cat4Text = GameObject.Find("Cat4Text").GetComponent<Text>();


        Cat1CostText = GameObject.Find("Cat1CostText").GetComponent<Text>();
        Cat1Text = GameObject.Find("Cat1Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CatNum == 1)
        {
            if (cat1Level >= 5)
                INFOtext.text = "<고양이 빌더>" + System.Environment.NewLine + "철저히 단련된 근육이 매력인 기본 캐릭터"; 
            else
              INFOtext.text = "<고양이>" + System.Environment.NewLine + "저가생산 가능한 기본 캐릭터";
        }
        else if (CatNum == 2)
        {
            INFOtext.text = "<탱크 고양이>" + System.Environment.NewLine + "고체력 방어용 캐릭터 공격력은 새발의 피";
        }
        else if (CatNum == 3)
        {
            INFOtext.text = "<고양이 도마뱀>" + System.Environment.NewLine + "원거리형 캐릭터 단발의 공격력이 으뜸";
        }
        else if (CatNum == 4)
        {
            if (cat4Level >= 5)
                INFOtext.text = "<용사 고양이>" + System.Environment.NewLine + "용사를 동경하는 전투용 고급 캐릭터(범위 공격)";
            else
                INFOtext.text = "<도끼 고양이>" + System.Environment.NewLine + "전투용 고급 캐릭터(범위 공격)";
        }
        else if (CatNum == 5)
        {
            INFOtext.text = "<거신 고양이>" + System.Environment.NewLine + "초절대 파괴력의 최고급 캐릭터(범위 공격)";
        }

        Cat1Text.text = cat1Level.ToString();

        if (cat1Level == 1)
            Cat1CostText.text = "100";
        if (cat1Level == 2)
            Cat1CostText.text = "200";
        if (cat1Level == 3)
            Cat1CostText.text = "300";
        if (cat1Level == 4)
            Cat1CostText.text = "400";
        if (cat1Level == 5)
            Cat1CostText.text = "MAX";

        Cat2Text.text = cat2Level.ToString();

        if (cat2Level == 1)
            Cat2CostText.text = "100";
        if (cat2Level == 2)
            Cat2CostText.text = "200";
        if (cat2Level == 3)
            Cat2CostText.text = "300";
        if (cat2Level == 4)
            Cat2CostText.text = "400";
        if (cat2Level == 5)
            Cat2CostText.text = "MAX";

        Cat4Text.text = cat4Level.ToString();

        if (cat4Level == 1)
            Cat4CostText.text = "100";
        if (cat4Level == 2)
            Cat4CostText.text = "200";
        if (cat4Level == 3)
            Cat4CostText.text = "300";
        if (cat4Level == 4)
            Cat4CostText.text = "400";
        if (cat4Level == 5)
            Cat4CostText.text = "MAX";
    }

    public void Button1()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        CatNum = 1;
    }

    public void Button2()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        CatNum = 2;
    }

    public void Button3()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        CatNum = 3;
    }

    public void Button4()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        CatNum = 4;
    }

    public void Button5()
    {
        SoundManager.instance.SFXPlay("Select", SelectClip);
        CatNum = 5;
    }

    public void PowerButton()
    {
        if (CatNum == 1)
        {
            Debug.Log(cat1Level);
            Debug.Log(INTXP);
            if (cat1Level <= 5)
            {

                if (cat1Level == 1 && INTXP >= 100)
                {
                    INTXP -= 100;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat1Level == 2 && INTXP >= 200)
                {
                    INTXP -= 200;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat1Level == 3 && INTXP >= 300)
                {
                    INTXP -= 300;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat1Level == 4 && INTXP >= 400)
                {
                    INTXP -= 400;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat1Level == 5 && INTXP >= 500)
                {
                    INTXP -= 500;
                    PlayerPrefs.SetInt("xp", INTXP);
                }

                SoundManager.instance.SFXPlay("Upgrade", UpgradeClip);

                cat1ATK += 10.0f;
   
                PlayerPrefs.SetFloat("cat1ATK", cat1ATK);
                PlayerPrefs.Save();

                cat1HP += 100.0f;

                PlayerPrefs.SetFloat("cat1HP", cat1HP);
                PlayerPrefs.Save();
                cat1Level += 1;
                PlayerPrefs.SetInt("cat1LEVEL", cat1Level);
                PlayerPrefs.Save();
            }

        }

      

        if (CatNum == 2)
        {
            Debug.Log(cat2Level);
            Debug.Log(cat2HP);
            Debug.Log(INTXP);
            if (cat2Level <= 5)
            {

                if (cat2Level == 1 && INTXP >= 100)
                {
                    INTXP -= 100;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat2Level == 2 && INTXP >= 200)
                {
                    INTXP -= 200;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat2Level == 3 && INTXP >= 300)
                {
                    INTXP -= 300;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat2Level == 4 && INTXP >= 400)
                {
                    INTXP -= 400;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat2Level == 5 && INTXP >= 500)
                {
                    INTXP -= 500;
                    PlayerPrefs.SetInt("xp", INTXP);
                }

                SoundManager.instance.SFXPlay("Upgrade", UpgradeClip);

                cat2ATK += 10.0f;
                PlayerPrefs.SetFloat("cat2ATK", cat2ATK);
                PlayerPrefs.Save();
                cat2HP += 200.0f;
                PlayerPrefs.SetFloat("cat2HP", cat2HP);
                PlayerPrefs.Save();
                cat2Level += 1;
                PlayerPrefs.SetInt("cat2LEVEL", cat2Level);

                PlayerPrefs.Save();
            }

        }


        if (CatNum == 4)
        {
            Debug.Log(cat4Level);
            Debug.Log(INTXP);
            if (cat4Level <= 5)
            {

                if (cat4Level == 1 && INTXP >= 100)
                {
                    INTXP -= 100;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat4Level == 2 && INTXP >= 200)
                {
                    INTXP -= 200;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat4Level == 3 && INTXP >= 300)
                {
                    INTXP -= 300;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat4Level == 4 && INTXP >= 400)
                {
                    INTXP -= 400;
                    PlayerPrefs.SetInt("xp", INTXP);
                }
                if (cat4Level == 5 && INTXP >= 500)
                {
                    INTXP -= 500;
                    PlayerPrefs.SetInt("xp", INTXP);
                }

                SoundManager.instance.SFXPlay("Upgrade", UpgradeClip);
                cat4ATK += 10;
                PlayerPrefs.SetFloat("cat4ATK", cat4ATK);
                cat4HP += 10;
                PlayerPrefs.SetFloat("cat4ATK", cat4HP);
                cat4Level += 1;
                PlayerPrefs.SetInt("cat4LEVEL", cat4Level);
                PlayerPrefs.Save();
            }

        }


    }
   
}
