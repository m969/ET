using System.Linq;
using EGamePlay.Combat.Ability;

namespace ET
{
    public class Skill_OnBeginExecute : AEvent<EventType.OnBeginExecute>
    {
        protected override async ETTask Run(EventType.OnBeginExecute args)
        {
            if (args.AbilityExecution is SkillExecution1001 skillExecution)
            {
                skillExecution.BeginExecuteEx();
            }
            await ETTask.CompletedTask;
        }
    }

    public static class SkillAbility1001System
    {
        public static async void BeginExecuteEx(this SkillExecution1001 self)
        {
            var unit = self.OwnerEntity.GetComponent<CombatUnitComponent>().Unit;
            var shootArrowUnit = EntityFactory.CreateWithParent<Unit, int>(unit, 1001);
            shootArrowUnit.UnitType = UnitType.AbilityItem;
            shootArrowUnit.Position = unit.Position;
            shootArrowUnit.AddComponent<AbilityItemComponent, AbilityItem>(EGamePlay.Entity.Create<AbilityItem>());
            var vCol = new VCollisionSphere { Pos = VInt3.zero, Radius = ((VInt)1f).i };
            vCol.Born(new Assets.Scripts.GameLogic.ActorRoot());
            var collisionComp = shootArrowUnit.AddComponent<CollisionComponent, VCollisionShape>(vCol);
            collisionComp.OnCollisionEnterAction = (other) => {
                if (other is Unit unit)
                {
                    if (unit.UnitType == UnitType.Monster)
                    {
                        other.GetComponent<CombatComponent>().CombatEntity.CurrentHealth.Minus(100);
                        Log.Console(other.GetComponent<CombatComponent>().CombatEntity.CurrentHealth.Value.ToString());
                        shootArrowUnit.GetComponent<MoveComponent>().Stop();
                        shootArrowUnit.Dispose();
                    }
                }
            };
            var list = ListComponent<UnityEngine.Vector3>.Create();
            list.List.Add(unit.Position);
            list.List.Add(self.InputPoint);
            await shootArrowUnit.AddComponent<MoveComponent>().MoveToAsync(list.List, 10);
            shootArrowUnit.Dispose();
            list.Dispose();

            await ETTask.CompletedTask;
        }

        public static void EndExecuteEx(this SkillExecution1001 self)
        {

        }
    }
}