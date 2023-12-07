using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject effect;
  public float healAmount = 5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerStat>().HealPlayer(healAmount);
            //Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}
