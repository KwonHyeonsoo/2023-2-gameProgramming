using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    [SerializeField] GameObject monster;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void monsterSpawn(Vector3 postion)
    {
        Vector3 cubsize = staticValues.CubeSize;

        float x = postion.x + Random.Range( -cubsize.x/2, cubsize.x/2);
        float y = cubsize.y+3;
        float z = postion.z + Random.Range(-cubsize.z/ 2, cubsize.z/4);
        Instantiate(monster, new Vector3(x,y,z), Quaternion.identity);
    }

}
