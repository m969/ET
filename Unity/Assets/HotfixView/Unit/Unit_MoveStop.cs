using UnityEngine;

namespace ET
{
    public class Unit_MoveStop : AEvent<EventType.MoveStop>
    {
        protected override async ETTask Run(EventType.MoveStop args)
        {
            args.Unit.Moving = false;
            args.Unit.GetComponent<AnimatorComponent>().Play(MotionType.Idle);
            await ETTask.CompletedTask;
        }
    }
}