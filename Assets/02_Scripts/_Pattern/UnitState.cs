using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class Idle_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;

    public Idle_State()
    {
        animationStrategy = new Idle_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);
    }

    public void Update_State(Unit_Base Unit)
    {

    }

    public void Exit_State(Unit_Base Unit)
    {

    }

}

public class Atk_1_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Atk_1_State()
    {
        animationStrategy = new Atk_1_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        Debug.Log("Exiting Attack State");
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Atk_2_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Atk_2_State()
    {
        animationStrategy = new Atk_2_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {

    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 공격 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Atk_3_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Atk_3_State()
    {
        animationStrategy = new Atk_3_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 공격 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Skill_1_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Skill_1_State()
    {
        animationStrategy = new Skill_1_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Skill_2_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Skill_2_State()
    {
        animationStrategy = new Skill_2_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Sp_Atk_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Sp_Atk_State()
    {
        animationStrategy = new Sp_Atk_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Roll_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Roll_State()
    {
        animationStrategy = new Roll_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        Debug.Log("Exiting Attack State");
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Defend_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Defend_State()
    {
        animationStrategy = new Defend_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Move_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Move_State()
    {
        animationStrategy = new Move_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Jump_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Jump_State()
    {
        animationStrategy = new Jump_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Take_Hit_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;
    private bool isAnimationComplete = false;

    public Take_Hit_State()
    {
        animationStrategy = new Take_Hit_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);

        // 애니메이션이 끝났는지 확인하는 코루틴을 시작합니다.
        Unit.StartCoroutine(Check_Animation_Complete(Unit));
    }

    public void Update_State(Unit_Base Unit)
    {
        if (isAnimationComplete)
        {
            // 공격이 끝났으면 Idle 상태로 전환
            Unit.Set_State(new Idle_State());
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        Debug.Log("Exiting Attack State");
    }

    private IEnumerator Check_Animation_Complete(Unit_Base Unit)
    {
        // 애니메이션이 끝날 때까지 기다립니다.
        while (!Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        isAnimationComplete = true;
    }
}

public class Death_State : IUnitAnimationState
{
    private IUnitAnimationStrategy animationStrategy;

    public Death_State()
    {
        animationStrategy = new Death_Animation_Strategy();
    }

    public void Enter_State(Unit_Base Unit)
    {
        animationStrategy.Play_Animation(Unit.unitAnimator);
    }

    public void Update_State(Unit_Base Unit)
    {
        if (Unit.Is_Dead == true)
        {
            // 끝났으면 죽음 상태로 전환
            if (Unit.unitAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime == 1.0f)
            {
                Unit.unitAnimator.speed = 0;
            }
        }
    }

    public void Exit_State(Unit_Base Unit)
    {
        
    }

}