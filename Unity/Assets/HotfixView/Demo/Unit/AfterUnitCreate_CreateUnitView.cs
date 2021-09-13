using UnityEngine;

namespace ET
{
    public class AfterUnitCreate_CreateUnitView: AEvent<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(EventType.AfterUnitCreate args)
        {
            if (args.Unit.UnitType == UnitType.Unit)
            {
                // Unit View层
                // 这里可以改成异步加载，demo就不搞了
                //GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
                //GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");
                var prefab = Resources.Load<GameObject>("Hero");
                GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
                go.transform.position = args.Unit.Position;
                go.transform.GetChild(1).gameObject.SetActive(false);
                args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
                args.Unit.AddComponent<AnimatorComponent>();
            }
            if (args.Unit.UnitType == UnitType.AbilityItem)
            {
                var prefab = Resources.Load<GameObject>("Arrow");
                GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
                go.transform.position = args.Unit.Position;
                args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            }
            if (args.Unit.UnitType == UnitType.Monster)
            {
                var prefab = Resources.Load<GameObject>("Monster");
                GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
                go.transform.position = args.Unit.Position;
                args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
                args.Unit.AddComponent<AnimatorComponent>();
            }

            await ETTask.CompletedTask;
        }
    }
}