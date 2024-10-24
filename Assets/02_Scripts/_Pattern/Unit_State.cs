using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor;
using UnityEngine;

public abstract class Unit_State
{
    protected Animator animator;
    protected Animation_State animationState;

    public Unit_State(Animator animator)
    {
        this.animator = animator;
    }

    public abstract void Handle();

    protected void Play_Animation()
    {
        animator.SetTrigger(animationState.ToString());
    }
}

public class Idle_State : Unit_State
{
    public Idle_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Idle; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Atk_1_State : Unit_State
{
    public Atk_1_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Atk_1; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Atk_2_State : Unit_State
{
    public Atk_2_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Atk_2; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Atk_3_State : Unit_State
{
    public Atk_3_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Atk_3; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Skill_1_State : Unit_State
{
    public Skill_1_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Skill_1; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Skill_2_State : Unit_State
{
    public Skill_2_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Skill_2; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Sp_Atk_State : Unit_State
{
    public Sp_Atk_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Sp_Atk; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Roll_State : Unit_State
{
    public Roll_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Roll; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Defend_State : Unit_State
{
    public Defend_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Defend; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Move_State : Unit_State
{
    public Move_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Move; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Jump_State : Unit_State
{
    public Jump_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Jump; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}

public class Take_Hit_State : Unit_State
{
    public Take_Hit_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Take_Hit; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}


public class Death_State : Unit_State
{
    public Death_State(Animator animator) : base(animator)
    {
        animationState = Animation_State.Death; // 사용할 애니메이션 상태 설정
    }

    public override void Handle()
    {
        Play_Animation();
    }
}