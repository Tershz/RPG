using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttribute : Items
{
    public static ItemAttribute Instance { get; set; }

    [Header("Use Item")]
    public int HP;
    public int MP;

    [Header("Armor")]
    public int MaxHP;
    public int MaxMP;
    public int P_Attack;
    public int M_Attack;
    public int Luck;

    [Header("Weapon")]
    public int Power;
    public int Defense;

    [Header("")]
    public string Description;
    public int SellPrice=0;
    

    public ItemAttribute(int attribute1,int attribute2,int attribute3,int attribute4,int attribute5,int attribute6,int attribute7,int attribute8,string desc)
    {

        switch (itemType)
        {
            case ItemType.ArmorWeapon:
                ArmorWeapon(attribute1, attribute2, attribute3, attribute4, attribute5, attribute6, attribute7, attribute8,desc);
                break;
            case ItemType.Material:
                Material(attribute8,desc);
                break;
            case ItemType.UseItem:
                UseItem(attribute1, attribute2, attribute8,desc);
                break;
            case ItemType.Coin:
                Coin(attribute8,desc);
                break;
        }
        
    }

    public void ArmorWeapon(int P_Attack,int M_Attack, int Luck, int Pow, int def, int increase_HP, int increase_MP,int sell,string desc)
    {
        this.P_Attack = P_Attack;
        this.M_Attack = M_Attack;
        this.Luck = Luck;

        Power = Pow;
        Defense = def;

        MaxHP = increase_HP;
        MaxMP = increase_MP;

        SellPrice = sell;
        Description = desc;
    }
    public void Material(int sell, string desc)
    {
        SellPrice = sell;
        Description = desc;
    }
    public void UseItem(int HpUp,int MpUp, int sell, string desc)
    {
        HP = HpUp;
        MP = MpUp;
        SellPrice = sell;
        Description = desc;
    }
    public void Coin(int value, string desc)
    {
        SellPrice = value;
        Description = desc;
    }

    private void Update()
    {
        
    }
}
