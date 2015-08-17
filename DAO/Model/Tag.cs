﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Tag
    {
        public long TagId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Taxonomy> Taxonomies { get; set; }
    }
}