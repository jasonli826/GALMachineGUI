﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineNewGUI.Entity
{
    public  class Product
    {
        public ProductParameters ProductParameters { get; set; }
        public Product() 
        {
            ProductParameters = new ProductParameters();
        }


 
    }
}
