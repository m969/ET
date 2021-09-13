using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class SkillAddStatusEffectConfigCategory : ProtoObject
    {
        public static SkillAddStatusEffectConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, SkillAddStatusEffectConfig> dict = new Dictionary<int, SkillAddStatusEffectConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<SkillAddStatusEffectConfig> list = new List<SkillAddStatusEffectConfig>();
		
        public SkillAddStatusEffectConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (SkillAddStatusEffectConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public SkillAddStatusEffectConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SkillAddStatusEffectConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SkillAddStatusEffectConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SkillAddStatusEffectConfig> GetAll()
        {
            return this.dict;
        }

        public SkillAddStatusEffectConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class SkillAddStatusEffectConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public string Name { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string Target { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public string Probability { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public string StatusID { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public string Duration { get; set; }
		[ProtoMember(7, IsRequired  = true)]
		public string Param1 { get; set; }
		[ProtoMember(8, IsRequired  = true)]
		public string Param2 { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
