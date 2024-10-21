using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action_Data", menuName = "Action_Data", order = 0)]
public class STO_Action : ScriptableObject
{
    [Header("STO_Action")]
    // 액션 상태
    [SerializeField] Unit_Action_State _unitActionState;
    public Unit_Action_State unit_Action_State { get { return _unitActionState; } set { _unitActionState = value; } }



}
