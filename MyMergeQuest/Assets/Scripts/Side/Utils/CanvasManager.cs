using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Text playerHealthPointsText;
    [SerializeField] private Text playerHitPointsText;
    [SerializeField] private Text enemyHealthPointsText;
    [SerializeField] private Text enemyHitPointsText;

    private GameObject player;
    private EnemySpawner spawner;

    private Health playerHealth;
    private Health enemyHealth;

    private DamageDealer playerHitPoints;
    private DamageDealer enemyHitPoints;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
        playerHealth = player.GetComponent<Health>();        
        playerHitPoints = player.GetComponentInChildren<DamageDealer>();   
    }

    private void Update()
    {
        playerHealthPointsText.text = $"Player HP: {playerHealth.currentHealth}";
        playerHitPointsText.text = $"Player HitP: {playerHitPoints.damage}";      
    }
}
