using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ScoreBoardData : Mono
{
    public string userName1;
    public int score1;
    public string userName2;
    public int score2;
    public string userName3;
    public int score3;
    public string userName4;
    public int score4;
    public string userName5;
    public int score5;
    public string userName6;
    public int score6;
    public string userName7;
    public int score7;
    public string userName8;
    public int score8;
    public string userName9;
    public int score9;
    public string userName10;
    public int score10;

    public int getscore(int input)
    {
        switch (input){
            case 1:
                return score1;
                break;
            case 2:
                return score2;
                break;
            case 3:
                return score3;
                break;
            case 4:
                return score4;
                break;
            case 5:
                return score5;
                break;
            case 6:
                return score6;
                break;
            case 7:
                return score7;
                break;
            case 8:
                return score8;
                break;
            case 9:
                return score9;
                break;
            case 10:
                return score10;
                break;
        }
        return -1;
    }
}