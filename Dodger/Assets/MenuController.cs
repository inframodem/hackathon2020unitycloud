using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;

public class MenuController : MonoBehaviour
{
    public enum menustates { Main, HighScore};
    public menustates currstate;
    public GameObject MainMenu;
    public GameObject HighScore;
    public ScoreBoardData currscoreboard;
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    public Text score6;
    public Text score7;
    public Text score8;
    public Text score9;
    public Text score10;
    void Awake()
    {
        currstate = menustates.Main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currstate)
        {
            case menustates.Main:
                HighScore.SetActive(false);
                MainMenu.SetActive(true);
                break;
            case menustates.HighScore:
                MainMenu.SetActive(false);
                HighScore.SetActive(true);
                break;
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("MainLevel");
    }
    public void AccessScore()
    {
        RestClient.Get<ScoreBoardData>("https://hackathon-game.firebaseio.com/highscoreboard.json").Then(response =>
        {
            currscoreboard = response;
            score1.text = currscoreboard.userName1 + ":   " + currscoreboard.score1.ToString();
            score2.text = currscoreboard.userName2 + ":   " + currscoreboard.score2.ToString();
            score3.text = currscoreboard.userName3 + ":   " + currscoreboard.score3.ToString();
            score4.text = currscoreboard.userName4 + ":   " + currscoreboard.score4.ToString();
            score5.text = currscoreboard.userName5 + ":   " + currscoreboard.score5.ToString();
            score6.text = currscoreboard.userName6 + ":   " + currscoreboard.score6.ToString();
            score7.text = currscoreboard.userName7 + ":   " + currscoreboard.score7.ToString();
            score8.text = currscoreboard.userName8 + ":   " + currscoreboard.score8.ToString();
            score9.text = currscoreboard.userName9 + ":   " + currscoreboard.score9.ToString();
            score10.text = currscoreboard.userName10 + ":   " + currscoreboard.score10.ToString();
            currstate = menustates.HighScore;
        });
    }
    public void AccessMenu()
    {
        currstate = menustates.Main;
    }
}
