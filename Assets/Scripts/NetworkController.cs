using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkController : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if(!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
        
    }
    public override void OnConnectedToMaster(){
        Debug.Log("We are not  connect to the " + PhotonNetwork.CloudRegion + " server!");
    }
   
}
