using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.Challenge.Data.DAL
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
