using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class Idle_State : Unit_Animation_Base
{
    public Idle_State()
    {
        animationStrategy = new Idle_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Atk_1_State : Unit_Animation_Base
{
    public Atk_1_State()
    {
        animationStrategy = new Atk_1_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Atk_2_State : Unit_Animation_Base
{
    public Atk_2_State()
    {
        animationStrategy = new Atk_2_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Atk_3_State : Unit_Animation_Base
{
    public Atk_3_State()
    {
        animationStrategy = new Atk_3_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Skill_1_State : Unit_Animation_Base
{
    public Skill_1_State()
    {
        animationStrategy = new Skill_1_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Skill_2_State : Unit_Animation_Base
{
    public Skill_2_State()
    {
        animationStrategy = new Skill_2_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Sp_Atk_State : Unit_Animation_Base
{
    public Sp_Atk_State()
    {
        animationStrategy = new Sp_Atk_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Roll_State : Unit_Animation_Base
{
    public Roll_State()
    {
        animationStrategy = new Roll_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Defend_State : Unit_Animation_Base
{
    public Defend_State()
    {
        animationStrategy = new Defend_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Move_State : Unit_Animation_Base
{
    public Move_State()
    {
        animationStrategy = new Move_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Jump_State : Unit_Animation_Base
{
    public Jump_State()
    {
        animationStrategy = new Jump_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Take_Hit_State : Unit_Animation_Base
{
    public Take_Hit_State()
    {
        animationStrategy = new Take_Hit_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}

public class Death_State : Unit_Animation_Base
{
    public Death_State()
    {
        animationStrategy = new Death_Animation_Strategy();
    }

    public override void Enter_State(Unit_Base Unit)
    {
        base.Enter_State(Unit);
    }

    public override void Update_State(Unit_Base Unit)
    {
        base.Update_State(Unit);
    }

    public override void Exit_State(Unit_Base Unit)
    {
        base.Exit_State(Unit);
    }
}