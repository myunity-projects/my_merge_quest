using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private EnemyAnimationManager enemyAnimationManager;
    private PlayerAnimations playerAnimations;

    public float currentHealth;

    public bool isAlive;

    private void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;

        if (gameObject.CompareTag("Player"))
        {
            playerAnimations = GetComponent<PlayerAnimations>();
        }
        else
        {
            enemyAnimationManager = GetComponent<EnemyAnimationManager>();
        }
    }

    private void Update()
    {
        CheckIsAlive();
    }

    public void RecieveDamage(float damage)
    {
        if (isAlive)
        {
            if(gameObject.CompareTag("Player"))
            {
                playerAnimations.PlayerHurtAnimation();
            }
            else
            {
                enemyAnimationManager.EnemyHurtAnimation();
            }
            currentHealth -= damage;
        }        
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }
    }
}
