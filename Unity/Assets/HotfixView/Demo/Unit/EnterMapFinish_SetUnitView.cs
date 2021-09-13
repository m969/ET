using UnityEngine;

namespace ET
{
    public class EnterMapFinish_SetUnitView: AEvent<EventType.EnterMapFinish>
    {
        protected override async ETTask Run(EventType.EnterMapFinish args)
        {
            args.MyUnit.GetComponent<GameObjectComponent>().GameObject.transform.GetChild(1).gameObject.SetActive(true);
            await ETTask.CompletedTask;
        }
    }
}