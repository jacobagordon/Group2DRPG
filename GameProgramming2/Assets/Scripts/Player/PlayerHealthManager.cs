using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    int playerMaxHealth;
    [SerializeField]
    int playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

    }

    public void DamageToPlayer(int damage)
    {
        playerCurrentHealth -= damage;
    }

    public void HealPlayer(int health)
    {
        playerCurrentHealth += health % playerMaxHealth;
    }

    void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
