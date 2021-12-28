using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfers : MonoBehaviour
{
    private void Awake()
    {
        DataManager.GetInstance().CAT2Hp = 500.0f;

    }
   

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Stage", 1);
      

        PlayerPrefs.SetInt("cat2_Level", 5);
        PlayerPrefs.SetFloat("cat2_Hp", DataManager.GetInstance().CAT2Hp);
        PlayerPrefs.SetString("cat2_name", "cat2");


       
    }

    // Update is called once per frame
    public void upgrade()
    {

        PlayerPrefs.SetFloat("cat2_Hp", DataManager.GetInstance().CAT2Hp);

        //iValue += 10;
        DataManager.GetInstance().CAT2Hp += 100;
    }
}
