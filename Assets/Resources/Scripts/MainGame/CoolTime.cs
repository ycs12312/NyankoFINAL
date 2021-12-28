using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    public Image image1;
    public Button button1;
    public float coolTime1 = 20.0f;
    public bool isClicked1 = false;
    float leftTime1 = 10.0f;
    public Image image2;
    public Button button2;
    public float coolTime2 = 20.0f;
    public bool isClicked2 = false;
    float leftTime2 = 10.0f;
    float speed = 5.0f;

    // Update is called once per frame
    void Update()
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

      
    }

    public void StartCoolTime11()
    {
      

    }

    public void StartCoolTime1()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 40)
        {
            Debug.Log("1¹ø ¹öÆ° ÄðÅ¸ÀÓ");
            leftTime1 = coolTime1;
                isClicked1 = true;
                if (button1)
                    button1.enabled = false;
           
        }
        else
        {
            Debug.Log("µ·¾ø");
        }
    }

    public void StartCoolTime2()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getMoney() >= 100)
        {
            Debug.Log("2¹ø ¹öÆ° ÄðÅ¸ÀÓ");
            leftTime2 = coolTime2;
                isClicked2 = true;
                if (button2)
                    button2.enabled = false;
        }
    }
}


