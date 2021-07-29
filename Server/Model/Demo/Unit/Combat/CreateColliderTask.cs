using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;
using ET;

namespace EGamePlay.Combat.Ability
{
    public class CreateColliderTaskData
    {
        public Vector3 Position;
        public float Direction;
        public int LifeTime;
        public Action<VCollisionShape> OnTriggerEnterCallback;
    }

    public class CreateColliderTask : AbilityTask
    {
        public VCollisionShape ColliderObj { get; set; }


        public override async ETTask ExecuteTaskAsync()
        {
            var taskData = taskInitData as CreateColliderTaskData;
            ColliderObj = new VCollisionSphere
            {
                Pos = (VInt3)Vector3.zero,
                Radius = 1
            };
            //ColliderObj.GetComponent<OnTriggerEnterCallback>().OnTriggerEnterCallbackAction = (other) =>
            //{
            //    taskData.OnTriggerEnterCallback?.Invoke(other);
            //};
            await TimerComponent.Instance.WaitAsync(taskData.LifeTime);
            ColliderObj = null;
            Entity.Destroy(this);
        }
    }
}