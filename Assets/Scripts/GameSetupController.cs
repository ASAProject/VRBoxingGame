using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{
    public GameObject LOC1,LOC2;
    private GameObject go;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }
    private void CreatePlayer(){
        Debug.Log("Creating Player");
        var tempcount = PhotonNetwork.CurrentRoom.PlayerCount;
        print(tempcount);
        if(tempcount == 1){
        go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","Dimples"),LOC1.transform.position,LOC1.transform.rotation);
        PositionCheck.reserved = true;
        }
        if(tempcount ==2){
        go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","Dimples"),LOC2.transform.position,LOC2.transform.rotation);
        PositionCheck.reserved = true;
        }
        animator = GetComponentInChildren<Animator>();
    }
}
