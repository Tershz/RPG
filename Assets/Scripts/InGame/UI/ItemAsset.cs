using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemAsset : MonoBehaviour
{
    public static ItemAsset Instance { get; private set; }
    public static List<Items> AllItem = new List<Items>();


    private void Awake()
    {
        Instance = this;
        ReadAsset();
    }

    public Transform pfItemWorld;

    [Header("Item Image Input")]
    public Sprite WariorArmor;
    public Sprite WariorHelm;
    public Sprite WariorGlove;
    public Sprite WariorBoots;
    public Sprite WariorShield;
    public Sprite WariorSword;
    public Sprite WariorRing;
    public Sprite ChainArmor;
    public Sprite Boots;
    public Sprite HealthPotion;
    public Sprite ManaPotion;
    public Sprite Coin;

    public void ReadAsset()
    {
        string path = "Assets/TextFile/ItemAsset.txt";
        FileInfo theSourceFile = new FileInfo(path);
        StreamReader reader = theSourceFile.OpenText();
        string readLine;
        string note = "//";
        do
        {
            readLine = reader.ReadLine();
            if (readLine == null || readLine.Contains(note) )
            {
                continue;
            }
            else
            {
                string[] readWord = readLine.Split(new string[] {","}, System.StringSplitOptions.None);
                print(readWord[0]);
                
                if(readWord[1] == "ArmorWeapon")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.ArmorWeapon,
                        amount =1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }
                else if (readWord[1] == "Material")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.Material,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "UseItem")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.UseItem,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "Coin")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.UseItem,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "HeadArmor")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.HeadArmor,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "HandArmor")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.HandArmor,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "FootArmor")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.FootArmor,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "Shield")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.Shield,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "Weapon")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.Weapon,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "Accessories")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.Accessories,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }else if (readWord[1] == "BodyArmor")
                {
                    AllItem.Add(new Items
                    {
                        itemName = readWord[0],
                        itemType = Items.ItemType.BodyArmor,
                        amount = 1,
                        itemAttribute = new ItemAttribute(Convert.ToInt32(readWord[2]), Convert.ToInt32(readWord[3]), Convert.ToInt32(readWord[4]), Convert.ToInt32(readWord[5]), Convert.ToInt32(readWord[6]), Convert.ToInt32(readWord[7]), Convert.ToInt32(readWord[8]), Convert.ToInt32(readWord[9]), readWord[10])
                    });
                }
                print("All Item List: "+AllItem.Count);
            }

        } while (readLine != null);
    }


}
