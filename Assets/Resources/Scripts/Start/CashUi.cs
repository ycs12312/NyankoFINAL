using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashUi : MonoBehaviour
{
    public Text xp;
    public Text cash;

    public int INTXP;
    public int INTCASH;

    void Start()
    {
        xp = GameObject.Find("xp").GetComponent<Text>();
        cash = GameObject.Find("cash").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        INTXP = PlayerPrefs.GetInt("xp");
        INTCASH = PlayerPrefs.GetInt("cash");

        xp.text = INTXP.ToString();
        cash.text = INTCASH.ToString();
        //Debug.Log(INTCASH);
    }
}
