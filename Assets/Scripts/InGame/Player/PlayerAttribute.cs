using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    public int Lv;
    public int PoinUp;
    public double HP;
    public double MaxHP;
    public double MP;
    public double MaxMP;
   
    public double Exp;
    public double Maxexp;

    public double defense;
    public double phisicalAttack;
    public double magicAttack;
    public double Luck;


    private void Update()
    {
        if (Exp >= Maxexp)
        {
            Debug.Log("Level UP!!!");
            Lv+=1;
            Exp -= Maxexp;
            Maxexp*=1.2;
            MaxHP*=1.2;
            MaxMP*=1.2;
            MaxHP =(int)MaxHP;
            HP = MaxHP;
            MaxMP = (int)MaxMP;
            MP = MaxMP;
            Maxexp = (int)Maxexp;
            PoinUp += 1;
        }
    }
}
