using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePattern2 : MonoBehaviour {

    public int numOfBullets;             //Number of projectile at spawing
    public float projectileSpeed;        //Speed of the projectile
    public float spreadAngle;            //Spread of random pattern
    public float frequenecy;             //Frequency of shooting bullets
    public GameObject ProjectilePrefab;  //Projectile to spawn
    public Transform player;

    private Vector3 playerPos; 
    private Vector3 startPoint;
    private const float radius = 1f;

    // Use this for initialization
    void Start()
    {
        startPoint = transform.position;
        StartCoroutine(SpawnRandomProjectiles(numOfBullets, frequenecy));
    }

    IEnumerator SpawnRandomProjectiles(int numProjectile, float delay)
    {

        while (true)
        {
            playerPos = player.position;
            startPoint = transform.position;
            for (int i = 0; i <= numProjectile - 1; i++)
            {

                Vector3 playerDirection = (playerPos - startPoint).normalized * projectileSpeed;
                //set Vector back to beginning of spread
                float angleBack = -spreadAngle / 2;
                float startXDirPos = (playerDirection.x * Mathf.Cos((angleBack * Mathf.PI) / 180)) - (playerDirection.z * Mathf.Sin((angleBack * Mathf.PI) / 180));
                float startZDirPos = (playerDirection.x * Mathf.Sin((angleBack * Mathf.PI) / 180)) + (playerDirection.z * Mathf.Cos((angleBack * Mathf.PI) / 180));
                Vector3 projectileStartVector = new Vector3(startXDirPos, startPoint.y, startZDirPos);

                //translate vector forward by random amount
                float projectileXDirPos = (projectileStartVector.x * Mathf.Cos((spreadAngle * Random.value * Mathf.PI) / 180)) - (projectileStartVector.z * Mathf.Sin((spreadAngle * Random.value * Mathf.PI) / 180));
                float projectileZDirPos = (projectileStartVector.x * Mathf.Sin((spreadAngle * Random.value * Mathf.PI) / 180)) + (projectileStartVector.z * Mathf.Cos((spreadAngle * Random.value * Mathf.PI) / 180));
                Vector3 projectileVector = new Vector3(projectileXDirPos, startPoint.y, projectileZDirPos);

                projectileVector = projectileVector.normalized * projectileSpeed;
                GameObject tmpObject = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
                tmpObject.GetComponent<Rigidbody>().velocity = new Vector3(projectileVector.x, 0, projectileVector.z);

            }
            yield return new WaitForSeconds(delay);
        }
    }

    
}
