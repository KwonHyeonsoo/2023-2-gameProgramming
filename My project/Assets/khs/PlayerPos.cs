using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{

    Rigidbody Rigid;
    bool isGround = true;
    MapManager mapManager;

    // Start is called before the first frame update
    void Start()
    {
        mapManager = FindAnyObjectByType<MapManager>();
        Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "cube1" || collision.gameObject.tag == "cube2") 
        {
            staticValues.playerOnCubePos = collision.gameObject.transform.position;
            mapManager.setPlayerPosition(collision.gameObject.transform.position);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
        staticValues.playerOnCubePos = Vector3.down;
    }
}
