

namespace ET
{
	[ActorMessageHandler]
	public class G2M_SessionDisconnectHandler : AMActorLocationHandler<Unit, G2M_SessionDisconnect>
	{
		protected override async ETTask Run(Unit unit, G2M_SessionDisconnect message)
		{
			Log.Console("G2M_SessionDisconnectHandler");
			unit.Domain.GetComponent<UnitComponent>().Remove(unit.Id);
			//unit.Dispose();
			await ETTask.CompletedTask;
		}
	}
}