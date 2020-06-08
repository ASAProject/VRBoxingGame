using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    private int count = 0;
    [SerializeField]
    private GameObject quickStartButton;
    [SerializeField]
    private GameObject quickCancelButton;
    private int RoomSize;
    public string roomname;
    public override void OnConnectedToMaster(){
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }
    void Start(){
        count =0;
    }
    void Update(){
        if(PhotonNetwork.CurrentRoom.Name != null && count ==0){
            JoinedRoom();
            count++;
        }
    }
    public void QuickStart(){
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick start");
    }
    public void JoinedRoom(){
        print("running");
        SaveRoomString.roomname = PhotonNetwork.CurrentRoom.Name;
        Debug.Log(PhotonNetwork.CurrentRoom.Name+ "joined");
    }
    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log("Failed to join a room");
        CreateRoom();
    }
    void CreateRoom(){
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0,10000);
        RoomOptions roomOps =  new RoomOptions(){IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        roomname = "Room" + randomRoomNumber;
        PhotonNetwork.CreateRoom(roomname, roomOps);
        SaveRoomString.roomname = roomname;
        Debug.Log(roomname);
    }

    public override void OnCreateRoomFailed(short returnCode, string message){
        Debug.Log("Failed to create room... trying again");
        CreateRoom();
    }

    public void QuickCancel(){
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}