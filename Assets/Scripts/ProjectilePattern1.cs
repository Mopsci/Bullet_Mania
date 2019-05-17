using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePattern1 : MonoBehaviour
{

    public int numOfBullets;             //Number of projectile at spawing
    public float projectileSpeed;        //Speed of the projectile
    public float spinSpeed;              //Spining the start position of the bullets
    public float frequenecy;             //Frequency of shooting bullets
    public GameObject ProjectilePrefab;  //Projectile to spawn

    private Vector3 startPoint;
    private const float radius = 1f;
    private float angle;

    // Use this for initialization
    void Start()
    {
        angle = 0f;
        startPoint = transform.position;
        StartCoroutine(SpawnProjectiles(numOfBullets,spinSpeed, frequenecy));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnProjectiles(int numProjectile, float spin, float delay)
    {
        while (true)
        {
            startPoint = transform.position;
            float angleStep = 360f / numProjectile;
            for (int i = 0; i <= numProjectile - 1; i++)
            {
                float projectileXDirPos = startPoint.x + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
                float projectileZDirPos = startPoint.z + Mathf.Sin((angle * Mathf.PI) / 180) * radius;

                Vector3 projectileVector = new Vector3(projectileXDirPos, startPoint.y , projectileZDirPos);
                Vector3 projectileDirection = (projectileVector - startPoint).normalized * projectileSpeed;
                GameObject tmpObject = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
                tmpObject.GetComponent<Rigidbody>().velocity = new Vector3(projectileDirection.x, 0, projectileDirection.z);

                angle += angleStep;
            }
            angle += spin;
            yield return new WaitForSeconds(delay);
        }
    }
}
