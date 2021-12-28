using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cat2 : MonoBehaviour
{
    public int StageNum;

    public Image CAT4;
    public Sprite CAT4A;
    public Sprite CAT4B;

    public void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StageNum = PlayerPrefs.GetInt("cat1LEVEL");

        if (StageNum < 5)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Cat1/CAT1A");
            //this.gameObject.GetComponent<SpriteRenderer>().image = CAT1;
            CAT4.sprite = CAT4A;
        }

        if (StageNum >= 5)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Cat1/CAT1B");
            //spriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/ETower1");
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = CAT1A;
            CAT4.sprite = CAT4B;
        }

    }
}
