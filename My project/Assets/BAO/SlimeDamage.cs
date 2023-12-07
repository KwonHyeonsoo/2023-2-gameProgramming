using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SlimeDamage : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerStat>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}