using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Entity
{
    public class Category : BaseEntity
    {
        //public Category(int id, string name, bool isActive)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.IsActive = isActive;
        //}

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; }     
    }
}
