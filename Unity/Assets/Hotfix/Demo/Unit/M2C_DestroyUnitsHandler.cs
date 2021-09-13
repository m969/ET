
using Vector3 = UnityEngine.Vector3;

namespace ET
{
	[MessageHandler]
	public class M2C_DestroyUnitsHandler : AMHandler<M2C_DestroyUnits>
	{
		protected override async ETVoid Run(Session session, M2C_DestroyUnits message)
		{	
			UnitComponent unitComponent = session.Domain.GetComponent<UnitComponent>();
			
			foreach (UnitInfo unitInfo in message.Units)
			{
				var unit = unitComponent.Get(unitInfo.UnitId);
				if (unit == null)
				{
					continue;
				}
				unitComponent.Remove(unit.Id);
			}

			await ETTask.CompletedTask;
		}
	}
}
