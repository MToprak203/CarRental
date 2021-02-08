using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    public abstract class IProperties : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
