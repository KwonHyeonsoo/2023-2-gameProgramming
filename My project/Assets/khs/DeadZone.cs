using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone: MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DeadZone") Destroy(gameObject);
    }
}
