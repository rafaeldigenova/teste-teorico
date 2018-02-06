﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnico.Infrastructure.Dominio
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public abstract void Update(EntityBase entity);
    }
}
