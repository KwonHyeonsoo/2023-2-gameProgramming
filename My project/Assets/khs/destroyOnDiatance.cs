using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnDiatance : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (staticValues.playerOnCubePos.z - 1000 > transform.position.z) Destroy(gameObject);
    }
}
