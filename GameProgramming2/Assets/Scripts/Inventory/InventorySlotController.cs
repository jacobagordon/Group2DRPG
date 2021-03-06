using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public Item item;

    public void Use()
    {
        if (item)
        {
            item.Use();
        }
    }

    public void updateInfo()
    {
        Text displayText = transform.Find("ItemName").GetComponent<Text>();
        Image displayImage = transform.Find("Image").GetComponent<Image>();

        if (item)
        {
            displayText.text = item.itemName;
            displayImage.sprite = item.icon;
            displayImage.color = Color.white;
        }
        else
        {
            displayText.text = "";
            displayImage.sprite = null;
            displayImage.color = Color.clear;
        }
    }

    public void Start()
    {
        updateInfo();
    }
}
