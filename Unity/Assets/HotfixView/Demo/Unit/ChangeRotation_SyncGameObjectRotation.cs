using UnityEngine;

namespace ET
{
    public class ChangeRotation_SyncGameObjectRotation: AEvent<EventType.ChangeRotation>
    {
        protected override async ETTask Run(EventType.ChangeRotation args)
        {
            Transform transform = args.Unit.GetComponent<GameObjectComponent>().GameObject.transform;
            if (args.Unit.IsMyUnit)
            {
                transform.GetChild(0).rotation = args.Unit.Rotation;
            }
            else
            {
                transform.rotation = args.Unit.Rotation;
            }
            await ETTask.CompletedTask;
        }
    }
}