using System;
using EGamePlay.Combat.Ability;


namespace ET
{
	[ActorMessageHandler]
	public class C2M_ShootRequestHandler : AMActorLocationRpcHandler<Unit, C2M_ShootRequest, M2C_ShootResponse>
	{
		protected override async ETTask Run(Unit unit, C2M_ShootRequest message, M2C_ShootResponse response, Action reply)
		{
			//var shootArrow = EntityFactory.CreateWithParent<Unit, int>(unit, 1001);
			//shootArrow.UnitType = UnitType.AbilityItem;
			//shootArrow.Position = unit.Position;
			//shootArrow.AddComponent<AbilityItemComponent, AbilityItem>(EGamePlay.Entity.Create<AbilityItem>());
			//shootArrow.AddComponent<CollisionComponent, VCollisionShape>(new VCollisionSphere { Pos = (VInt3)unit.Position, Radius = 1 });
			//var list = ListComponent<UnityEngine.Vector3>.Create();
			//list.List.Add(unit.Position);
			//list.List.Add(UnityEngine.Vector3.one);
			//await shootArrow.AddComponent<MoveComponent>().MoveToAsync(list.List, 3);
			//shootArrow.Dispose();
			//list.Dispose();
			reply();
			await ETTask.CompletedTask;
		}
	}
}