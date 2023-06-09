using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMergeHandler : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject powerUpPrefab;

    private DamageDealer playerDamageDealer;
    private Health playerHealth;

    private float totalPlayerHitPoints;

    public bool itemsMerged;
    public float mergedItemId;

    private void Start()
    {
        playerDamageDealer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<DamageDealer>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        // Increase players Hit Points after every merge
        if (GlobalVars.itemsMerged)
        {
            totalPlayerHitPoints += GlobalVars.mergedItemId;
            GlobalVars.itemsMerged = false;
            playerDamageDealer.damage += GlobalVars.mergedItemId;
            Instantiate(powerUpPrefab, playerTransform.transform.position, Quaternion.identity);
        }

        // If total amount of hitpoints divisible by 3 then health increases by a number in range from 1 to 3
        if (GlobalVars.itemsMerged && (totalPlayerHitPoints / 3 == 0) && playerHealth.currentHealth <= 100)
        {
            playerHealth.currentHealth += Random.Range(1, 3);
        }        
    }
}
