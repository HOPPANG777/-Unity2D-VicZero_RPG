using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitAnimationState
{
    Animation_State Animation_State { get; set; }
}

public enum Animation_State
{
    Idle,
    Atk_1,
    Atk_2,
    Atk_3,
    Skill_1,
    Skill_2,
    Sp_Atk,
    Roll,
    Defend,
    Move,
    Jump,
    Take_Hit,
    Death
}
