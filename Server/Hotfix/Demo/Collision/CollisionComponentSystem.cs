using System.Linq;

namespace ET
{
    public class CollisionComponentAwakeSystem: AwakeSystem<CollisionComponent, VCollisionShape>
    {
        public override void Awake(CollisionComponent self, VCollisionShape vCollisionShape)
        {
            self.Awake(vCollisionShape);
        }
    }

    public class CollisionComponentUpdateSystem : UpdateSystem<CollisionComponent>
    {
        public override void Update(CollisionComponent self)
        {
            self.Update();
        }
    }

    public class CollisionComponentDestroySystem : DestroySystem<CollisionComponent>
    {
        public override void Destroy(CollisionComponent self)
        {
            self.Destroy();
        }
    }
    
    public static class CollisionComponentSystem
    {
        public static void Awake(this CollisionComponent self, VCollisionShape vCollisionShape)
        {
            var unit = self.GetParent<Unit>();
            var domain = unit.Domain;
            var comp = domain.GetComponent<LogicPhysicsComponent>();
            self.CollisionShape = vCollisionShape;
            //self.CollisionShape.Born(new Assets.Scripts.GameLogic.ActorRoot());
            vCollisionShape.UpdateShape((VInt3)new UnityEngine.Vector3(unit.Position.x, 0, unit.Position.z), (VInt3)unit.Forward);
            comp.AddCollisionShape(self.CollisionShape, unit);
        }

        public static void Destroy(this CollisionComponent self)
        {
            var unit = self.GetParent<Unit>();
            var domain = unit.Domain;
            var comp = domain.GetComponent<LogicPhysicsComponent>();
            comp.RemoveCollisionShape(self.CollisionShape);
        }

        public static void Update(this CollisionComponent self)
        {
            //self.CollisionShape?.UpdateShape((VInt3)self.GetParent<Unit>().Position, (VInt3)self.GetParent<Unit>().Forward);
        }

        public static void OnCollisionEnter(this CollisionComponent self, Entity otherEntity)
        {
            //Log.Console($"OnCollisionEnter {otherEntity}");
            self.OnCollisionEnterAction?.Invoke(otherEntity);
        }
    }
}