using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Idle");
    }
}

public class Atk_1_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Atk_1");
    }
}

public class Atk_2_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Atk_2");
    }
}

public class Atk_3_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Atk_3");
    }
}

public class Skill_1_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Skill_1");
    }
}

public class Skill_2_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Skill_2");
    }
}

public class Sp_Atk_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Sp_Atk");
    }
}

public class Roll_Animation_Strategy : IUnitAnimationStrategy
{ 
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Roll");
    }

}

public class Defend_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Defend");
    }
    
}

public class Move_Animation_Strategy : IUnitAnimationStrategy
{ 
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Move");
    }

}

public class Jump_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Jump");
    }

}

public class Take_Hit_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Take_Hit");
    }
}

public class Death_Animation_Strategy : IUnitAnimationStrategy
{
    public void Play_Animation(Animator animator)
    {
        animator.SetTrigger("Death");
    }
}