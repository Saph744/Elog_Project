using System.Data;

namespace eLog.Domain.Data
{
    public interface IUnitOfWork: IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        /// <summary>
        /// Commit the changes
        /// </summary>
        void Commit();

        void Rollback();
        /// <summary>
        /// Save changes
        /// </summary>
        void SaveChanges();
        Task SaveChangesAsync();
        void AutoDetectChangesEnabled(bool option);

    }
}
