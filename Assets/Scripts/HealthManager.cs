using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        thePlayer = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        currentHealth -= damage;

        thePlayer.KnockBack(direction);
    }
    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }
}
