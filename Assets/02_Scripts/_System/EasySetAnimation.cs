using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySetAnimation : MonoBehaviour
{
    public void Easy_Animation(Unit_Base Unit, Animation_State State)
    {
        switch (State)
        {
            case Animation_State.IDLE:
                Unit.Set_State(new Idle_State());
                break;
            case Animation_State.ATK_1:
                Unit.Set_State(new Atk_1_State());
                break;
            case Animation_State.ATK_2:
                Unit.Set_State(new Atk_2_State());
                break;
            case Animation_State.ATK_3:
                Unit.Set_State(new Atk_3_State());
                break;
            case Animation_State.Skill_1:
                Unit.Set_State(new Skill_1_State());
                break;
            case Animation_State.Skill_2:
                Unit.Set_State(new Skill_2_State());
                break;
            case Animation_State.SP_ATK:
                Unit.Set_State(new Sp_Atk_State());
                break;
            case Animation_State.ROLL:
                Unit.Set_State(new Roll_State());
                break;
            case Animation_State.DEFEND:
                Unit.Set_State(new Defend_State());
                break;
            case Animation_State.MOVE:
                Unit.Set_State(new Move_State());
                break;
            case Animation_State.JUMP:
                Unit.Set_State(new Jump_State());
                break;
            case Animation_State.TAKE_HIT:
                Unit.Set_State(new Take_Hit_State());
                break;
            case Animation_State.DEATH:
                Unit.Set_State(new Death_State());
                break;
        }
    }
}
