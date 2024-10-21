using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitAction
{
    Unit_Action_State Action_State { get; set; }
}
public enum Unit_Action_State
{
    Move,
    Jump,
    Defend,
    Roll
}
