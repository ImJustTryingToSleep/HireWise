using HireWise.Common.Entities.RecordModels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IRecordRepository
    {
        /// <summary>
        /// Добавление новой записи
        /// </summary>
        Task<Record> AddRecordAsync(Record record);

        /// <summary>
        /// Обновление записи
        /// </summary>
        Task<Record> UpdateRecordAsync(Record record);

        /// <summary>
        /// Удаление записи
        /// </summary>
        Task<bool> DeleteRecordAsync(Guid id);

        /// <summary>
        /// Получение записи по Id
        /// </summary>
        Task<Record?> GetRecordByIdAsync(Guid id);

        /// <summary>
        /// Получение всех записей
        /// </summary>
        IAsyncEnumerable<Record> GetAllRecordsAsync();

        /// <summary>
        /// Получение всех опубликованных записей
        /// </summary>
        IAsyncEnumerable<Record> GetRecordsByPublishStatusAsync(bool isPublish);

        /// <summary>
        /// Получение опубликованных записей по грейду и TechTransfer
        /// </summary>
        IAsyncEnumerable<Record> GetPublishedByGradeAndTechIdsAsync(int techTransferId, int gradeId);

        IAsyncEnumerable<Record> GetPublishedByTechIdAsync(int techTransferId);

        /// <summary>
        /// Получение записей по UserId
        /// </summary>
        IAsyncEnumerable<Record> GetRecordsByUserIdAsync(Guid userId);

        /// <summary>
        /// Получение записей по GradeId
        /// </summary>
        IAsyncEnumerable<Record> GetRecordsByGradeIdAsync(int gradeId);

        /// <summary>
        /// Получение записей по TechTransferId
        /// </summary>
        IAsyncEnumerable<Record> GetRecordsByTechTransferIdAsync(int techTransferId);
    }
}
