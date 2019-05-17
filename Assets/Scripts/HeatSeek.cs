using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSeek : MonoBehaviour {
    public Transform player;
    public float speed;

    private Vector3 playerPos;
	
	// Update is called once per frame
	void Update () {
        LockOnPlayer();
    }

    void LockOnPlayer()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        transform.LookAt(player.position);
        Debug.DrawRay(transform.forward, player.position, Color.black);
    }
    
}
