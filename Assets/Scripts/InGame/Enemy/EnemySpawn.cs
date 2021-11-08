using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int timerSpawn;
    public int timerCanBattle;
    private int setTimerCanBattle;
    public bool canBattle;

    void Start()
    {
        canBattle = true;
        setTimerCanBattle = timerCanBattle;
        
    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.LogError("Collider");
        if (canBattle == true)
        {
            canBattle = false;
            StartCoroutine(Wait());
        }
    }*/
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timerCanBattle);
        canBattle = true;
    }

    void Update()
    {
        if (canBattle == false)
        {
            StartCoroutine(Wait());
        }
    }
}
