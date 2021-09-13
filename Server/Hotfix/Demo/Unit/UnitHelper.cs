using EGamePlay;
using EGamePlay.Combat;
using UnityEngine;

namespace ET
{
    public static class UnitHelper
    {
        public static UnitInfo CreateUnitInfo(Unit unit)
        {
            var unitInfo = new UnitInfo();
            unitInfo.X = unit.Position.x;
            unitInfo.Y = unit.Position.y;
            unitInfo.Z = unit.Position.z;
            unitInfo.UnitId = unit.Id;
            unitInfo.ConfigId = unit.ConfigId;
            unitInfo.UnitType = (int)unit.UnitType;

            var nc = unit.GetComponent<NumericComponent>();
            if (nc != null)
            {
                foreach ((int key, long value) in nc.NumericDic)
                {
                    unitInfo.Ks.Add(key);
                    unitInfo.Vs.Add(value);
                }
            }

            return unitInfo;
        }

        public static UnitInfo CreateAbilityItemInfo(Unit unit)
        {
            var unitInfo = new UnitInfo();
            unitInfo.X = unit.Position.x;
            unitInfo.Y = unit.Position.y;
            unitInfo.Z = unit.Position.z;
            unitInfo.UnitId = unit.Id;
            unitInfo.ConfigId = unit.ConfigId;
            unitInfo.UnitType = (int)unit.UnitType;
            return unitInfo;
        }

        public static Unit CreateMonster(Scene scene)
        {
            Unit unit = EntityFactory.Create<Unit, int>(scene, 2001);
            unit.UnitType = UnitType.Monster;
            unit.Position = new Vector3(-5, 0, -5);
            var vCol = new VCollisionSphere { Pos = VInt3.zero, Radius = ((VInt)1f).i };
            vCol.Born(new Assets.Scripts.GameLogic.ActorRoot());
            unit.AddComponent<CollisionComponent, VCollisionShape>(vCol);
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<CombatComponent, CombatEntity>(CombatContext.Instance.AddChildWithId<CombatEntity>(unit.Id));

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒

            scene.GetComponent<MonsterComponent>().Add(unit);
            return unit;
        }
    }
}