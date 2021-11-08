using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEnemy : MonoBehaviour
{

    public GameObject enemyParent;
    public ButtonControll playerButton;

    void Start()
    {
        
    }

    public void SelectedEnemy(GameObject selected)
    {
        Debug.Log("Selected"+selected.name);
       foreach(Transform child in enemyParent.transform)
        {

            if (child.gameObject.name == selected.name )
            {
                child.transform.GetChild(0).gameObject.SetActive(true);
                playerButton.enemySelected = true;
                Debug.Log("Enemy Selected");
            }
            else
            {
                child.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
