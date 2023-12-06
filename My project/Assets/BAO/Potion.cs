using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
  public float healAmount = 5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerStat>().HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
    
}
