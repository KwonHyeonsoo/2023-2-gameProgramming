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

    public void potionSpawn(Vector3 postion, int width, int height)
    {
        Instantiate(potion);
    }

}
