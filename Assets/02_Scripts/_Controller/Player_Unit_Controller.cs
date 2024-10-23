using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Unit_Controller : MonoBehaviour
{
    public void Unit_Execute_Act(Unit_Base Attacker, Unit_Base Target, STO_Base_Act Act)
    {
        if (Attacker == null || Target == null ||  Act == null) return;

        switch (Act.Anim_State)
        {
            case Animation_State.ATK_1:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.ATK_2:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.ATK_3:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.Skill_1:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.Skill_2:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.SP_ATK:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.ROLL:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.DEFEND:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.MOVE:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
            case Animation_State.JUMP:
                {
                    if (Act.ProjTrue == false)
                    {
                        Attacker.transform.position = Target.transform.position + new Vector3(2.75f, 0, 0);
                    }
                    All_Manager.instance.Resource_M.EasySet.Easy_Animation(Attacker, Act.Anim_State);
                    Target.Hitted(Act.Power);
                }
                break;
        }

        All_Manager.instance.GameMode_M.Turn_Count += 1;
        All_Manager.instance.GameMode_M.Turn_End();
        
    }
}
