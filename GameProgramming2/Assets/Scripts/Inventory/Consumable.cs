using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Consumable")]
public class Consumable : Item
{
    public int healAmt = 5;

    public override void Use()
    {
        Debug.Log("Player used a consumable");
        // Get Player Health
        GameObject player = Inventory.instance.player;
        PlayerHealthManager PlayerHealth = player.GetComponent<PlayerHealthManager>();

        // Heal Player

        Debug.Log(itemName);
        if(itemName == "Green Potion")
        {
            PlayerHealth.HealPlayer(2);
        }
        else if(itemName == "Blue Potion")
        {
            PlayerHealth.HealPlayer(5);
        }
        else if(itemName == "Red Potion")
        {
            PlayerHealth.HealPlayer(7);
        }
        else if(itemName == "Gold Potion")
        {
            PlayerHealth.HealPlayer(10);
        }

        // Remove Potion
        Inventory.instance.Remove(this);
    }
}
