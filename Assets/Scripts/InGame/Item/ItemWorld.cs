using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ItemWorld : MonoBehaviour
{

    private Items item;
    private SpriteRenderer spriteRenderer;

    public static ItemWorld SpawnItemWorld(Vector3 position,Items item,Transform parent,int level)
    {
        
        item.level= level;

        Transform transform = Instantiate(ItemAsset.Instance.pfItemWorld, position,Quaternion.identity,parent);
        transform.tag = "Item";
        transform.gameObject.SetActive(true);
        transform.gameObject.name= item.itemName;
        transform.gameObject.GetComponent<Items>().index = 0;
        transform.gameObject.GetComponent<Items>().itemName = item.itemName;
        transform.gameObject.GetComponent<Items>().itemType = item.itemType;
        transform.gameObject.GetComponent<Items>().itemAttribute = item.itemAttribute;
        transform.gameObject.GetComponent<Items>().amount = item.amount;
        transform.gameObject.GetComponent<Items>().level = level;


        /*Debug.Log("Clone" + transform.gameObject.GetComponent<Items>().itemAttribute.SellPrice + "Real" + item.itemAttribute.SellPrice);*/

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }


    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Items items)
    {
        this.item = items;
        
        spriteRenderer.sprite = items.GetSprite();
    }

    public Items GetItem()
    {
        return item;
    }
    

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
