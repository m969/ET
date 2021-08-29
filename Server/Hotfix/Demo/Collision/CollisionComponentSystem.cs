using System.Linq;

namespace ET
{
    public class CollisionComponentAwakeSystem: AwakeSystem<CollisionComponent>
    {
        public override void Awake(CollisionComponent self)
        {
            self.Awake();
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
            
        }
    }
    
    public static class CollisionComponentSystem
    {
        public static void Awake(this CollisionComponent self)
        {
            self.GetParent<Unit>().Domain.GetComponent<LogicPhysicsComponent>().AddCollisionShape(self.GetParent<Unit>().GetComponent<CollisionComponent>().CollisionShape, self.GetParent<Unit>());
        }

        public static void Update(this CollisionComponent self)
        {
            self.CollisionShape?.UpdateShape((VInt3)self.GetParent<Unit>().Position, (VInt3)self.GetParent<Unit>().Forward);
        }
    }
}