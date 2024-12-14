using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDistroyScript : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy"
        || collision.gameObject.tag  == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
