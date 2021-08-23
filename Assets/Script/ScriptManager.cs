using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{

    public bool ResetLevel;

    [Space]
    [Header("Level Number")]
    public int LevelNB;

    //[Space]
    //[Header("EnemyPacks")]
    //public GameObject[] EnemyPacksList;

    [Space]
    [Header("Levels")]
    public GameObject[] LevelsList;
    public Text CurrrentLevelNB;

    [Space]
    [Header("Button")]
    public Button Next;
    public Button Restart;
    public Button RestartAfterDeath;
    public GameObject Tutorial;

    public Animator anim1;
    //public Animator anim2;
    //public Animator anim3;

    [Space]
    [Header("Player")]
    public JoystickPlayerExample player;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if ((PlayerPrefs.GetInt("LevelReached")) == 0)
        {
            PlayerPrefs.SetInt("LevelReached", 1);
        }

        CurrrentLevelNB.text = (PlayerPrefs.GetInt("LevelReached")).ToString();
        CurrentLevel();
        //anim2 = Restart.GetComponent<Animator>();
        //anim3 = RestartAfterDeath.GetComponent<Animator>();

        Button btnNext = Next.GetComponent<Button>();
        btnNext.onClick.AddListener(NextTaskOnClick);

        Button btnRestart = Restart.GetComponent<Button>();
        btnRestart.onClick.AddListener(RestartTaskOnClick);

        Button btnRestartAfterDeath = RestartAfterDeath.GetComponent<Button>();
        btnRestartAfterDeath.onClick.AddListener(RestartAfterDeathTaskOnClick);
        
    }
    void NextTaskOnClick()
    {
        player.Finished = false;
        player.Status.gameObject.SetActive(false);
        Tutorial.SetActive(false);
        anim1 = Next.GetComponent<Animator>();
        anim1.SetTrigger("Press");
        player.ResetPosition();
        Next.gameObject.SetActive(false);
        Restart.gameObject.SetActive(false);
        RestartAfterDeath.gameObject.SetActive(false);
        PlayerPrefs.SetInt("LevelReached", LevelNB + 1);
        CurrrentLevelNB.text = (PlayerPrefs.GetInt("LevelReached")).ToString();
        NextLevel();
    }
    void RestartTaskOnClick()
    {
        player.Finished = false;
        player.Status.gameObject.SetActive(false);
        Tutorial.SetActive(false);
        anim1 = Restart.GetComponent<Animator>();
        anim1.SetTrigger("Press");
        player.ResetPosition();
        ResetLevel = true;
        Next.gameObject.SetActive(false);
        Restart.gameObject.SetActive(false);
        RestartAfterDeath.gameObject.SetActive(false);

        foreach (GameObject Level in LevelsList)
        {
            if (Level.activeSelf)
            {
                Level.GetComponent<LevelManager>().Restart();
            }
        }
        CurrrentLevelNB.text = (PlayerPrefs.GetInt("LevelReached")).ToString();
    }
    void RestartAfterDeathTaskOnClick()
    {
        player.Finished = false;
        player.Status.gameObject.SetActive(false);
        Tutorial.SetActive(false);
        anim1 = RestartAfterDeath.GetComponent<Animator>();
        anim1.SetTrigger("Press");
        player.ResetPosition();
        ResetLevel = true;
        Next.gameObject.SetActive(false);
        Restart.gameObject.SetActive(false);
        RestartAfterDeath.gameObject.SetActive(false);

        foreach (GameObject Level in LevelsList)
        {
            if (Level.activeSelf)
            {
                Level.GetComponent<LevelManager>().Restart();
            }
        }
        CurrrentLevelNB.text = (PlayerPrefs.GetInt("LevelReached")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CurrentLevel()
    {
        int i = 0;
        LevelNB = PlayerPrefs.GetInt("LevelReached");

        foreach (GameObject level in LevelsList)
        {
            if (i == LevelNB)
            {
                level.SetActive(true);
            }
            else
            {
                level.SetActive(false);
            }

            i++;
        }
    }

    void NextLevel()
    {
       int i = 0;
       LevelNB = PlayerPrefs.GetInt("LevelReached");
       //Debug.Log(LevelNB);

        foreach (GameObject level in LevelsList)
        {
            if (i == LevelNB - 1 && LevelNB != LevelsList.Length)
            {
                level.SetActive(false);
                level.GetComponent<LevelManager>().Delete();
            }
            else if (i == LevelNB && LevelNB != LevelsList.Length)
            {
                level.SetActive(true);
            }

            if (LevelNB == LevelsList.Length)
            {
                //PlayerPrefs.DeleteAll();
                LevelsList[LevelNB - 1].SetActive(false);
                LevelsList[LevelNB - 1].GetComponent<LevelManager>().Delete();

                LevelsList[1].SetActive(true);
                PlayerPrefs.SetInt("LevelReached", 1);
                LevelNB = PlayerPrefs.GetInt("LevelReached");
                CurrrentLevelNB.text = (PlayerPrefs.GetInt("LevelReached")).ToString();
            }

            i++;
        }
    }
}
