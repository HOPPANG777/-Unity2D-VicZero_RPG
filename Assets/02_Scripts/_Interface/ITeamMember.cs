using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeamMember
{
    TeamType TeamType { get; set; }
}
public enum TeamType
{
    ALLY,
    ENEMY,
    NEUTRAL
}
