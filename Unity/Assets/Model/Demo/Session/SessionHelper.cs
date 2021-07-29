namespace ET
{
	public class SessionHelper
	{
		public static async ETTask<TResponse> Call<TResponse>(IActorLocationRequest request) where TResponse : class, IActorLocationResponse
		{
			return await SessionComponent.Instance.Session.Call(request) as TResponse;
        }
	}
}
