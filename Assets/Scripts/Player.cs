using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public static float health;
    private float startHealth = 25f;

    public Slider healthBar;
    public TextMeshProUGUI textMesh;
    // Use this for initialization
    void Start () {
        health = startHealth;
        healthBar.value = 1f;
        textMesh.SetText( "Health is: " + health + "/" + startHealth);
    }
	
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.value = health / startHealth;
        textMesh.SetText("Health is: " + health + "/" + startHealth);
        if (health <= 0)
        {
            GameObject.Destroy(this.gameObject);
            EndGame();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
