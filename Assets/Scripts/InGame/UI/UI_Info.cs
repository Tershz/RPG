using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Info : MonoBehaviour
{
    public bool hide = false;
    public GameObject infoObj;

    private Vector3 defaultPos;
    private TextMeshProUGUI hideText;

    private void Awake()
    {
        defaultPos = infoObj.transform.position;
        hideText = infoObj.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    public void HideUnhide()
    {
        if(hide == false)
        {
            infoObj.transform.position = new Vector3(infoObj.transform.position.x, -130, infoObj.transform.position.z);
            hideText.text = "Show";
            hide = true;
        }
        else
        {
            infoObj.transform.position = defaultPos;
            hideText.text = "Hide";
            hide = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
