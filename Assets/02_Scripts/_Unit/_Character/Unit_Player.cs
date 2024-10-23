using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit_Player : Unit_Base
{
    [Header("Player")]
    [SerializeField] protected STO_PlayerUnit _currentPlayerUnitSTO;
    public STO_PlayerUnit CurrentPlayerUnitSTO { get { return _currentPlayerUnitSTO; } set { _currentPlayerUnitSTO = value; } }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void SetFirstStatus()
    {
        base.SetFirstStatus();
    }

    public override void Hitted(int attackPower)
    {
        base.Hitted(attackPower);
    }

    protected override bool Check_Dead()
    {
        return base.Check_Dead();
    }

    protected override void Unit_Die()
    {
        base.Unit_Die();
    }

    protected override void UpdateStateUI()
    {
        base.UpdateStateUI();
    }
   
    public virtual void Player_Unit_Attack()
    {
        //All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Unit.transform.position = All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Enemy.transform.position + new Vector3(2.75f, 0, 0);
        Set_State(new Atk_1_State());
        //All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Enemy.Hitted(_currentUnitBaseSTO.UnitInfo[Unit_Level].attackPower);
    }


    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        Unit.Unit_Name = STO_Unit.Unit_Name;
        Unit.UnitBase_Stat.unitHP = STO_Unit.UnitInfo[Unit_Level].unitHP;
        Unit.Max_HP = Unit.Current_HP = STO_Unit.UnitInfo[Unit_Level].unitHP;
        Unit.UnitBase_Stat.unitSpeed = STO_Unit.UnitInfo[Unit_Level].unitSpeed;
        Unit.UnitBase_Stat.attackPower = STO_Unit.UnitInfo[Unit_Level].attackPower;
        Unit.UnitBase_Stat.defensePower = STO_Unit.UnitInfo[Unit_Level].defensePower;
        Unit.UnitBase_Stat.unitSP = STO_Unit.UnitInfo[Unit_Level].unitSP;
        Unit.Max_SP = Unit.Current_SP = STO_Unit.UnitInfo[Unit_Level].unitSP;
        Unit.unitSR.sprite = STO_Unit.UnitSprite;
        Unit.unitAnimator.runtimeAnimatorController = STO_Unit.AnimController;
        Unit.unitSR.drawMode = SpriteDrawMode.Sliced;
        Unit.unitSR.flipX = true;
        Unit.unitSR.size = new Vector2(11.52f, 5.12f);
        Unit.unitBC.size = new Vector2(2.0f, 2.5f);
        Unit.unitBC.offset = new Vector2(0.0f, -1.3f);
        Set_Unit_Position();
    }
    
    public override void Set_Unit_Position()
    {
        var Units = All_Manager.instance.GameMode_M.Player_List;

        for (int i = 0; i < Units.Count; i++)
        {
            if (i < Units.Count)
            {
                Units[i].transform.position = All_Manager.instance.Resource_M.Player_Unit_Set_Position[i] + new Vector3(0, 0, _currentPlayerUnitSTO.UnitSetPositionZ);
            }
        }
    }

    public override void Perform_Action(Unit_Base Attacker, Unit_Base Target, STO_Base_Act Act)
    {

    }
}
