using System;

namespace Assets.Scripts.Common
{
	public class PooledClassObject
	{
		public uint usingSeq = 1;

		public IObjPoolCtrl holder;

		public bool bChkReset = true;

		public virtual void OnUse()
		{
		}

		public virtual void OnRelease()
		{
		}

		public void Release()
		{
			if (this.holder != null)
			{
				this.OnRelease();
				this.holder.Release(this);
			}
		}
	}
}
