using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit_Animation_Base : IUnitAnimationState
{
    protected IUnitAnimationStrategy animationStrategy;
    protected bool isAnimationComplete = false;

    public virtual void Enter_State(Unit_Base Unit)
    {
        Debug.Log("Enter_State");

        Animator animator = Unit.unitAnimator;

        // 현재 애니메이션 상태가 이 애니메이션이 아닌 경우에만 애니메이션을 재생합니다.
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationStrategy.Get_Animation_Name()))
        {
            animationStrategy.Play_Animation(animator);
        }

        // 애니메이션이 끝났는지 확인하는 코루틴 시작
        isAnimationComplete = false;  // 애니메이션 완료 상태 초기화
        Unit.StartCoroutine(Check_Animation_Complete(Unit, animationStrategy.Get_Animation_Name()));
    }

    public virtual void Update_State(Unit_Base Unit)
    {
        Debug.Log("Update_State");

        if (isAnimationComplete)
        {
            Unit.Set_State(new Idle_State());
        }
    }

    public virtual void Exit_State(Unit_Base Unit) 
    {
    
    }

    protected IEnumerator Check_Animation_Complete(Unit_Base Unit, string animationName)
    {
        Debug.Log("Check_Animation_Complete");

        // 애니메이션이 시작될 때까지 대기
        yield return new WaitUntil(() => Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName));

        // 애니메이션이 끝날 때까지 대기
        yield return new WaitUntil(() => Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

        // 애니메이션이 완료되었음을 표시
        isAnimationComplete = true;
    }
}
