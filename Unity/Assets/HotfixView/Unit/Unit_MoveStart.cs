using UnityEngine;

namespace ET
{
    public class Unit_MoveStart : AEvent<EventType.MoveStart>
    {
        protected override async ETTask Run(EventType.MoveStart args)
        {
            AnimatorComponent animatorComponent = args.Unit.GetComponent<AnimatorComponent>();
            if (args.Unit.Moving == false)
            {
                args.Unit.Moving = true;
                animatorComponent.Play(MotionType.Run);
            }
            await ETTask.CompletedTask;
        }
    }
}