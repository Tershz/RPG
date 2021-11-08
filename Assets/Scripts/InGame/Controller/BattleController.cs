using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [Header("EnemyAsset")]
    public EnemyAsset enemyAsset;
    public Sprite enemySprite;

    [Header ("EnemyCount")]
    public int totalEnemy;
    public int totalEnemyAlive;

    [Header ("EnemyParent")]
    public Transform enemyParent;
    [Header ("PlayerControl")]
    public PlayerControl playerControl;
    public PlayerAttribute playerAttribute;
    [Header ("BattlePanel")]
    public GameObject battlePanel;
    [Header ("ButtonPanel")]
    public GameObject buttonParent;
    [Header ("NotificationPanel")]
    public GameObject notificationParent;

    [Header ("Turn")]
    public bool isPlayer;
    public bool isEnemy1;
    public bool isEnemy2;
    public bool isEnemy3;
    public bool isDelay;

    //Notification Text
    private TextMeshProUGUI notificationText;
    [SerializeField]
    private TextWriter textWriter;


    private void Awake()
    {
        notificationText = notificationParent.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void RandomEnemy()
    {
        isPlayer = true;
        totalEnemy = (int)Random.Range(1, 4);
        totalEnemyAlive = totalEnemy;
        ShowEnemy(totalEnemy);
        playerTurn();
    }
    public void getSprite(string name)
    {
        switch (name)
        {
            case "Scorpion":
                enemySprite = enemyAsset.Scorpion;
                break;
            case "Snake":
                enemySprite = enemyAsset.Snake;
                break;
            case "Spider":
                enemySprite = enemyAsset.Spider;
                break;
        }
    }
    public void ShowEnemy(int enemy)
    {
        foreach(Transform child in enemyParent)
        {
            //reset enemy
            EnemyAttribute childAttribute = child.GetComponent<EnemyAttribute>();
            int RandomVar = Random.Range(0, enemyAsset.ListEnemy.Count);

            childAttribute.HP=20;
            childAttribute.exp=10;
            childAttribute.star=100;
            childAttribute.damage=5;

            childAttribute.enemyName=enemyAsset.ListEnemy[RandomVar].enemyName;
            getSprite(childAttribute.enemyName);
            childAttribute.physical_Def= enemyAsset.ListEnemy[RandomVar].physical_Def;
            childAttribute.magic_Def= enemyAsset.ListEnemy[RandomVar].magic_Def;
            child.GetComponent<Image>().sprite = enemySprite;

            child.gameObject.SetActive(false);
            child.GetChild(0).gameObject.SetActive(false);
        }
        for(int i=0;i< enemy; i++)
        {
            enemyParent.GetChild(i).gameObject.SetActive(true);
            if (i == 0)
            {
                enemyParent.GetChild(0).GetChild(0).gameObject.SetActive(true);
                buttonParent.GetComponent<ButtonControll>().enemySelected = true;
            }
        }

    }
    public void EndPlayerTurn()
    {
        foreach (Transform child in buttonParent.transform)
        {
            child.gameObject.SetActive(false);
        }
        StartCoroutine(BattleDelay("Player"));
        notificationParent.SetActive(true);
    }
    public void EnemyAttack(string enemyName)
    {
        foreach (Transform child in enemyParent)
        {
            if (child.name == enemyName)
            {
                if (child.gameObject.activeInHierarchy == true)
                {
                    playerControl.getDamage(child.GetComponent<EnemyAttribute>().damage);
                    Debug.Log(enemyName + " Attack "+ child.GetComponent<EnemyAttribute>().enemyName);
                    EnemyAttribute childAttribute = child.GetComponent<EnemyAttribute>();
                    setNotification("You are attacked by a " + childAttribute.enemyName + " and take " + childAttribute.damage + " damage");
                }
            }
        }
        StartCoroutine(BattleDelay(enemyName));
        Debug.Log(enemyName);
        isDelay = true;
    }

    

    IEnumerator BattleDelay(string enemyName)
    {
        if(totalEnemyAlive > 0)
        {
            yield return new WaitForSeconds(5);

            switch (enemyName)
            {
                case "Enemy_1":
                    isEnemy1 = false;
                    if (enemyParent.GetChild(1).gameObject.activeInHierarchy == true)
                    {
                        isEnemy2 = true;
                    }
                    else if (enemyParent.GetChild(2).gameObject.activeInHierarchy == true)
                    {
                        isEnemy3 = true;
                    }
                    else
                    {
                        isPlayer = true;
                        playerTurn();
                    }
                    isDelay = false;
                    break;
                case "Enemy_2":
                    isEnemy2 = false;
                    if (enemyParent.GetChild(2).gameObject.activeInHierarchy == true)
                    {
                        isEnemy3 = true;
                    }
                    else
                    {
                        isPlayer = true;
                        playerTurn();
                    }
                    isDelay = false;
                    break;
                case "Enemy_3":
                    isEnemy3 = false;
                    isPlayer = true;
                    isDelay = false;
                    playerTurn();
                    break;
                case "Player":
                    isPlayer = false;
                    if (enemyParent.GetChild(0).gameObject.activeInHierarchy == true)
                    {
                        isEnemy1 = true;
                        Debug.Log("Enemy1 Turn");
                    }
                    else if (enemyParent.GetChild(1).gameObject.activeInHierarchy == true)
                    {
                        isEnemy2 = true;
                        Debug.Log("Enemy2 Turn");
                    }
                    else if (enemyParent.GetChild(2).gameObject.activeInHierarchy == true)
                    {
                        isEnemy3 = true;
                        Debug.Log("Enemy3 Turn");
                    }
                    else
                    {
                        notificationParent.SetActive(false);
                        if (totalEnemyAlive <= 0)
                        {
                            isDelay = false;
                            isEnemy1 = false;
                            isEnemy2 = false;
                            isEnemy3 = false;
                            isPlayer = false;
                            battlePanel.SetActive(false);
                        }
                        Time.timeScale = 1;
                        playerControl.gameControl.WalkMode = true;
                        playerControl.gameControl.BattleMode = false;
                    }
                    break;
            }
        }
        
    }
    public void playerTurn()
    {
        if (isPlayer == true)
        {
            notificationParent.SetActive(false);
            foreach (Transform child in buttonParent.transform)
            {
                if (child.tag != "Skill")
                {
                    child.gameObject.SetActive(true);

                }
            }
        }
    }

    public void setNotification(string text)
    {
        Debug.Log("Tes");
        textWriter.AddWriter(notificationText, text, 0.05f);
    }

    void Update()
    {
        
        if (isDelay == false)
        {
            if (isEnemy1)
            {
                EnemyAttack("Enemy_1");

            }
            else if (isEnemy2)
            {
                EnemyAttack("Enemy_2");
            }
            else if (isEnemy3)
            {
                EnemyAttack("Enemy_3");
            }
        }
       
      
    }
}
