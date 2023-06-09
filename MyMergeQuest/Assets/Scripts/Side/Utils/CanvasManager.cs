using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Text playerHealthPointsText;
    [SerializeField] private Text playerHitPointsText;

    private GameObject player;

    private Health playerHealth;

    private DamageDealer playerHitPoints;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
        playerHealth = player.GetComponent<Health>();
        playerHitPoints = player.GetComponentInChildren<DamageDealer>();         
    }

    private void Update()
    {
        playerHealthPointsText.text = $"Player HP: {playerHealth.currentHealth}";
        playerHitPointsText.text = $"Player Hit Points: {playerHitPoints.damage}";      
    }
}
