using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnItemListChange;
    public List<Items> itemList =new List<Items>();
    public List<int> listId = new List<int>();
    public int newItemId;

    public Inventory()
    {
        itemList = new List<Items>();
        listId = new List<int>();
    }

    public int newID(Items getItem) 
    {
        newItemId = 0;
        bool exitLoop = false;
        do
        {
            if (listId.Contains(newItemId))
            {
                newItemId += 1;
            }
            else
            {
                exitLoop = true;
                listId.Add(newItemId);
            }

        } while (exitLoop != true);
        return newItemId;
    }

    public void AddItem(Items item)
    {
        if (item.itemName != "Coin")
        {
            if (item.IsStackable())
            {
                bool isAllreadyinInventory = false;
                foreach (Items inventoryItem in itemList)
                {
                    if (inventoryItem.itemName == item.itemName)
                    {
                        inventoryItem.amount += item.amount;
                        isAllreadyinInventory = true;
                    }

                }
                if (isAllreadyinInventory == false)
                {
                    /*item.index = itemList.Count();*/
                    item.index = newID(item);
                    itemList.Add(item);
                    Debug.LogWarning("Item ID : " + item.index);
                }
            }
            else
            {
                item.index = newID(item);
                /*item.index = itemList.Count();*/
                itemList.Add(item);
                Debug.LogWarning("Item ID : " + item.index);
            }
        }
        else
        {
            TextMeshProUGUI money = GameObject.Find("Canvas").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>(); 
            int getMoney = Convert.ToInt32(money.text);
            Debug.Log("MoneyBefore:"+getMoney);
            getMoney += item.itemAttribute.SellPrice;
            Debug.Log("Money"+getMoney);
            money.text = getMoney.ToString();
        }
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    public void SellItem(Items item)
    {
        if (item.IsStackable())
        {
            bool isDone = false;
            Items IteminInventory = null;
            int i = 0;
            do
            {
                if (itemList[i].itemName == item.itemName)
                {
                    IteminInventory = itemList[i];
                    itemList[i].amount -= 1;
                    Debug.Log("Sell Item Amount: " + itemList[i].amount);
                    Debug.Log("ItemInventory: " + IteminInventory.itemName);
                    OnItemListChange?.Invoke(this, EventArgs.Empty);
                    InventoryDetail.updateDetail(IteminInventory);
                    if (IteminInventory.amount<=0 )
                    {
                        itemList.RemoveAt(i);
                        listId.Remove(itemList[i].index);
                        isDone = true;
                        Debug.Log("Inventory Count: " + itemList.Count);
                        InventoryDetail.closeDetail();
                        OnItemListChange?.Invoke(this, EventArgs.Empty);
                        return;
                    }
                }
                i++;
            } while (isDone == true || i <= itemList.Count - 1);

        }
        else
        {
            bool IteminInventory = false;
            int i = 0;
            do
            {
                if (itemList[i].index == item.index)
                {
                    itemList[i].amount -= 1;
                    Debug.Log("Sell Item Amount: " + itemList[i].amount);
                    listId.Remove(itemList[i].index);
                    itemList.RemoveAt(i);
                    IteminInventory = true;
                    Debug.Log("Inventory Count: " + itemList.Count);
                    OnItemListChange?.Invoke(this, EventArgs.Empty);
                    InventoryDetail.closeDetail();
                    break;
                }
                i++;
            } while (IteminInventory = true || i<=itemList.Count-1);
        }
        

    }
   
    public void EquipItem(Items item)
    {
        bool IteminInventory = false;
        int i = 0;
        do
        {
            if (itemList[i].index == item.index)
            {
                if (itemList[i].equiped == true)
                {
                    itemList[i].equiped = false;
                }
                else
                {
                    foreach (Items newItem in itemList)
                    {
                        if (newItem.itemType == itemList[i].itemType)
                        {
                            newItem.equiped = false;
                        }
                    }
                    itemList[i].equiped = true;
                }
                IteminInventory = true;
                OnItemListChange?.Invoke(this, EventArgs.Empty);
                InventoryDetail.closeDetail();
                break;
            }
            i++;
        } while (IteminInventory = true || i <= itemList.Count - 1);

    }
    public void useItem(Items item)
    {
        
    }

    public List<Items> GetItemList()
    {
        return itemList;
    }
}
