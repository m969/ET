using System.Linq;

namespace ET
{
    public class MonsterComponentAwakeSystem : AwakeSystem<MonsterComponent>
    {
        public override void Awake(MonsterComponent self)
        {

        }
    }
    
    public class MonsterComponentDestroySystem : DestroySystem<MonsterComponent>
    {
        public override void Destroy(MonsterComponent self)
        {
            self.idUnits.Clear();
        }
    }
    
    public static class MonsterComponentSystem
    {
        public static void Add(this MonsterComponent self, Unit unit)
        {
            unit.Parent = self;
            self.idUnits.Add(unit.Id, unit);
        }

        public static Unit Get(this MonsterComponent self, long id)
        {
            self.idUnits.TryGetValue(id, out Unit unit);
            return unit;
        }

        public static void Remove(this MonsterComponent self, long id)
        {
            Unit unit;
            self.idUnits.TryGetValue(id, out unit);
            self.idUnits.Remove(id);
            unit?.Dispose();
        }

        public static void RemoveNoDispose(this MonsterComponent self, long id)
        {
            self.idUnits.Remove(id);
        }

        public static Unit[] GetAll(this MonsterComponent self)
        {
            return self.idUnits.Values.ToArray();
        }
    }
}