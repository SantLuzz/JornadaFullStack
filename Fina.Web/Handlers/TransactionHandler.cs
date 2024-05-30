using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Web.Handlers
{
    public class TransactionHandler : ITransactionHandler
    {
        public Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Transaction>?>> GetByperiodAsync(GetTransactionsByPeriodRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Transaction?>> UpdateAsync(UpdatedTransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
