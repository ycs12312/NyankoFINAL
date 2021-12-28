using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgSound;
    public AudioClip[] bglist;
    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for(int i = 0; i < bglist.Length; i++)
        {
            if(arg0.name == "Stage1")
                BGSoundPlay(bglist[0]);
            if (arg0.name == "Stage2")
                BGSoundPlay(bglist[1]);
            if (arg0.name == "StartScene")
                BGSoundPlay(bglist[2]);
         
        }
        
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }

    public void SFXPlay2(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;

        audioSource.Play();

        Destroy(go, clip.length);
    }

    public void SFXPlay3(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Stop();

        Destroy(go, clip.length);
    }

    public void BGSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 1.0f;
        bgSound.Play();

    }

    public void BGSoundStop(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.Stop();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.GetInstance().Win == true || DataManager.GetInstance().Die == true || DataManager.GetInstance().ReS == true)
            bgSound.Stop();
    }
}
