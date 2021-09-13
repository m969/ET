using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EGamePlay
{
    public partial class ItemData : Entity
    {
        public long UniqueId { get; set; }
        public int ConfigId { get; set; }
        public int Amount { get; set; }
    }
}