using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour {

    public Transform[] path;
    public float speed;
    public float startHealth;

    [HideInInspector]
    public float distToPoint = 1.0f;

    [Header("Back end")]
    public Slider healthBar;

    private int currentPoint = 0;
    private float health;
    private int level; 
    
    private void Start()
    {
        transform.position = path[0].position;
        health = startHealth;
        healthBar.value = 1f;
    } 

    // Update is called once per frame
    void Update () {
        UpdatePosition();
	}

    void UpdatePosition()
    {
        float dist = Vector3.Distance(path[currentPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);
        if (dist <= distToPoint)
        {
            currentPoint++;
        }
        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Health is: " + health);
        healthBar.value = health / startHealth;
        if(health <= 0)
        {
            Debug.Log("next level");
            GameObject.Destroy(this.gameObject);
            
            Die();
        }
    }

    void Die()
    {
        
        Debug.Log(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
