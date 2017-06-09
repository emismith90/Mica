﻿using System;

namespace Mica.Domain.Data.Models
{
    public class InventoryEntity : EntityBase<long>
    {
        // Empty constructor for EF
        protected InventoryEntity() { }

        public long InStock{ get; set; }

        public virtual MaterialVariantEntity MaterialVariant { get; set; }
    }
}
