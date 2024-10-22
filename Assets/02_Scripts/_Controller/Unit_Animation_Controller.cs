using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Animation_Controller : MonoBehaviour
{
    public Animator animator;

    public void Start_Animation(IUnitAnimationStrategy animationStrategy)
    {
        // 애니메이션 전략을 통해 애니메이션 재생
        animationStrategy.Play_Animation(animator);

        // 코루틴 실행: 애니메이션이 끝난 후에 다음 행동을 수행하도록
        StartCoroutine(Wait_For_Animation_To_End());
    }

    private IEnumerator Wait_For_Animation_To_End()
    {
        // 애니메이션이 끝날 때까지 대기
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // 애니메이션이 끝난 후에 다음 행동 수행
        Perform_Next_Action();
    }

    protected virtual void Perform_Next_Action()
    {
        // 여기서 다음 행동을 수행합니다 (예: 다른 애니메이션 시작, 공격 처리 등)
        // Debug.Log("Animation has finished. Now performing the next action.");
    }
}
