using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRoomString : MonoBehaviour
{
    public static string roomname;
    public static int playercount;
    void Start(){
        DontDestroyOnLoad(this.gameObject);
    }
   
}
