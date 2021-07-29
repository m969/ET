namespace ET
{
	public class CollisionComponent : EGamePlay.Component
	{
		public VCollisionShape CollisionShape { get; set; }
		public System.Action<object> OnCollisionEnterAction { get; set; }


		public void OnCollisionEnter(Entity otherEntity)
        {
			OnCollisionEnterAction?.Invoke(otherEntity);
		}
	}
}