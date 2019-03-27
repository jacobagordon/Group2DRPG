using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv = new List<Item>();

    public GameObject player;
    public GameObject inventoryPanel;

    public static Inventory instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        updatePanelSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updatePanelSlot()
    {
        int index = 0;
        foreach (Transform child in inventoryPanel.transform)
        {
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < inv.Count)
            {
                slot.item = inv[index];
            }
            else
            {
                slot.item = null;
            }

            slot.updateInfo();
            index++;
        }
    }


    public void Add(Item item)
    {
        if (inv.Count < 4)
        {
            if (inv.Contains(item))
            {
                Item i = inv.Find(a => a == item);
                i.count++;
            }
            else
            {
                inv.Add(item);
            }
        }
        updatePanelSlot();
    }

    public void Remove(Item item)
    {
        inv.Remove(item);
        updatePanelSlot();
    }
}
