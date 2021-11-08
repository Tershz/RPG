using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    [Header ("Battle Control")]
    public BattleController battleControl;

    [Header ("Panel")]
    public GameObject Battlepanel;
    public Transform ButtonParent;

    [Header("Attribute")]
    public GameObject player_obj;
    public GameObject enemy1_obj;
    public GameObject enemy2_obj;
    public GameObject enemy3_obj;

    public bool enemySelected;

    private TextMeshProUGUI notificationText;
    private int power;
    private int MPCost;
    private string enemyName;


    IEnumerator BattleDelay()
    {
        battleControl.EndPlayerTurn();
        yield return new WaitForSeconds(5);

    }

    public void Battle()
    {
        foreach (Transform child in ButtonParent)
        {
            if (child.tag == "Skill")
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void Back()
    {
        foreach (Transform child in ButtonParent)
        {
            if (child.tag == "Skill")
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    public void damageEnemy(int damage)
    {
        
        if (enemy1_obj.transform.GetChild(0).gameObject.activeInHierarchy == true)
        {
            enemy1_obj.GetComponent<EnemyAttribute>().HP -= damage;
            enemyName = enemy1_obj.GetComponent<EnemyAttribute>().enemyName;
        }
        else if (enemy2_obj.transform.GetChild(0).gameObject.activeInHierarchy == true)
        {
            enemy2_obj.GetComponent<EnemyAttribute>().HP -= damage;
            enemyName = enemy2_obj.GetComponent<EnemyAttribute>().enemyName;
        }
        else if (enemy3_obj.transform.GetChild(0).gameObject.activeInHierarchy == true)
        {
            enemy3_obj.GetComponent<EnemyAttribute>().HP -= damage;
            enemyName = enemy3_obj.GetComponent<EnemyAttribute>().enemyName;
        }
        battleControl.setNotification("You attack a " + enemyName + " and deal " + damage + " damage.");
    }

    

    public void Skill(string skillName)
    {
        switch (skillName)
        {
            case "Phisical":
                power = 10;
                MPCost = 10;
                break;
            case "Magic":
                power = 20;
                MPCost = 20;
                break;
            case "Special":
                power = 30;
                MPCost = 50;
                break;
            case "Ulitimate":
                power = 80;
                MPCost = 100;
                break;
        }
        if (enemySelected==true && battleControl.playerAttribute.MP - MPCost >= 0)
        {
            battleControl.EndPlayerTurn();
            damageEnemy(power);
            battleControl.playerControl.useSkill(MPCost);
            
        }
    }
    

    public void Run()
    {
        Battlepanel.SetActive(false);
        Time.timeScale = 1;
        player_obj.GetComponent<PlayerControl>().gameControl.WalkMode = true;
        player_obj.GetComponent<PlayerControl>().gameControl.BattleMode = false;
    }

    void Update()
    {
        
    }
}
