using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Strike : MonoBehaviour
{
    private PhotonView photonView;
   // private CapsuleCollider capsuleCollider;
    private Rigidbody rigidBody;
    private float speed = 25f;
    void Start(){
        //capsuleCollider = GetComponent<CapsuleCollider>();
        photonView = GetComponent<PhotonView>();
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update(){
        if(photonView.IsMine){
            movement();
        }
    }
    private void movement(){
        if(Input.GetKey(KeyCode.W)){
            //capsuleCollider.transform.Translate(transform.forward * speed );
            //.SimpleMove(transform.forward * Time.deltaTime * 25f);
            rigidBody.MovePosition(transform.forward * speed);
        }
        if(Input.GetKey(KeyCode.S)){
             //capsuleCollider.transform.Translate(-transform.forward* speed );
             //characterController.SimpleMove(-transform.forward * Time.deltaTime * 25f);
             rigidBody.MovePosition(-transform.forward * speed);
        }
        if(Input.GetKey(KeyCode.A)){
             //capsuleCollider.transform.Translate(-transform.right* speed );
             //characterController.SimpleMove(transform.right * Time.deltaTime * 25f);
             rigidBody.MovePosition(-transform.right * speed);
        }
        if(Input.GetKey(KeyCode.D)){
             //capsuleCollider.transform.Translate(transform.right* speed );
              //characterController.SimpleMove(-transform.right * Time.deltaTime * 25f);
              rigidBody.MovePosition(transform.right * speed);
        }
    }
}
