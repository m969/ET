namespace ET
{
	using System.Collections.Generic;

	public class LogicPhysicsComponent : Entity
	{
		public Dictionary<VCollisionShape, Entity> CollisionShapes { get; set; } = new Dictionary<VCollisionShape, Entity>();
		public Dictionary<VCollisionShape, Entity> AddCollisionShapes { get; set; } = new Dictionary<VCollisionShape, Entity>();
		public List<VCollisionShape> RemoveCollisionShapes { get; set; } = new List<VCollisionShape>();
	}
}