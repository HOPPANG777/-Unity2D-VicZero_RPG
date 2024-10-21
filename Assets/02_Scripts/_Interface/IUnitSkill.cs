using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitSkill
{
    Unit_Skill_State Skill_State { get; set; }
}
public enum Unit_Skill_State
{
    Skill_1,
    SKill_2,
    Sp_Attack
}