using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
