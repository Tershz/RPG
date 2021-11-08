using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttribute : MonoBehaviour
{
    [Header("Contoller")]
    public BattleController battleController;

    [Header("Enemy Attribute")]
    public string enemyName;
    public bool physical_Def;
    public bool magic_Def;

    public int Lv;
    public int HP=20;
    public int damage=5;
    public int exp=10;
    public int star=100;

    private int playerLv;

    private TextMeshProUGUI battleNotification;

    private void Awake()
    {
        playerLv = battleController.playerAttribute.Lv;
        if(playerLv <=2 )
        {
            Lv = (int)Random.Range(1,playerLv+2);
        }
        else
        {
            Lv = (int)Random.Range(playerLv-2,playerLv+3);
        }
        damage *= Lv;
        exp *= Lv;
        star *= Lv;
    }

    void Update()
    {

        if (HP <= 0)
        {
            if (gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
            {
                battleController.buttonParent.GetComponent<ButtonControll>().enemySelected = false;
                Debug.Log(gameObject.name+" Child");
            }
            Debug.Log(gameObject.name+" Die");
            gameObject.SetActive(false);
            //Min Total Enemy Alive
            battleController.totalEnemyAlive--;
            //Get EXp by Kill Enemy
            battleController.playerControl.getExp(exp);
            //Get Money by Kill Enemy
            Items money = ItemAsset.AllItem[4];
            money.itemAttribute.SellPrice = star;
            battleController.playerControl.getItem(money);


            int RandomVar = Random.Range(1, 11);
            if (RandomVar <= 3)
            {
                RandomVar = Random.Range(0, 4);
                Items newItem = ItemAsset.AllItem[RandomVar];
                newItem.amount = 1;
                battleController.playerControl.getItem(newItem);
                battleController.setNotification("You killed the " + enemyName + ".\nYou get " + exp + " exp and " + star + " stars.\nYou get 1x " + newItem.itemName);
            }
            else
            {
                battleController.setNotification("You killed the " + enemyName + ".\nYou get " + exp + " exp and " + star + " stars.");
            }

        }
    }
}
