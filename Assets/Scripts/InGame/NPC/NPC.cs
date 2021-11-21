using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    public int noQuest;
    public GameObject NPCPanel;
    public GameObject newQuest;
    public GameObject parentQuest;

    //Quest Info
    private TextMeshProUGUI NPCPanelText;
    private bool queststatus;
    private bool addquests;
    private int questvarSnake;
    private int questvarSpider;
    private int questvarScorpion;

    // Start is called before the first frame update
    private void Awake()
    {
        noQuest = 0;
        queststatus = true;
        addquests = false;
        NPCPanelText = NPCPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void Interact()
    {
        NPCPanel.SetActive(true);
        if(addquests == true)
        {
            Debug.Log("Quest Status: " + queststatus);
            if (noQuest <= 5 && queststatus == true)
            {
                Debug.Log("Quest");
                noQuest += 1;
                switch (noQuest)
                {
                    case 1:
                        NPCPanelText.text = "Kill 5 Snake";
                        questvarSnake = 5;
                        questvarSpider = 0;
                        questvarScorpion = 0;
                        queststatus = false;
                        break;
                    case 2:
                        NPCPanelText.text = "Kill 5 Scorpion";
                        questvarSnake = 0;
                        questvarSpider = 0;
                        questvarScorpion = 5;
                        queststatus = false;
                        break;
                    case 3:
                        NPCPanelText.text = "Kill 5 Spider";
                        questvarSnake = 0;
                        questvarSpider = 5;
                        questvarScorpion = 0;
                        queststatus = false;
                        break;
                    case 4:
                        NPCPanelText.text = "Kill 5 Snake and Kill 5 Scorpion";
                        questvarSnake = 5;
                        questvarSpider = 0;
                        questvarScorpion = 5;
                        queststatus = false;
                        break;
                    case 5:
                        NPCPanelText.text = "Kill 5 Snake,Kill 5 Scorpion,and Kill 5 Spider";
                        questvarSnake = 5;
                        questvarSpider = 5;
                        questvarScorpion = 5;
                        queststatus = false;
                        break;
                    case 6:
                        NPCPanelText.text = "Kill The Boss";
                        queststatus = false;
                        break;
                }

            }addquests = false;
        }
        
        
    }
    public void addQuest()
    {
        string temp;
        GameObject acceptQuest = Instantiate(newQuest, parentQuest.transform);
        acceptQuest.name = "Quest" + noQuest;
        acceptQuest.SetActive(true);
        TextMeshProUGUI getText = acceptQuest.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        getText.text = NPCPanelText.text;
        if (questvarSnake != 0)
        {
            temp = getText.text;
            getText.text = temp + "\nSnake "+ (5-questvarSnake)+"/" + 5;
        }
        if (questvarSpider != 0)
        {
            temp = getText.text;
            getText.text = temp + "\nSpider " + (5 - questvarSpider) +"/"+5;
        }
        if (questvarScorpion != 0)
        {
            temp = getText.text;
            getText.text = temp + "\nScorpion " + (5 - questvarScorpion) + "/" + 5;
        }
        NPCPanel.SetActive(false);
        addquests = true;
    }
    public void decline()
    {
        NPCPanel.SetActive(false);
    }
    public void UpdateQuest(string EnemyName)
    {
        foreach (Transform child in parentQuest.transform)
        {
            TextMeshProUGUI childText = child.GetChild(0).GetComponent<TextMeshProUGUI>();
            GameObject childStatus = child.GetChild(1).gameObject;
            string[] newText = childText.text.Split('\n');
            string temp;
            if (child.name == "Quest" + noQuest)
            {
                if (queststatus == false)
                {
                    if (EnemyName == "Snake")
                    {
                        questvarSnake -= 1;
                        for (int i = 0; i < newText.Length; i++)
                        {
                            if (i == 0)
                            {
                                childText.text = newText[i];
                            }
                            if (newText[i] == "Snake " + (6 - questvarSnake) + "/5")
                            {
                                temp = childText.text;
                                childText.text = temp + "\n" + "Snake " + (5 - questvarSnake) + "/5";
                                Debug.Log("Kill Snake");
                            }
                            else
                            {
                                temp = childText.text;
                                childText.text = "\n" + newText[i];
                            }
                        }
                    }
                    else if (EnemyName == "Spider")
                    {
                        questvarSpider -= 1;
                        for (int i = 0; i < newText.Length; i++)
                        {
                            if (i == 0)
                            {
                                childText.text = newText[i];
                            }
                            if (newText[i] == "Spider " + (6 - questvarSpider) + "/5")
                            {
                                temp = childText.text;
                                childText.text = temp + "\n" + "Spider " + questvarSpider + "/5";
                            }
                            else
                            {
                                temp = childText.text;
                                childText.text = "\n" + newText[i];
                            }
                        }
                    }
                    else if (EnemyName == "Scorpion")
                    {
                        questvarScorpion -= 1;
                        for (int i = 0; i < newText.Length; i++)
                        {
                            if (i == 0)
                            {
                                childText.text = newText[i];
                            }
                            if (newText[i] == "Scorpion " + (6 - questvarScorpion) + "/5")
                            {
                                temp = childText.text;
                                childText.text = temp + "\n" + "Scorpion " + questvarScorpion + "/5";
                            }
                            else
                            {
                                temp = childText.text;
                                childText.text = "\n" + newText[i];
                            }
                        }
                    }
                    if (questvarScorpion == 0 && questvarSnake == 0 && questvarSpider == 0)
                    {
                        queststatus = true;
                        childStatus.SetActive(true);
                    }
                }
            }
        }
    }

        void Update()
        {
        }
}