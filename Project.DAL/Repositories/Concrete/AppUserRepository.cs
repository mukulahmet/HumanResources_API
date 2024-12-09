﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstract;
using Project.Models.Concrete;

namespace Project.DAL.Repositories.Concrete
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
