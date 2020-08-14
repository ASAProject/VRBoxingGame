using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Strike : MonoBehaviourPunCallbacks, IPunObservable
{
    private Joystick joystick;
    private PhotonView photonView;
    private Rigidbody rigidBody;
    private float speed = 7f;
    private GameObject LOC1,LOC2;
    private int playercount;
    public Camera camera;
    public AudioListener audioListener;
    private Animator animator;
    private bool punch;
    private Button buttonpunch;
    private bool checkmulticollisions = false,makeexit = false;
    void Start(){
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        photonView = GetComponent<PhotonView>();
        if (photonView) photonView.ObservedComponents.Add(this);
        LOC2 = GameObject.Find("LOC2");
        LOC1 = GameObject.Find("LOC1");
        playercount = PhotonNetwork.CurrentRoom.PlayerCount;
        if(!photonView.IsMine){
            camera.enabled = false;
            audioListener.enabled = false;
        }
        buttonpunch = GameObject.Find("Punch").GetComponent<Button>();
        buttonpunch.onClick.AddListener(delegate { Punch(); });
       // buttonpunch.onClick.AddListener(StartCoroutine(AnimatorSetFire(3.0f)));
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
             animator.SetBool("walk",true);
             rigidBody.velocity = new Vector3(-velx * speed , rigidBody.velocity.y,-velz*speed);
        }
        else{
            rigidBody.velocity = new Vector3(0, 0, 0);
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
            StartCoroutine(AnimatorSetFire(2.29f));
        }
        
    }
    private IEnumerator AnimatorSetFire(float animationLength)
    {
        if(photonView.IsMine){
            punch = true;
            //animator.SetBool("punch", true);
            animator.SetTrigger("punch");
            yield return new WaitForSeconds(animationLength);
            punch = false;
            //animator.SetBool("punch", false);
        }
      
    }
     void OnTriggerEnter(Collider other) {
         if(photonView.IsMine){
             if(other.gameObject.name == "DimplesRig:LeftHandIndex1" && punch){
                checkmulticollisions = true;
                if(checkmulticollisions){
                    print("hit");
                    Health.fillamount--;
                    checkmulticollisions = false;
                } 
            }
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
         if(stream.IsWriting) {
            stream.SendNext(Health.fillamount);
         }
         else if(stream.IsReading){
             var temp = (float)stream.ReceiveNext();
            Health.enemyhealth = temp;
         }
         
     }
}
    

