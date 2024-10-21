using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack_Data", menuName = "Attack_Data", order = 0)]
public class STO_Attack : ScriptableObject
{
    [Header("STO_Attack")]
    // 액션 상태
    [SerializeField] Unit_Attack_State _unitAttackState;
    public Unit_Attack_State unit_Action_State { get { return _unitAttackState; } set { _unitAttackState = value; } }



}
