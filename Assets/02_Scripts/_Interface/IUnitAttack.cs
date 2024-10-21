using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitAttack
{
    Unit_Attack_State Attack_State { get; set; }
}
public enum Unit_Attack_State
{
    Atk_1,
    Atk_2,
    Atk_3
}