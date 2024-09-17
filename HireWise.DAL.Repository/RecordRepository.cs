using HireWise.Common.Entities.RecordModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HireWise.DAL.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly HireWiseDBContext _context;

        public RecordRepository(HireWiseDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавление новой записи
        /// </summary>
        public async Task<Record> AddRecordAsync(Record record)
        {
            await _context.Set<Record>().AddAsync(record);
            await _context.SaveChangesAsync();
            return record;
        }

        /// <summary>
        /// Обновление записи
        /// </summary>
        public async Task<Record> UpdateRecordAsync(Record record)
        {
            _context.Set<Record>().Update(record);
            await _context.SaveChangesAsync();
            return record;
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        public async Task<bool> DeleteRecordAsync(Guid id)
        {
            var record = await GetRecordByIdAsync(id);
            if (record == null) return false;

            _context.Set<Record>().Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }

        #region GET
        /// <summary>
        /// Получение записи по Id
        /// </summary>
        public async Task<Record?> GetRecordByIdAsync(Guid id) =>
            await GetRecordsQuery().FirstOrDefaultAsync(r => r.Id == id);

        /// <summary>
        /// Получение всех записей
        /// </summary>
        public IAsyncEnumerable<Record> GetAllRecordsAsync() =>
            GetRecordsQuery().AsAsyncEnumerable();

        /// <summary>
        /// Получение записей по UserId
        /// </summary>
        public IAsyncEnumerable<Record> GetRecordsByUserIdAsync(Guid userId) =>
            GetRecordsQuery()
                .Where(r => r.UserId == userId)
                .AsAsyncEnumerable();

        /// <summary>
        /// Получение записей по GradeId
        /// </summary>
        public IAsyncEnumerable<Record> GetRecordsByGradeIdAsync(int gradeId) =>
            GetRecordsQuery()
                .Where(r => r.GradeId == gradeId)
                .AsAsyncEnumerable();

        /// <summary>
        /// Получение записей по TechTransferId
        /// </summary>
        public IAsyncEnumerable<Record> GetRecordsByTechTransferIdAsync(int techTransferId) =>
            GetRecordsQuery()
                .Where(r => r.TechTransferId == techTransferId)
                .AsAsyncEnumerable();

        public IAsyncEnumerable<Record> GetRecordsByPublishStatusAsync(bool isPublish) =>
            GetPublishedRecords(isPublish).AsAsyncEnumerable();

        /// <summary>
        /// Получение записей по GradeId
        /// </summary>
        public IAsyncEnumerable<Record> GetPublishedByGradeAndTechIdsAsync(int techTransferId, int gradeId) =>
            GetPublishedRecords(true)
            .Where(r => r.TechTransferId == techTransferId)
                .Where(r => r.GradeId == gradeId)
                .AsAsyncEnumerable();

        /// <summary>
        /// Получение записей по TechTransferId
        /// </summary>
        public IAsyncEnumerable<Record> GetPublishedByTechIdAsync(int techTransferId) =>
            GetRecordsQuery()
                .Where(r => r.TechTransferId == techTransferId)
                .AsAsyncEnumerable();
        #endregion

        /// <summary>
        /// Получение всех опубликованных записей
        /// </summary>
        private IQueryable<Record> GetPublishedRecords(bool isPublish) =>
            GetRecordsQuery()
                .Where(r => r.IsPublished == isPublish);

        private IQueryable<Record> GetRecordsQuery()
        {
            return _context.Set<Record>();
                //.Include(r => r.User) // Подключаем пользователя
                //.Include(r => r.TechTransfer) // Подключаем трансфер 
                //.Include(r => r.Grade); // Подключаем грейд
        }
    }
}
