using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    
    [SerializeField]
    private Transform itemRB;
    [SerializeField]
    private Transform itemSlotTemplate;
    public Transform getChild;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChange += Inventory_OnListChange;
        RefreshInventory();
    }

    private void Inventory_OnListChange(object sender, EventArgs e)
    {
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        foreach(Transform child in itemRB)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }


        foreach (Items item in inventory.GetItemList())
        {
            Transform newItem = Instantiate(itemSlotTemplate, itemRB);
            newItem.gameObject.SetActive(true);

            Image itemImage = newItem.GetChild(0).GetChild(1).GetComponent<Image>();
            itemImage.sprite = item.GetSprite();

            newItem.name = item.itemName;

            newItem.GetComponent<Items>().index = item.index;
            newItem.GetComponent<Items>().level = item.level;
            newItem.GetComponent<Items>().itemName = item.itemName;
            newItem.GetComponent<Items>().itemType = item.itemType;
            newItem.GetComponent<Items>().itemAttribute = item.itemAttribute;
            newItem.GetComponent<Items>().amount = item.amount;
            newItem.GetComponent<Items>().equiped = item.equiped;

            TextMeshProUGUI amounttxt = newItem.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI lvtxt = newItem.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();

            if (item.amount <= 1)
            {
                amounttxt.text = "";
            }
            else
            {
                amounttxt.text = item.amount.ToString();
            }
            if (item.level == 0)
            {
                lvtxt.text = "";
            }
            else
            {
                lvtxt.text = "Lv." + item.level.ToString();
            }


        }
    }

}
