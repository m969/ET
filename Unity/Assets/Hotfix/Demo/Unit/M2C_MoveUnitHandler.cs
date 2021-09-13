
using Vector3 = UnityEngine.Vector3;

namespace ET
{
	[MessageHandler]
	public class M2C_MoveUnitHandler : AMHandler<M2C_MoveUnit>
	{
		protected override async ETVoid Run(Session session, M2C_MoveUnit message)
		{	
			UnitComponent unitComponent = session.Domain.GetComponent<UnitComponent>();

            var unit = unitComponent.Get(message.UnitId);
            if (unit != null)
            {
				var list = ListComponent<Vector3>.Create();
				list.List.Add(unit.Position);
				list.List.Add(new Vector3(message.X, message.Y, message.Z));
				await unit.GetComponent<MoveComponent>().MoveToAsync(list.List, 10);
				list.Dispose();
            }

            await ETTask.CompletedTask;
		}
	}
}
