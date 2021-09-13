using System.Linq;

namespace ET
{
    public class LogicPhysicsComponentAwakeSystem : AwakeSystem<LogicPhysicsComponent>
    {
        public override void Awake(LogicPhysicsComponent self)
        {
            //self.Awake();
        }
    }

    public class LogicPhysicsComponentUpdateSystem : UpdateSystem<LogicPhysicsComponent>
    {
        public override void Update(LogicPhysicsComponent self)
        {
            self.Update();
        }
    }

    public static class LogicPhysicsComponentSystem
    {
        public static void Update(this LogicPhysicsComponent self)
        {
            foreach (var item in self.RemoveCollisionShapes)
            {
                self.CollisionShapes.Remove(item);
            }
            self.RemoveCollisionShapes.Clear();
            foreach (var item in self.AddCollisionShapes)
            {
                self.CollisionShapes.Add(item.Key, item.Value);
            }
            self.AddCollisionShapes.Clear();

            foreach (var item in self.CollisionShapes)
            {
                foreach (var item2 in self.CollisionShapes)
                {
                    if (item.Key == item2.Key)
                    {
                        continue;
                    }
                    if (item.Value.IsDisposed || item2.Value.IsDisposed)
                    {
                        continue;
                    }
                    if (item.Value is Unit unit && item2.Value is Unit unit2)
                    {
                        if (unit.GetComponent<CollisionComponent>() != null && unit2.GetComponent<CollisionComponent>() != null)
                        {
                            var v1 = (VInt3)new UnityEngine.Vector3(unit.Position.x, 0, unit.Position.z);
                            item.Key.UpdateShape(v1, (VInt3)unit.Forward);
                            item.Key.owner.handle.location = v1;
                            item.Key.owner.handle.forward = (VInt3)unit.Forward;
                            var v2 = (VInt3)new UnityEngine.Vector3(unit2.Position.x, 0, unit2.Position.z);
                            item2.Key.UpdateShape(v2, (VInt3)unit2.Forward);
                            item2.Key.owner.handle.location = v2;
                            item2.Key.owner.handle.forward = (VInt3)unit2.Forward;

                            if (item.Key.Intersects(item2.Key))
                            {
                                //Log.Console($"{(item.Key as VCollisionSphere).WorldPos} {(item2.Key as VCollisionSphere).WorldPos}");
                                //Log.Console($"{item.Key.GetShapeType()} {item2.Key.GetShapeType()}");
                                unit.GetComponent<CollisionComponent>().OnCollisionEnter(unit2);
                                unit2.GetComponent<CollisionComponent>().OnCollisionEnter(unit);
                            }
                        }
                    }
                }
            }
        }

        public static void AddCollisionShape(this LogicPhysicsComponent self, VCollisionShape vCollisionShape, Entity entity)
        {
            self.AddCollisionShapes.Add(vCollisionShape, entity);
        }

        public static void RemoveCollisionShape(this LogicPhysicsComponent self, VCollisionShape vCollisionShape)
        {
            self.RemoveCollisionShapes.Add(vCollisionShape);
        }
    }
}