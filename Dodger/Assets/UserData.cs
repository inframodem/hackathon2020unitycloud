using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData
{
    public string userName;
    public int score;
    // Start is called before the first frame update
    public UserData(string user, int newscore)
    {
        userName = user;
        score = newscore;
    }

    public string getUserName()
    {
        return userName;
    }

    public int getScore()
    {
        return score;
    }
}
