﻿using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Media
    {
        public int MediaId { get; set; }
        public string MediaUrl { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}