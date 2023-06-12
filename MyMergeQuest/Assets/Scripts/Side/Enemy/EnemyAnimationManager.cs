using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    const string AttackAnimName = "Attack";
    const string HurtAnimName = "Hurt";
    const string IdleAnimationName = "Idle";

    private bool isAttacking;

    public float attackAnimLength;
    public float hurtAnimLength;

    private string currentAnimaton;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        isAttacking = false;
        SetAnimationLengths();
    }

    void Update()
    {
        if (!GlobalVars.canMove)
        {
            if (!isAttacking && currentAnimaton != AttackAnimName)
            {
                StartCoroutine(AttackAnimation());
            }
        }
        else
        {
            ChangeAnimationState(IdleAnimationName);
        }
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    private void SetAnimationLengths()
    {
        attackAnimLength = GetAnimationLength(AttackAnimName);
        hurtAnimLength = GetAnimationLength(HurtAnimName);
    }

    public void EnemyAttackAnimation()
    {
        if (!isAttacking)
        {
            StartCoroutine(AttackAnimation());
        }
    }

    public void EnemyHurtAnimation()
    {
        ChangeAnimationState(HurtAnimName);
    }
    
    private float GetAnimationLength(string animName)
    {
        AnimationClip clip = animator.runtimeAnimatorController.animationClips
            .FirstOrDefault(animationClip => animationClip.name == animName);

        return clip.length;
    }

    IEnumerator AttackAnimation()
    {
        while (!GlobalVars.canMove)
        {
            isAttacking = true;

            yield return new WaitForSeconds(0.5f);
            ChangeAnimationState(AttackAnimName);

            yield return new WaitForSeconds(attackAnimLength);
            ChangeAnimationState(IdleAnimationName);

            isAttacking = false;
        }
    }
}
