using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePattern3 : MonoBehaviour {

    public int numOfBullets;             //Number of projectile at spawing
    public float projectileSpeed;        //Speed of the projectile
    public float frequenecy;             //Frequency of shooting bullets
    public GameObject ProjectilePrefab;  //Projectile to spawn

    private Vector3 startPoint;

    // Use this for initialization
    void Start()
    {
        startPoint = transform.position;
        StartCoroutine(SpawnProjectiles(numOfBullets, frequenecy));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnProjectiles(int numProjectile, float delay)
    {
        while (true)
        {
            startPoint = transform.position;
            for (int i = 0; i <= numProjectile - 1; i++)
            {
                float angle = 360 * Random.value;
                float projectileXDirPos = startPoint.x + Mathf.Cos((angle * Mathf.PI) / 180);
                float projectileZDirPos = startPoint.z + Mathf.Sin((angle * Mathf.PI) / 180);

                Vector3 projectileVector = new Vector3(projectileXDirPos, startPoint.y, projectileZDirPos);
                Vector3 projectileDirection = (projectileVector - startPoint).normalized * projectileSpeed;
                GameObject tmpObject = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
                tmpObject.GetComponent<Rigidbody>().velocity = new Vector3(projectileDirection.x, 0, projectileDirection.z);
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
