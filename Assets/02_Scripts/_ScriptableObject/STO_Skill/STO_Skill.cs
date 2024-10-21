using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill_Data", menuName = "Skill_Data", order = 0)]
public class STO_Skill : ScriptableObject
{
    [Header("STO_Skill")]
    // 스킬 상태
    [SerializeField] Unit_Skill_State _unitSkillState;
    public Unit_Skill_State unit_Skill_State { get { return _unitSkillState; } set { _unitSkillState = value; } }
}
