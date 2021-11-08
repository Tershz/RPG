using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDetail : MonoBehaviour
{
    public static InventoryDetail Intance { get; set; }

    public GameObject items;
    public GameObject itemDetail;
    public static GameObject static_itemDetail;
    public GameObject itemDetailtxt;
    public Image itemImage;
    public GameObject attributeButton;
    public static TextMeshProUGUI static_text;

    public GameObject playerpanel;

    public Image getImage;

    private void Awake()
    {
        static_itemDetail = itemDetail;
        static_text = itemDetailtxt.GetComponent<TextMeshProUGUI>();


    }

    public void click() 
    {
        Items getItem = gameObject.GetComponent<Items>();
        //cek Item
        items.GetComponent<Items>().index= getItem.index;
        items.GetComponent<Items>().level= getItem.level;
        items.GetComponent<Items>().itemName = getItem.itemName;
        items.GetComponent<Items>().itemType = getItem.itemType;
        items.GetComponent<Items>().itemAttribute = getItem.itemAttribute;
        items.GetComponent<Items>().amount = getItem.amount;
        items.GetComponent<Items>().equiped = getItem.equiped;

        attributeButton.SetActive(true);

        if (getItem.itemType == Items.ItemType.UseItem || getItem.itemType == Items.ItemType.Material )
        {
            itemDetail.transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = "Use";
        }
        else
        {
            if(getItem.equiped == false)
            {
                itemDetail.transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = "Equip";
            }else
            {
                itemDetail.transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = "Unequip";
            }
        }
        if (itemDetail.activeInHierarchy == false)
        {
            itemDetail.SetActive(true);
        }

        if(gameObject.transform.position.y <= playerpanel.transform.position.y)
        {
            Debug.LogWarning("0,1");
            itemDetail.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        }
        else
        {
            Debug.LogWarning("0,0");
            itemDetail.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        }
        itemDetail.transform.position = gameObject.transform.position;

        itemImage.sprite = getImage.sprite;
        static_text.text = "Name : " + getItem.itemName + "\nHP : " + getItem.itemAttribute.MaxHP+ "\nAmount : " + getItem.amount;

        Debug.Log(static_text.text);
        Debug.Log(getItem.itemAttribute.P_Attack);
        Debug.Log(getItem.itemName);
        
    }

    public static void closeDetail()
    {
        static_itemDetail.SetActive(false);
    }
    public static void updateDetail(Items getItem)
    {
        
        static_text.text = "Name : " + getItem.itemName + "\nHP : " + getItem.itemAttribute.MaxHP + "\nAmount : " + getItem.amount;
    }


    private void Update()
    {
        
    }
}
