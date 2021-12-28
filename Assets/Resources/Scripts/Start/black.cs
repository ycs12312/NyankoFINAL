using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;    //씬 매니지먼트 선언 필수.


public class black : MonoBehaviour

{
    public GameObject blackimage;
    public RectTransform blackmove;

    private void Awake()
    {
        blackimage = GameObject.Find("blackimage");
        blackmove = blackimage.GetComponent<RectTransform>();

        blackimage.transform.localPosition = new Vector3(1916.0f, 0f, 0f);
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);   
    }


    public void button()
    {
          if (blackimage.transform.localPosition.x > -1920)
            blackimage.transform.localPosition += Vector3.left * 800.0f * Time.deltaTime;
    }



}
