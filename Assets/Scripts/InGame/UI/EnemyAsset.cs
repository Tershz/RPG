using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyAsset : MonoBehaviour
{
    public static EnemyAsset Instance { get; set; }
    public List<EnemyAttribute> ListEnemy = new List<EnemyAttribute>();

    public Sprite Scorpion;
    public Sprite Snake;
    public Sprite Spider;
    
    void Start()
    {
        Instance = this;
        addToList();
    }
    public void addToList()
    {
       
        string path = "Assets/TextFile/EnemyAsset.txt";
        FileInfo theSourceFile = new FileInfo(path);
        StreamReader reader = theSourceFile.OpenText();
        string readLine;
        string note = "//";
        do
        {
            readLine = reader.ReadLine();
            if (readLine == null || readLine.Contains(note))
            {
                continue;
            }
            else
            {
                string[] readWord = readLine.Split(new string[] { "," }, System.StringSplitOptions.None);
                print(readWord[0]);
                bool temp1;
                bool temp2;
                if (readWord[1]=="true")
                {
                    temp1 = true;
                }
                else
                {
                    temp1 = false;
                }
                
                if (readWord[2]=="true")
                {
                    temp2 = true;
                }
                else
                {
                    temp2 = false;
                }
                ListEnemy.Add(new EnemyAttribute
                {
                    enemyName = readWord[0],
                    physical_Def = temp1,
                    magic_Def = temp2
                });
            }
        } while (readLine != null);
        
    }


    void Update()
    {
        
    }
}
