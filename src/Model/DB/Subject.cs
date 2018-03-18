﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Model.DB
{
	public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
