namespace ET
{
	public class CollisionComponent : Entity
	{
		public VCollisionShape CollisionShape { get; set; }
		public System.Action<Entity> OnCollisionEnterAction { get; set; }
	}
}