using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private Transform stopPoint;

    private string stopPointName = "EnemyStopPoint";

    private float timeToStopPoint = 6f;

    private Health health;
    private EnemyAnimationManager enemyAnimationManager;

    void Start()
    {
        GlobalVars.enemySpawned = true;

        health = GetComponent<Health>();
        enemyAnimationManager = GetComponent<EnemyAnimationManager>();

        stopPoint = GameObject.Find(stopPointName).transform;

        if(GlobalVars.enemySpawned)
        {
            transform.DOMoveX(stopPoint.position.x, timeToStopPoint)
            .SetEase(Ease.Linear)
            .OnComplete(() => GlobalVars.canMove = false);
        }        
    }

    private void Update()
    {
        if(!health.isAlive)
        {
            StartCoroutine(EnemyDeath());
        } 
        else
        {
            enemyAnimationManager.EnemyAttackAnimation();
        }
    }

    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(enemyAnimationManager.hurtAnimLength);
        Instantiate(explosion, transform.position, Quaternion.identity);
        GlobalVars.canMove = true;
        GlobalVars.enemySpawned = false;
        Destroy(gameObject);
    }
}
