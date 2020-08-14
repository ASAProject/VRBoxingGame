using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHandler : MonoBehaviour
{
    public Text highscore,currentscore;
    private GameObject PhotonMono,RoomName;
    void Start()
    {
        
        var tempscore = PlayerPrefs.GetString("win");
        currentscore.text = tempscore;
           RoomName = GameObject.Find("RoomName");
            Destroy(RoomName);
    }
}
