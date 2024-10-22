using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitAnimationState
{
    void Enter_State(Unit_Base Unit);
    void Update_State(Unit_Base Unit);
    void Exit_State(Unit_Base Unit);
}

public enum Animation_State
{
    IDLE,
    ATK_1,
    ATK_2,
    ATK_3,
    Skill_1,
    Skill_2,
    SP_ATK,
    ROLL,
    DEFEND,
    MOVE,
    JUMP,
    TAKE_HIT,
    DEATH
}
