using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitAnimationState
{
    Animation_State Anim_State { get; set; }
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
