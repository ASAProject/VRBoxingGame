using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{
    public GameObject LOC1,LOC2;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }
    private void CreatePlayer(){
        Debug.Log("Creating Player");
        if(!PositionCheck.reserved){
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","Dimples"),LOC1.transform.position,Quaternion.identity);
        PositionCheck.reserved = true;
        }
        else{
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","Dimples"),LOC2.transform.position,Quaternion.identity);
        PositionCheck.reserved = true;
        }
    }
}
