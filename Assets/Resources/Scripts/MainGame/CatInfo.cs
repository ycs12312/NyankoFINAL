using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnitInfo;


public class CatInfo : MonoBehaviour
{
    /*
    Cat1 cat1 = new Cat1();

    [ContextMenu("To Json Data")]
    public void Start()
    {

        Cat1 cat1 = new Cat1
        {

            ATK = 300.0f,
            HP = 10000.0f,
            SPEED = 10.0f,
            LEVEL = 1

        };

       
        string jsonData = JsonUtility.ToJson(cat1);
        Debug.Log(jsonData);
        string path = Application.dataPath + "playerData.Json";

        File.WriteAllText(path, jsonData);

        
    }

    public void Load()
    {
        string path = Application.dataPath + "playerData.Json";
        string json = File.ReadAllText(path);
        Cat1 cat1 = JsonUtility.FromJson<Cat1>(json);


    }

    public void upgrade()
    {
        // Debug.Log();

        /*
        if (DataManager.GetInstance().CAT1Level == 1)
        {
            Cat1 cat1 = new Cat1
            {
                ATK = 100.0f,
                HP = 5000.0f,
                SPEED = 1.0f,
                LEVEL = 2
            };

            string jsonData = JsonUtility.ToJson(cat1);
            Debug.Log(jsonData);
            string path = Application.dataPath + "playerData.Json";

            File.WriteAllText(path, jsonData);
        }

        if (DataManager.GetInstance().CAT1Level == 2)
        {
            Cat1 cat1 = new Cat1
            {
                ATK = 200.0f,
                HP = 10000.0f,
                SPEED = 2.0f,
                LEVEL = 3
            };


            string jsonData = JsonUtility.ToJson(cat1);
            Debug.Log(jsonData);
            string path = Application.dataPath + "playerData.Json";

            File.WriteAllText(path, jsonData);
        }
        https://chameleonstudio.tistory.com/56
    */

//    }

}
