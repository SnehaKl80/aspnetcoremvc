﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        void updateCategory(Category category);
    }
}
