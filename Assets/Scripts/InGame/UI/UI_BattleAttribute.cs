using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_BattleAttribute : MonoBehaviour
{
    [Header("Player Control")]
    public PlayerControl playerControl;

    [Header("Main Attribute")]
    public GameObject Main_HP;
    public GameObject Main_Exp;
    public TextMeshProUGUI Main_Lv;
    public GameObject Main_MP;

    [Header("Battle Attribute")]
    public GameObject Battle_HP;
    public GameObject Battle_MP;

    private PlayerAttribute attribute;

    public void setAttribute(PlayerAttribute newAttribute)
    {
        attribute = newAttribute;
        //Main
        Main_HP.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = attribute.HP + "/" + attribute.MaxHP;
        Main_MP.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = attribute.MP + "/" + attribute.MaxMP;
        Main_Exp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = attribute.Exp + "/" + attribute.Maxexp;
        Main_Lv.text = "Lv."+attribute.Lv;
        //Battle
        Battle_HP.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = attribute.HP + "/" + attribute.MaxHP;
        Battle_MP.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = attribute.MP + "/" + attribute.MaxMP;
    }

    void Update()
    {
        //Main
        Main_HP.transform.GetChild(0).localScale = new Vector3((float)(attribute.HP/attribute.MaxHP),1,1);
        Main_MP.transform.GetChild(0).localScale = new Vector3((float)(attribute.MP/attribute.MaxMP),1,1);
        Main_Exp.transform.GetChild(0).localScale = new Vector3((float)(attribute.Exp/attribute.Maxexp),1,1);

        //Battle
        Battle_HP.transform.GetChild(0).localScale = new Vector3((float)(attribute.HP/attribute.MaxHP),1,1);
        Battle_MP.transform.GetChild(0).localScale = new Vector3((float)(attribute.MP/attribute.MaxMP),1,1);
    }
}
