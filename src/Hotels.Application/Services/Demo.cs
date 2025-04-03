using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Services
{
    public interface ITransientService
    {
        Guid GetOperationId();
    }

    public interface IScopedService
    {
        Guid GetOperationId();
    }

    public interface ISingletonService
    {
        Guid GetOperationId();
    }

    public class OperationService : ITransientService, IScopedService, ISingletonService
    {
        private readonly Guid _operationId;

        public OperationService()
        {
            _operationId = Guid.NewGuid();
        }

        public Guid GetOperationId() => _operationId;
    }
}
