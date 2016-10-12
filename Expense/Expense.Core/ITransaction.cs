namespace Expense.Core
{
    public abstract class Transaction
    {
        public bool WasExecutionSucessfull { get; protected set; }

        protected readonly IExpenseRepository _repository;
        protected readonly IApplicationLogger _applicationLogger;

        protected Transaction(IExpenseRepository repo, IApplicationLogger log)
        {
            _applicationLogger = log;
            _repository = repo;
        }
        public abstract void Execute();
    }
}