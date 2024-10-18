using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Enemy : Unit_Base
{

    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        Unit.UnitName = STO_Unit.UnitName; 
        Unit.UnitBase_Stat.unitHP = STO_Unit.UnitInfo[UnitLevel].unitHP; 
        Unit.MaxHP = Unit.CurrentHP = STO_Unit.UnitInfo[UnitLevel].unitHP;
        Unit.UnitBase_Stat.unitSpeed = STO_Unit.UnitInfo[UnitLevel].unitSpeed;
        Unit.UnitBase_Stat.attackPower = STO_Unit.UnitInfo[UnitLevel].attackPower;
        Unit.UnitBase_Stat.defensePower = STO_Unit.UnitInfo[UnitLevel].defensePower;
    }
}
