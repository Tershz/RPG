using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Equip : MonoBehaviour
{
    public GameObject playerAttribute;
    public GameObject playerControl;

    private PlayerControl newPlayerControl;
    private UI_PlayerAttribute newPlayerAttribute;
    private GameObject playerEquipment;
    private Items getItem;
    private Items equpmentItem;
    private TextMeshProUGUI equpmentLV;
    private Image playerEquipment_img;




    private void Awake()
    {
        newPlayerControl = playerControl.GetComponent<PlayerControl>();
        playerEquipment = playerAttribute.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
        newPlayerAttribute = playerAttribute.GetComponent<UI_PlayerAttribute>();

      
    }
    private void setItem(Items item)
    {
        equpmentItem.itemName = item.itemName;
        equpmentItem.amount = item.amount;
        equpmentItem.index = item.index;
        equpmentItem.equiped = item.equiped;
        equpmentItem.itemAttribute = item.itemAttribute;
        equpmentItem.itemType = item.itemType;
        equpmentItem.level = item.level;
        equpmentLV.gameObject.SetActive(true);
        equpmentLV.text ="LV."+ item.level;
    }
    void Update()
    {
         

        getItem = gameObject.GetComponent<Items>();
        if (getItem.equiped == true)
        {
            //image equiped
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            switch (getItem.itemType)
            {
                case Items.ItemType.HeadArmor:
                    equpmentItem = playerEquipment.transform.GetChild(0).GetComponent<Items>();
                    equpmentLV = playerEquipment.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
                    playerEquipment_img=playerEquipment.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>();

                    setItem(getItem);
                    playerEquipment_img.sprite = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                    playerEquipment_img.color = Color.white;
                    break;
                case Items.ItemType.BodyArmor:
                    equpmentItem = playerEquipment.transform.GetChild(1).GetComponent<Items>();
                    equpmentLV = playerEquipment.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
                    playerEquipment_img = playerEquipment.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>();

                    setItem(getItem);
                    playerEquipment_img.sprite = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                    playerEquipment_img.color = Color.white;
                    break;
                case Items.ItemType.HandArmor:
                    equpmentItem = playerEquipment.transform.GetChild(2).GetComponent<Items>();
                    equpmentLV = playerEquipment.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
                    playerEquipment_img = playerEquipment.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>();

                    setItem(getItem);
                    playerEquipment_img.sprite = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                    playerEquipment_img.color = Color.white;
                    break;
                case Items.ItemType.FootArmor:
                    equpmentItem = playerEquipment.transform.GetChild(3).GetComponent<Items>();
                    equpmentLV = playerEquipment.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
                    playerEquipment_img = playerEquipment.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>();

                    setItem(getItem);
                    playerEquipment_img.sprite = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                    playerEquipment_img.color = Color.white;
                    break;
                case Items.ItemType.Accessories:
                    equpmentItem = playerEquipment.transform.GetChild(4).GetComponent<Items>();
                    equpmentLV = playerEquipment.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
                    playerEquipment_img = playerEquipment.transform.GetChild(4).GetChild(0).gameObject.GetComponent<Image>();
                    if (equpmentItem!= null)
                    {
                        equpmentItem = playerEquipment.transform.GetChild(5).GetComponent<Items>();
                        equpmentLV = playerEquipment.transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>();
                        playerEquipment_img = playerEquipment.transform.GetChild(5).GetChild(0).gameObject.GetComponent<Image>();
                    }

                    setItem(getItem);
                    playerEquipment_img.sprite = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                    playerEquipment_img.color = Color.white;
                    break;
                case Items.ItemType.Weapon:
                    equpmentItem = playerEquipment.transform.GetChild(7).GetComponent<Items>();
                    equpmentLV = playerEquipment.transform.GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>();
                    playerEquipment_img = playerEquipment.transform.GetChild(7).GetChild(0).gameObject.GetComponent<Image>();

                    setItem(getItem);
                    playerEquipment_img.sprite = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                    playerEquipment_img.color = Color.white;
                    break;
                case Items.ItemType.Shield:
                    equpmentItem = playerEquipment.transform.GetChild(6).GetComponent<Items>();
                    equpmentLV = playerEquipment.transform.GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>();
                    playerEquipment_img = playerEquipment.transform.GetChild(6).GetChild(0).gameObject.GetComponent<Image>();

                    setItem(getItem);
                    playerEquipment_img.sprite = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                    playerEquipment_img.color = Color.white;
                    break;
            }
        }
        
        
    }
}
