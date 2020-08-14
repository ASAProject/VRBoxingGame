using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class Waiting : MonoBehaviour
{
    private int playercount = 0;

    void Update()
    {
        playercount = PhotonNetwork.CurrentRoom.PlayerCount;
        if(playercount == 2){
            SceneManager.LoadScene("Callforboxing");
        }
    }
}
