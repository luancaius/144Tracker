﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T> 
    {
        Task Save(T vehicle, CancellationToken cancellationToken);
        T Get(string id);
        bool Delete(string id);
        IEnumerable<T> List(string userid);
        IEnumerable<T> Search(string query);
    }
}