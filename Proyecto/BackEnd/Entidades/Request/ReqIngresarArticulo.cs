﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class ReqIngresarArticulo : ReqBase
    {
        public Articulo articulo { get; set; }
    }
}
