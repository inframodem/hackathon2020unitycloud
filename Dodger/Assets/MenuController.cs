using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public enum menustates { Main, HighScore};
    public menustates currstate;
    public GameObject MainMenu;
    public GameObject HighScore;

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
        currstate = menustates.HighScore;
    }
    public void AccessMenu()
    {
        currstate = menustates.Main;
    }
}
