﻿using Overtime.Context;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class DepartmentRepository : GeneralRepository<MyContext, Department, int>
    {
        public DepartmentRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
