using System;


namespace ET
{
	[ActorMessageHandler]
	public class C2M_ShootRequestHandler : AMActorLocationRpcHandler<Unit, C2M_ShootRequest, M2C_ShootResponse>
	{
		protected override async ETTask Run(Unit unit, C2M_ShootRequest message, M2C_ShootResponse response, Action reply)
		{
			var shootArrow = EntityFactory.CreateWithParent<Unit, int>(unit, 1001);
			shootArrow.UnitType = UnitType.AbilityItem;
			shootArrow.GetComponent<CollisionComponent>().CollisionShape = new VCollisionSphere { Pos = (VInt3)unit.Position, Radius = 1 };
			shootArrow.GetComponent<CollisionComponent>().CollisionShape.Born(new Assets.Scripts.GameLogic.ActorRoot());
			reply();
			await ETTask.CompletedTask;
		}
	}
}