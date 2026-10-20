using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Student { get; }
        ISubjectRepository Subject { get; }
        void SaveAsync();
    }
}
