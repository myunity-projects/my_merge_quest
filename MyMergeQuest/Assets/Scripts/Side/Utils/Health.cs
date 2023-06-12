using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private EnemyAnimationManager enemyAnimationManager;
    private PlayerAnimations playerAnimations;
    private HealthBar healthBar;
    private LevelLoader levelLoader;

    public float currentHealth;

    public bool isAlive;

    private void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
        healthBar = GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

        if (gameObject.CompareTag("Player"))
        {
            playerAnimations = GetComponent<PlayerAnimations>();          
        }
        else if (gameObject.CompareTag("Enemy") && GlobalVars.enemySpawned)
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
        if (isAlive && gameObject != null)
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
            healthBar.SetHealth(currentHealth);
        }
        else if (!isAlive && gameObject.CompareTag("Player"))
        {
            playerAnimations.PlayerDeathAnimation();
            levelLoader.LoadLevel(3);
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
