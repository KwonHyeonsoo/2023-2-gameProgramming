using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStat : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public AudioSource audioSource;
    public AudioClip clip;
    [SerializeField] private Transform player;
    public float volume=0.5f;
    

    [SerializeField] private float maxHealth;

    public HealthBar healthBar;

    private float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }
    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            audioSource.PlayOneShot(clip, volume);
            Invoke("Die", 0.5f);
            //Die();
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }
    public void HealPlayer(float amount)
    {
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
    }
    private void Die()
    {
        Debug.Log("You died!");
        
        player.gameObject.GetComponent<SimpleSampleCharacterControl>().enabled = false;
        GameOverScreen.gameObject.SetActive(true);


    }
}