using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager: MonoBehaviour
{
    [SerializeField] GameObject potion;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void potionSpawn(Vector3 postion)
    {
        Vector3 cubsize = staticValues.CubeSize;

        float x = postion.x + Random.Range(-cubsize.x / 2, cubsize.x / 2);
        float y = 1;
        float z = postion.z + Random.Range(-cubsize.z / 2, cubsize.z / 4);
        Instantiate(potion, new Vector3(x, y, z), Quaternion.Euler(-90,0,0));
    }

}
