using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private string[] tags = { "Player", "Enemy" };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (collision.gameObject.CompareTag(tags[0]))
        {
            if(health != null)
            {
                health.RecieveDamage(damage);
            }            
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
