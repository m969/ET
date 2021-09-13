using System.Linq;
using EGamePlay.Combat.Ability;

namespace ET
{
    public class AbilityItemComponentAwakeSystem : AwakeSystem<AbilityItemComponent, AbilityItem>
    {
        public override void Awake(AbilityItemComponent self, AbilityItem abilityItem)
        {
            self.Awake(abilityItem);
        }
    }

    public class AbilityItemComponentUpdateSystem : UpdateSystem<AbilityItemComponent>
    {
        public override void Update(AbilityItemComponent self)
        {
            self.Update();
        }
    }

    public class AbilityItemComponentDestroySystem : DestroySystem<AbilityItemComponent>
    {
        public override void Destroy(AbilityItemComponent self)
        {
            self.Destroy();
        }
    }
    
    public static class AbilityItemComponentSystem
    {
        public static void Awake(this AbilityItemComponent self, AbilityItem abilityItem)
        {
            var msgUnit = self.Unit.GetParent<Unit>();
            self.AbilityItem = abilityItem;

            var msg = new M2C_CreateUnits();
            msg.Units.Add(UnitHelper.CreateUnitInfo(self.Unit));
            MessageHelper.Broadcast(msgUnit, msg);
        }

        public static void Destroy(this AbilityItemComponent self)
        {
            var msgUnit = self.Unit.GetParent<Unit>();
            var msg = new M2C_DestroyUnits();
            msg.Units.Add(UnitHelper.CreateUnitInfo(self.Unit));
            MessageHelper.Broadcast(msgUnit, msg);
        }

        public static void Update(this AbilityItemComponent self)
        {
            if (TimeHelper.Now() - self.LastSyncTime > self.SyncTimeLimit)
            {
                self.LastSyncTime = TimeHelper.Now();

                var msgUnit = self.Unit.GetParent<Unit>();
                var msg = new M2C_MoveUnit();
                msg.UnitId = self.Unit.Id;
                msg.X = self.Unit.Position.x;
                msg.Y = self.Unit.Position.y;
                msg.Z = self.Unit.Position.z;
                MessageHelper.Broadcast(msgUnit, msg);
            }
        }
    }
}