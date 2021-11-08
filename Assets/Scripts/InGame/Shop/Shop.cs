using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject panel;
    public PlayerControl newPlayerControl;
    public Transform shoptamplate;
    public Transform templateParent;
    public Button refreshBtn;
    private Transform shopitem;

    public TextMeshProUGUI timeText;
    public float timeRemaining;
    private float settime;
    public bool timerIsRunning = false;

    private void Awake()
    {
        
        settime = timeRemaining;
    }
    // Start is called before the first frame update
    void Start()
    {
        setShop();
        timerIsRunning = true;
        refreshBtn.enabled = false;
    }

    public void setShop()
    {
        foreach(Transform item in templateParent)
        {
            Destroy(item.gameObject);
        }
        for (int i = 0; i < 9; i++)
        {
            shopitem = Instantiate(shoptamplate, templateParent);
            shopitem.name = "item" + (i + 1);
            shopitem.gameObject.SetActive(true);
            int RandomVar = Random.Range(0, 4);
            Items newitem = shopitem.GetComponent<Items>();
            newitem = ItemAsset.AllItem[RandomVar];
            shopitem.GetComponent<Items>().itemName = newitem.itemName;
            shopitem.GetComponent<Items>().itemAttribute = newitem.itemAttribute;
            shopitem.GetComponent<Items>().itemType = newitem.itemType;
            shopitem.GetComponent<Items>().level = newitem.level;
            shopitem.GetComponent<Items>().amount = newitem.amount;
            shopitem.GetComponent<Items>().equiped = newitem.equiped;
            shopitem.GetChild(0).GetComponent<Image>().sprite = newitem.GetSprite();
            shopitem.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + newitem.itemAttribute.SellPrice;
        }
    }
    public void refreshTime()
    {
        timeRemaining = settime;
        timerIsRunning = true;
        refreshBtn.enabled = false;
        setShop();
    }
    public void buy(GameObject item)
    {
        item.transform.GetChild(2).gameObject.SetActive(true);
        item.transform.GetChild(1).GetComponent<Button>().enabled = false;
        newPlayerControl.getItem(item.GetComponent<Items>());
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                refreshBtn.enabled = true;
            }
        }
    }
    public void close()
    {
        panel.SetActive(false);
    }
}
