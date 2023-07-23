﻿using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Infrastructure.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
