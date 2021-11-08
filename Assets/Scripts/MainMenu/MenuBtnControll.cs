using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtnControll : MonoBehaviour
{
    public GameObject SettingMenu;

    public void Start_Btn()
    {
        SceneManager.LoadScene(1);
    }
    public void Setting_Btn()
    {
        if (SettingMenu.activeInHierarchy)
        {
            SettingMenu.SetActive(false);
        }
        else
        {
            SettingMenu.SetActive(true);
        }
    }
    public void Quit_Btn()
    {
        Application.Quit();
    }
    
}
