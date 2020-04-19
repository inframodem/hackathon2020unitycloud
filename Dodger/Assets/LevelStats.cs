using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;

public class LevelStats : MonoBehaviour
{
    public int health;
    public int score;
    public float timer;
    public float timerstart;
    public Text scoredisplay;
    public Text healthdisplay;
    public GameObject player;
    public bool isdead;
    public GameObject ScoreHolder;
    public Text UserNameInput;
    public bool databaseactive;
    public ScoreBoardData currscoreboard;
    public string username;
    public int bestfit = -1;
    public int pass;
    // Start is called before the first frame update
    void Start()
    {
        isdead = false;
        timer = timerstart;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f && !isdead)
        {
            score += 10;
            timer = timerstart;
        }
        scoredisplay.text = "Score: " + score;
        healthdisplay.text = "Health: " + health;
        if(health <= 0)
        {
            isdead = true;
            Destroy(player);
            ScoreHolder.SetActive(true);
        }
    }

    public void SubmitScore()
    {
        username = UserNameInput.text;

        PostToDatabase();
            
        BacktoMenu();
 
        
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    private void PostToDatabase()
    {
        
        
        RestClient.Get<ScoreBoardData>("https://hackathon-game.firebaseio.com/highscoreboard.json").Then(response =>
            {
                currscoreboard = response;
                pass = currscoreboard.getscore(1);
                
                int[] currscores = new int[]
                { currscoreboard.score1, currscoreboard.score2, currscoreboard.score3, currscoreboard.score4,
            currscoreboard.score5, currscoreboard.score6, currscoreboard.score7, currscoreboard.score8, currscoreboard.score9, currscoreboard.score10 };
                string[] currnames = new string[]
                { currscoreboard.userName1, currscoreboard.userName2, currscoreboard.userName3, currscoreboard.userName4,
            currscoreboard.userName5, currscoreboard.userName6, currscoreboard.userName7, currscoreboard.userName8, currscoreboard.userName9, currscoreboard.userName10 };
                for (int i = currscores.Length - 1; i >= 0; i--)
                {
                    Debug.Log(currscores[i]);
                }
                for (int i = currscores.Length - 1; i >= 0; i--)
                {
                    if (score > currscores[i])
                    {
                        bestfit = i;
                    }
                }
                if (bestfit > -1)
                {
                    for (int i = currscores.Length - 2; i >= bestfit; i--)
                    {
                        currscores[i + 1] = currscores[i];
                    }
                    for (int i = currnames.Length - 2; i >= bestfit; i--)
                    {
                        currnames[i + 1] = currnames[i];
                    }
                    currscores[bestfit] = score;
                    currnames[bestfit] = username;
                    currscoreboard.score1 = currscores[0];
                    currscoreboard.score2 = currscores[1];
                    currscoreboard.score3 = currscores[2];
                    currscoreboard.score4 = currscores[3];
                    currscoreboard.score5 = currscores[4];
                    currscoreboard.score6 = currscores[5];
                    currscoreboard.score7 = currscores[6];
                    currscoreboard.score8 = currscores[7];
                    currscoreboard.score9 = currscores[8];
                    currscoreboard.score10 = currscores[9];

                    currscoreboard.userName1 = currnames[0];
                    currscoreboard.userName2 = currnames[1];
                    currscoreboard.userName3 = currnames[2];
                    currscoreboard.userName4 = currnames[3];
                    currscoreboard.userName5 = currnames[4];
                    currscoreboard.userName6 = currnames[5];
                    currscoreboard.userName7 = currnames[6];
                    currscoreboard.userName8 = currnames[7];
                    currscoreboard.userName9 = currnames[8];
                    currscoreboard.userName10 = currnames[9];


                    RestClient.Put("https://hackathon-game.firebaseio.com/highscoreboard.json", currscoreboard);
                }
            });
        
         
        
        

        

        

    }

}
