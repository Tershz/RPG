using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Items items;
    public Transform parent;
    public static List<int> listId=new List<int>();
    private int id ;

    private void Start()
    {
        ItemWorld.SpawnItemWorld(new Vector3(-4, -3), ItemAsset.AllItem[5],parent,3);//
        ItemWorld.SpawnItemWorld(new Vector3(-4, -4), ItemAsset.AllItem[6],parent,0);//
        ItemWorld.SpawnItemWorld(new Vector3(-4, -3), ItemAsset.AllItem[7],parent,0);//
        ItemWorld.SpawnItemWorld(new Vector3(-4, -2), ItemAsset.AllItem[8],parent,0);//
        ItemWorld.SpawnItemWorld(new Vector3(-4, -1), ItemAsset.AllItem[9],parent,0);//
        ItemWorld.SpawnItemWorld(new Vector3(-3, -3), ItemAsset.AllItem[10],parent,0);//
        ItemWorld.SpawnItemWorld(new Vector3(-3, -2), ItemAsset.AllItem[11],parent,0);//
        ItemWorld.SpawnItemWorld(new Vector3(-5, -4), ItemAsset.AllItem[3],parent,0);//
        ItemWorld.SpawnItemWorld(new Vector3(-5, -3), ItemAsset.AllItem[4],parent, 0);
        ItemWorld.SpawnItemWorld(new Vector3(-5, -2), ItemAsset.AllItem[4],parent, 0);
        ItemWorld.SpawnItemWorld(new Vector3(-5, -1), ItemAsset.AllItem[4],parent, 0);
        ItemWorld.SpawnItemWorld(new Vector3(-5, 0), ItemAsset.AllItem[0],parent, 2);
        ItemWorld.SpawnItemWorld(new Vector3(-7, -4), ItemAsset.AllItem[3],parent, 0);//
        ItemWorld.SpawnItemWorld(new Vector3(-7, -3), ItemAsset.AllItem[1],parent, 3);
        ItemWorld.SpawnItemWorld(new Vector3(-7, -2), ItemAsset.AllItem[1],parent, 6);
        ItemWorld.SpawnItemWorld(new Vector3(-7, -1), ItemAsset.AllItem[2],parent, 0);//
        ItemWorld.SpawnItemWorld(new Vector3(-7, 0), ItemAsset.AllItem[3],parent, 0);//
        ItemWorld.SpawnItemWorld(new Vector3(-6, -4), ItemAsset.AllItem[2],parent, 0);//
        ItemWorld.SpawnItemWorld(new Vector3(-6, -3), ItemAsset.AllItem[0],parent, 2);
        ItemWorld.SpawnItemWorld(new Vector3(-6, -2), ItemAsset.AllItem[0],parent, 1);
        ItemWorld.SpawnItemWorld(new Vector3(-6, -1), ItemAsset.AllItem[1],parent, 9);
        ItemWorld.SpawnItemWorld(new Vector3(-6, -0), ItemAsset.AllItem[2],parent, 0);//

    }

   /* private int getIndex()
    {
        id = 0;
        bool ok = false;
        while(ok != true)
        {
            if (listId.Contains(id))
            {
                id += 1;
            }
            else
            {
                listId.Add(id);
                ok = true;
            }
        }
        return id;
    }*/

}
