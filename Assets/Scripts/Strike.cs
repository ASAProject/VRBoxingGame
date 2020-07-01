using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Strike : MonoBehaviour
{
    private Joystick joystick;
    private PhotonView photonView;
   // private CapsuleCollider capsuleCollider;
    private Rigidbody rigidBody;
    private float speed = 7f;
    private GameObject LOC1,LOC2;
    private int playercount;
    public Camera camera;
    public AudioListener audioListener;
    private Animator animator;
    private bool punch;
    private Button buttonpunch;
    void Start(){
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        photonView = GetComponent<PhotonView>();
        LOC2 = GameObject.Find("LOC2");
        LOC1 = GameObject.Find("LOC1");
        playercount = PhotonNetwork.CurrentRoom.PlayerCount;
        if(!photonView.IsMine){
            camera.enabled = false;
            audioListener.enabled = false;
        }
        buttonpunch = GameObject.Find("Punch").GetComponent<Button>();
        buttonpunch.onClick.AddListener(delegate { Punch(); });
    }
    void Update(){
        
        if(photonView.IsMine){
            movement();
        }
    }
    private void movement(){
       
        var velx = joystick.Horizontal;
        var velz = joystick.Vertical;
        if (Mathf.Abs(velx)>0.01 || Mathf.Abs(velz)>0.01 ){
            print("true");
             animator.SetBool("walk",true);
             rigidBody.velocity = new Vector3(-velx * speed , rigidBody.velocity.y,-velz*speed);
        }
        else{
            print("false");
            animator.SetBool("walk",false);
        }
       if(playercount == 1){
           transform.LookAt(LOC2.transform.position);
       }
       if(playercount == 2){
           transform.LookAt(LOC1.transform.position);
       }
    }
    public void Punch(){
        if(photonView.IsMine){
        punch = true;
        animator.SetTrigger("punch");
        }
    }
}
