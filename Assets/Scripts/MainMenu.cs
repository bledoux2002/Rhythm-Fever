using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject musicObject;
    
    private AudioSource audioLength;
    private AudioClip AudioClips;
    private float timeToEnd;


    public void Start()
    {
        audioLength = musicObject.GetComponent<AudioSource>();
        AudioClips = audioLength.clip;
        timeToEnd = AudioClips.length;

    }

    public void Update()
    {
        print(Time.time);
        print(timeToEnd);
        if (timeToEnd == 0)
        {
            return;
        }
        if (Time.time > timeToEnd)
        {
            SceneManager.LoadScene("Finished");
        }      
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("ChooseLevel");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Butter");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Believer");
    }

    public void Pause()
    {
        
        Time.timeScale = 0;

        
        
        musicObject.GetComponent<AudioSource>().Pause();

        Pausemenu.SetActive(true);
        
    }

    public void Resume()
    {
        
        Time.timeScale = 1;
        musicObject.GetComponent<AudioSource>().Play();
        
        Pausemenu.SetActive(false);

    }

    public void backToMain()
    {
        
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit()
    {

        Application.Quit();
    }
}
