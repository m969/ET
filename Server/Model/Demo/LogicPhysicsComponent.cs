namespace ET
{
	using System.Collections.Generic;

	public class LogicPhysicsComponentSystem : AwakeSystem<LogicPhysicsComponent>
	{
		public override void Awake(LogicPhysicsComponent self)
		{
			self.Awake();
		}
	}

	public class LogicPhysicsComponentUpdateSystem : UpdateSystem<LogicPhysicsComponent>
	{
		public override void Update(LogicPhysicsComponent self)
		{
			self.Update();
		}
	}

	public class LogicPhysicsComponent : Entity
	{
		//public List<VCollisionShape> CollisionShapes { get; set; } = new List<VCollisionShape>();
		//public List<VCollisionShape> AddCollisionShapes { get; set; } = new List<VCollisionShape>();
		public Dictionary<VCollisionShape, Entity> CollisionShapes { get; set; } = new Dictionary<VCollisionShape, Entity>();
		public Dictionary<VCollisionShape, Entity> AddCollisionShapes { get; set; } = new Dictionary<VCollisionShape, Entity>();
		public List<VCollisionShape> RemoveCollisionShapes { get; set; } = new List<VCollisionShape>();


		public void Awake()
        {

		}

		public void Update()
		{
            foreach (var item in RemoveCollisionShapes)
            {
				CollisionShapes.Remove(item);
			}
			RemoveCollisionShapes.Clear();
			foreach (var item in AddCollisionShapes)
			{
				CollisionShapes.Add(item.Key, item.Value);
			}
			AddCollisionShapes.Clear();

			foreach (var item in CollisionShapes)
            {
                foreach (var item2 in CollisionShapes)
                {
					if (item.Key.Intersects(item2.Key))
					{
						Log.Debug($"{item.Key.GetShapeType()} {item2.Key.GetShapeType()}");
						if (item.Value is Unit unit && item2.Value is Unit unit2)
                        {
							unit.GetComponent<CollisionComponent>().OnCollisionEnter(unit2);
							unit2.GetComponent<CollisionComponent>().OnCollisionEnter(unit);
						}
					}
				}
            }
		}

		public void AddCollisionShape(VCollisionShape vCollisionShape, Entity entity)
        {
			AddCollisionShapes.Add(vCollisionShape, entity);
		}

		public void RemoveCollisionShape(VCollisionShape vCollisionShape)
		{
			RemoveCollisionShapes.Add(vCollisionShape);
		}
	}
}