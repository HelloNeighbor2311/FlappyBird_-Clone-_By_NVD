using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSpawnPipe : MonoBehaviour
{
    public List <GameObject> pipeList, QueueingPipe;
    public Transform postSpawn;
    int checkSpawnTime = 0;

    public void Init()
    {
        if (checkSpawnTime == 0)
        {
            Invoke("SpawnObject", 2f);
            
        }
    }
    void SpawnObject()
    {
        var randomNum = Random.Range(0, 3);
        var randomHeight = Random.Range(1.3f, 6f);
        var TempObj = SimplePool2.Spawn(pipeList[randomNum]);
        QueueingPipe.Add(TempObj);
        TempObj.transform.position = new Vector3(postSpawn.transform.position.x,postSpawn.transform.position.y+randomHeight,postSpawn.transform.position.z);
        Invoke("SpawnObject", 2f);
        
    }
    public void Clear() {
        foreach(var obj in QueueingPipe)
        {
            SimplePool2.Despawn(obj);
        }
        
    }

    
    
}
