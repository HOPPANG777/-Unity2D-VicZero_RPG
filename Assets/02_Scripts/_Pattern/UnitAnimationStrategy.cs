using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Idle"))
        {
            animator.SetTrigger("Idle");
        }
    }

    public string Get_Animation_Name()
    {
        return "Idle";
    }
}

public class Atk_1_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Atk_1"))
        {
            animator.SetTrigger("Atk_1");
        }
    }

    public string Get_Animation_Name()
    {
        return "Atk_1";
    }
}

public class Atk_2_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Atk_2"))
        {
            animator.SetTrigger("Atk_2");
        }
    }

    public string Get_Animation_Name()
    {
        return "Atk_2";
    }
}

public class Atk_3_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Atk_3"))
        {
            animator.SetTrigger("Atk_3");
        }
    }

    public string Get_Animation_Name()
    {
        return "Atk_3";
    }
}

public class Skill_1_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Skill_1"))
        {
            animator.SetTrigger("Skill_1");
        }
    }

    public string Get_Animation_Name()
    {
        return "Skill_1";
    }
}

public class Skill_2_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Skill_2"))
        {
            animator.SetTrigger("Skill_2");
        }
    }

    public string Get_Animation_Name()
    {
        return "Skill_2";
    }
}

public class Sp_Atk_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Sp_Atk"))
        {
            animator.SetTrigger("Sp_Atk");
        }
    }

    public string Get_Animation_Name()
    {
        return "Sp_Atk";
    }
}

public class Roll_Animation_Strategy : IUnitAnimationStrategy
{ 
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Roll"))
        {
            animator.SetTrigger("Roll");
        }
    }

    public string Get_Animation_Name()
    {
        return "Roll";
    }
}

public class Defend_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Defend"))
        {
            animator.SetTrigger("Defend");
        }
    }

    public string Get_Animation_Name()
    {
        return "Defend";
    }
}

public class Move_Animation_Strategy : IUnitAnimationStrategy
{ 
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Move"))
        {
            animator.SetTrigger("Move");
        }
    }

    public string Get_Animation_Name()
    {
        return "Move";
    }
}

public class Jump_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Jump"))
        {
            animator.SetTrigger("Jump");
        }
    }

    public string Get_Animation_Name()
    {
        return "Jump";
    }
}

public class Take_Hit_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Take_Hit"))
        {
            animator.SetTrigger("Take_Hit");
        }
    }

    public string Get_Animation_Name()
    {
        return "Take_Hit";
    }
}

public class Death_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!currentStateInfo.IsName("Death"))
        {
            animator.SetTrigger("Death");
        }
    }

    public string Get_Animation_Name()
    {
        return "Death";
    }
}