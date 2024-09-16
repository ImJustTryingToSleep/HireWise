using HireWise.Common.Entities.RecordModels.DB;
using HireWise.Common.Entities.RecordModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.Records
{
    public interface IRecordLogic
    {
        /// <summary>
        /// Создание новой записи.
        /// </summary>
        /// <param name="inputRecord">Модель ввода для создания записи.</param>
        Task CreateAsync(RecordInputModel inputRecord);

        /// <summary>
        /// Обновление существующей записи.
        /// </summary>
        /// <param name="inputRecord">Модель ввода для обновления записи.</param>
        /// <param name="id">Идентификатор записи для обновления.</param>
        Task UpdateAsync(RecordInputModel inputRecord, Guid id);

        /// <summary>
        /// Удаление записи по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор записи для удаления.</param>
        Task DeleteAsync(Guid id);

        Task<Record?> GetRecordByIdAsync(Guid id);

        IAsyncEnumerable<Record> GetAllRecordsAsync();

        IAsyncEnumerable<Record> GetPublishedRecordsAsync();

        IAsyncEnumerable<Record> GetUnpublishedRecordsAsync();

        IAsyncEnumerable<Record> GetPublishedByGradeAndTechIdsAsync(int techTransferId, int gradeId);

        IAsyncEnumerable<Record> GetPublishedByTechIdAsync(int techTransferId);

        IAsyncEnumerable<Record> GetRecordsByUserIdAsync(Guid userId);

        IAsyncEnumerable<Record> GetRecordsByGradeIdAsync(int gradeId);

        IAsyncEnumerable<Record> GetRecordsByTechTransferIdAsync(int techTransferId);
    }
}
