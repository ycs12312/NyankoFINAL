using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{

    public Text INFOtext;
    public GameObject Cat1Button;

    private void Awake()
    {
        Cat1Button = GameObject.Find("Cat1Button");
    }

    // Start is called before the first frame update
    void Start()
    {
        INFOtext = GameObject.Find("INFOtext").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void Button1()
    {
        INFOtext.text = "1�� ����̿� ���� ���� ";
    }

    void Button2()
    {
        INFOtext.text = "2�� ����̿� ���� ���� ";
    }

    void Button3()
    {
        INFOtext.text = "3�� ����̿� ���� ���� ";
    }
    
    void Button4()
    {
        INFOtext.text = "4�� ����̿� ���� ���� ";
    }

    void Button5()
    {
        INFOtext.text = "5�� ����̿� ���� ���� ";
    }
    */
}
