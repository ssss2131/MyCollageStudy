﻿using HelloRedis.Domain;
using HelloRedis.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public interface IAuthorService: IBaseService<Author>
    {
    }
}
