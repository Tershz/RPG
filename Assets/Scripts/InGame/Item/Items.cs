using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Items : MonoBehaviour
{
    public enum ItemType
    {
        ArmorWeapon,
        Weapon,
        Shield,
        Accessories,
        HeadArmor,
        BodyArmor,
        HandArmor,
        FootArmor,
        Material,
        UseItem,
        Coin
    }
    

    public int index;
    public string itemName;
    public ItemType itemType;
    public ItemAttribute itemAttribute;
    public int amount;
    public int level;
    public bool equiped = false;

    public Sprite GetSprite()
    {
        switch (itemName)
        {
            default:
            case "Chain Armor":
                return ItemAsset.Instance.ChainArmor;
            case "Warior Armor":
                return ItemAsset.Instance.WariorArmor;
            case "Warior Helm":
                return ItemAsset.Instance.WariorHelm;
            case "Warior Glove":
                return ItemAsset.Instance.WariorGlove;
            case "Warior Boots":
                return ItemAsset.Instance.WariorBoots;
            case "Warior Shield":
                return ItemAsset.Instance.WariorShield;
            case "Warior Sword":
                return ItemAsset.Instance.WariorSword;
            case "Warior Ring":
                return ItemAsset.Instance.WariorRing;
            case "Boots":
                return ItemAsset.Instance.Boots;
            case "Health Potion":
                return ItemAsset.Instance.HealthPotion;
            case "Mana Potion":
                return ItemAsset.Instance.ManaPotion;
            case "Coin":
                return ItemAsset.Instance.Coin;
        }
    }
     public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.UseItem:
            case ItemType.Material:
                return true;
            case ItemType.ArmorWeapon:
            case ItemType.BodyArmor:
                return false;
        }
    }

  
}
