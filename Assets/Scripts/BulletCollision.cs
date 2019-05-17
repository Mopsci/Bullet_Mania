using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

    //public GameObject playerObj;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Despawner")
        {
            GameObject.Destroy(this.gameObject);
        }

        if(other.tag == "Damage")
        {
            //TODO: Add Damage

            other.GetComponent<Player>().TakeDamage(1f);
            GameObject.Destroy(this.gameObject);
        }
    }

}
