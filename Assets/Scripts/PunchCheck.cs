using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCheck : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}
