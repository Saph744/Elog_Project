namespace eLog.Domain.Data
{
    public interface IUnitOfWorkManager : IDisposable
    {
        IUnitOfWork NewUnitOfWork();
        IUnitOfWork NewUnitOfWorkSql();
    }

}
