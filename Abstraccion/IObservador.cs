﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IObservador
    {
        void Actualizar(IIdioma idiomaObservado);
    }
}
