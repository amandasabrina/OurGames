﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace OurGames.Core.Model.Model
{
    public partial class Category
    {
        public Category()
        {
            CategoryGame = new HashSet<CategoryGame>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CategoryGame> CategoryGame { get; set; }
    }
}