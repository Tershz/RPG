using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBtn : MonoBehaviour
{
    public GameObject item;
    public TextMeshProUGUI money;
    public GameObject PlayerControll;
    public GameObject InventoryDetail;
    public static GameObject static_Detail;
    private PlayerControl newPlayerControll;

    private void Awake()
    {
         newPlayerControll = PlayerControll.GetComponent<PlayerControl>();
        
    }
    public void sellItem()
    {
        static_Detail = InventoryDetail;
        int getmoney = Convert.ToInt32(money.text);
        Items getItem = item.GetComponent<Items>();

        getmoney += getItem.itemAttribute.SellPrice;
        money.text = getmoney.ToString();
        Debug.Log("item: " + getItem.name);
        newPlayerControll.SellItem(getItem);

    }
    public void EquipUse(GameObject btn)
    {
        Text btnTxt = btn.transform.GetChild(0).GetComponent<Text>();
        Items getItem = item.GetComponent<Items>();
        if (getItem.itemType != Items.ItemType.UseItem || getItem.itemType != Items.ItemType.Material)
        {
            Debug.LogWarning("Equip");

            newPlayerControll.EquipItem(getItem,btnTxt.text,btn);

        }
        else
        {
            btnTxt.text = "Use";
        }
       
    }

    public static void CloseItemDetail()
    {
        static_Detail.SetActive(false);
    }
}
