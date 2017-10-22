﻿using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGenresRepositories
    {
        IEnumerable<Genre> GetGenres();
    }
}