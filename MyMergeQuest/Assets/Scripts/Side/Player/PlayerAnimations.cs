using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    const string RunAnim = "Run";
    const string IdleAnim = "Idle";
    const string Attack1Anim = "Attack1";
    const string Attack2Anim = "Attack2";
    const string HurtAnim = "Hurt";
    const string DeathAnim = "Death";

    private string currentAnimaton;

    private bool isAttacking = false;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!GlobalVars.canMove)
        {
            if (!isAttacking && (currentAnimaton != Attack1Anim && currentAnimaton != Attack2Anim))
            {
                StartCoroutine(AttackAnimation());
            }            
        }
        else
        {
            ChangeAnimationState(RunAnim);
        }
    }

    public void PlayerHurtAnimation()
    {
        ChangeAnimationState(HurtAnim);
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
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

            ChangeAnimationState(IdleAnim);
            yield return new WaitForSeconds(1f);
            
            ChangeAnimationState(Attack1Anim);
            yield return new WaitForSeconds(GetAnimationLength(Attack1Anim));

            isAttacking = false;
        }
    }
}
