using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SlimeDamage : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerStat>().TakeDamage(damage);
            
        }
    }
}