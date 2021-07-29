using System;


namespace ET
{
	[ActorMessageHandler]
	public class C2M_ShootRequestHandler : AMActorLocationRpcHandler<Unit, C2M_ShootRequest, M2C_ShootResponse>
	{
		protected override async ETTask Run(Unit unit, C2M_ShootRequest message, M2C_ShootResponse response, Action reply)
		{
			//unit.CombatEntity.a
			reply();
			await ETTask.CompletedTask;
		}
	}
}