using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    const string AttackAnimName = "Attack";
    const string HurtAnimName = "Hurt";
    const string AttackAnimBoolName = "isAttacking";
    const string HurtAnimBoolName = "isHurt";

    private bool isAttacking = false;

    public float attackAnimLength;
    public float hurtAnimLength;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        SetAnimationLengths();
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
        StartCoroutine(HurtAnimation());
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
            animator.SetBool(AttackAnimBoolName, true);

            yield return new WaitForSeconds(attackAnimLength);
            animator.SetBool(AttackAnimBoolName, false);

            isAttacking = false;
        }
    }

    IEnumerator HurtAnimation()
    {
        animator.SetBool(HurtAnimBoolName, true);
        yield return new WaitForSeconds(hurtAnimLength);
        animator.SetBool(HurtAnimBoolName, false);
    }
}
