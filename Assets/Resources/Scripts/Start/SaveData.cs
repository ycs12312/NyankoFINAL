using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int StageClear;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("clear"))
            PlayerPrefs.SetInt("clear", 1);

        if (!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level", 1);
        
        if (!PlayerPrefs.HasKey("xp"))
            PlayerPrefs.SetInt("xp", 10000);

        if (!PlayerPrefs.HasKey("cash"))
            PlayerPrefs.SetInt("cash", 1000);

        if (!PlayerPrefs.HasKey("cat1LEVEL"))
        {
            PlayerPrefs.SetInt("cat1LEVEL", 1);
            PlayerPrefs.SetFloat("cat1ATK", 20.0f);
            PlayerPrefs.SetFloat("cat1HP", 100.0f);
            PlayerPrefs.SetFloat("cat1SPEED", 0.8f);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("cat2LEVEL"))
        {
            PlayerPrefs.SetInt("cat2LEVEL", 1);
            PlayerPrefs.SetFloat("cat2ATK", 5.0f);
            PlayerPrefs.SetFloat("cat2HP", 1000.0f);
            PlayerPrefs.SetFloat("cat2SPEED", 0.8f);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("cat4LEVEL"))
        {
            PlayerPrefs.SetInt("cat4LEVEL", 1);
            PlayerPrefs.SetFloat("cat4ATK", 30.0f);
            PlayerPrefs.SetFloat("cat4HP", 200);
            PlayerPrefs.SetFloat("cat4SPEED", 0.8f);
            PlayerPrefs.Save();
        }
        
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.DeleteAll();
        //DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StageClear = PlayerPrefs.GetInt("level");
        //Debug.Log(StageClear);
    }
}
