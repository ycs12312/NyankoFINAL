using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataUi : MonoBehaviour
{
    public Text Money;
    public Text Exp;
    public Text Level;
    public Text LevelMoney;

    public Text CAT1Money;
    public Text CAT2Money;
    public Text CAT3Money;
    public Text CAT4Money;
    public Text CAT5Money;

    private void Awake()
    {
        
        Exp = GetComponent<Text>();
    
    }

    // Start is called before the first frame update
    void Start()
    {
        Money = GameObject.Find("Money").GetComponent<Text>();
        Level = GameObject.Find("Level").GetComponent<Text>();
        LevelMoney = GameObject.Find("LevelMoney").GetComponent<Text>();
        CAT1Money = GameObject.Find("CAT1Money").GetComponent<Text>();
        CAT2Money = GameObject.Find("CAT2Money").GetComponent<Text>();
        CAT3Money = GameObject.Find("CAT3Money").GetComponent<Text>();
        CAT4Money = GameObject.Find("CAT4Money").GetComponent<Text>();
        CAT5Money = GameObject.Find("CAT5Money").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        Money.text = "MONEY : " + DataManager.GetInstance().money.ToString() + " / 5000";

        //Exp.text = "Exp : " + DataManager.GetInstance().exp.ToString();


        if (DataManager.GetInstance().level >= 6)
        {
            Level.text = "LEVEL MAX";
            LevelMoney.text = "";
        }
        else
        {
            Level.text = "LEVEL " + DataManager.GetInstance().level.ToString();
            LevelMoney.text = "$" + DataManager.GetInstance().levelmoney.ToString();
        }

        CAT1Money.text = "$" + DataManager.GetInstance().CAT1Money.ToString();
        CAT2Money.text = "$" + DataManager.GetInstance().CAT2Money.ToString();
        CAT3Money.text = "$" + DataManager.GetInstance().CAT3Money.ToString();
        CAT4Money.text = "$" + DataManager.GetInstance().CAT4Money.ToString();
        CAT5Money.text = "$" + DataManager.GetInstance().CAT5Money.ToString();
    }
}
