using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerAttribute : MonoBehaviour
{
    public PlayerControl playerControl;

    public TextMeshProUGUI poinUp;
    public int poinValue;

    private PlayerAttribute playerAttribute;

    public GameObject AttributeDetail;

    public GameObject Detail_Equipment;

    public List<GameObject> poinButton;
    public List<TextMeshProUGUI> listTextPoin;

    
    private void Awake()
    {
    }

    public void setImage(Sprite sprite)
    {
        if(AttributeDetail.transform.GetChild(0).name == "Image")
        {
            AttributeDetail.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
        }
        
    }

    public void UP(TextMeshProUGUI text)
    {
        Debug.Log(gameObject.name);
        if (playerAttribute.PoinUp > 0)
        {
            if (poinValue > 0)
            {

                int newUp = Convert.ToInt32(text.text);
                newUp += 1;
                poinValue -= 1;
                poinUp.text = poinValue.ToString();
                text.text = newUp.ToString();
            }
        }
    }
    public void Down(TextMeshProUGUI text)
    {
        int newDown = Convert.ToInt32(text.text);
        if (newDown > 0)
        {
            newDown -= 1;
            poinValue += 1;
            poinUp.text = poinValue.ToString();
        }
        text.text = newDown.ToString();
    }
    public void confirmPoint()
    {
        foreach (TextMeshProUGUI newText in listTextPoin)
        {
            if (newText.text != "0")
            {
                updateAttribute(newText.gameObject.name, Convert.ToInt32(newText.text));
                newText.text = "0";
            }

        }
        playerControl.updatePoin(poinValue);

    }
    public void cancelPoint()
    {
        foreach(TextMeshProUGUI newText in listTextPoin)
        {
            if(newText.text != "0")
            {

                poinValue += Convert.ToInt32(newText.text);
                Debug.Log("back Point:"+Convert.ToInt32(newText.text));
                newText.text = "0";
            }

        }
        
    }
    public void updateAttribute(string name,int point) 
    {
        playerControl.updateAttribute(name, point);
        
    }
    public void setAttribute(PlayerAttribute attribute)
    {
        playerAttribute = attribute;
        foreach(Transform child in AttributeDetail.transform)
        {
            /*poinUp.text = attribute.PoinUp.ToString();*/
            poinUp.text = poinValue.ToString();
            if (child.tag == "Attribute")
            {
                switch (child.name)
                {
                    case "HP":
                        child.GetChild(0).GetComponent<TextMeshProUGUI>().text = child.name + " : "+ attribute.HP+"/"+ attribute.MaxHP  ;
                        break;
                    case "MP":
                        child.GetChild(0).GetComponent<TextMeshProUGUI>().text = child.name + " : "+ attribute.MP+"/"+ attribute.MaxMP  ;
                        break;
                    case "DEF":
                        child.GetChild(0).GetComponent<TextMeshProUGUI>().text = child.name + " : "+ attribute.defense;
                        break;
                    case "LUCK":
                        child.GetChild(0).GetComponent<TextMeshProUGUI>().text = child.name + " : "+ attribute.Luck;
                        break;
                    case "P.Atck":
                        child.GetChild(0).GetComponent<TextMeshProUGUI>().text = child.name + " : "+ attribute.phisicalAttack ;
                        break;
                    case "M.Atck":
                        child.GetChild(0).GetComponent<TextMeshProUGUI>().text = child.name + " : "+ attribute.magicAttack;
                        break;
                }
            }
            if(child.gameObject.name == "Level_Text (TMP)")
            {
                child.GetComponent<TextMeshProUGUI>().text = "Level : " + attribute.Lv;
            }
            else if(child.gameObject.name == "EXP_Text (TMP)")
            {
                child.GetComponent<TextMeshProUGUI>().text = "EXP : " + attribute.Exp+"/"+attribute.Maxexp;
            }
        }
    }

    public void EquipedDetail(GameObject button)
    {
        Detail_Equipment.transform.position = button.transform.position;
        Detail_Equipment.SetActive(true);
    }
    public void ExitEquipedDetail()
    {
        Detail_Equipment.SetActive(false);
    }


    void Update()
    {
        setAttribute(playerAttribute);
        if(playerAttribute.PoinUp > 0)
        {
            foreach(GameObject newbtnPoin in poinButton)
            {
                newbtnPoin.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject newbtnPoin in poinButton)
            {
                newbtnPoin.SetActive(false);
            }
        }
    }
}
