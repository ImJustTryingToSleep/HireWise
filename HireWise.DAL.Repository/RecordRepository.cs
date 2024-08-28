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
        public async Task<List<Record>> GetAllRecordsAsync() =>
            await GetRecordsQuery().ToListAsync();
        

        /// <summary>
        /// Получение всех опубликованных записей
        /// </summary>
        public async Task<List<Record>> GetPublishedRecordsAsync() =>
            await GetRecordsQuery()
                .Where(r => r.IsPublished)
                .ToListAsync();

        /// <summary>
        /// Получение записей по UserId
        /// </summary>
        public async Task<List<Record>> GetRecordsByUserIdAsync(Guid userId) =>
            await GetRecordsQuery()
                .Where(r => r.UserId == userId)
                .ToListAsync();

        /// <summary>
        /// Получение записей по GradeId
        /// </summary>
        public async Task<List<Record>> GetRecordsByGradeIdAsync(int gradeId) =>
            await GetRecordsQuery()
                .Where(r => r.GradeId == gradeId)
                .ToListAsync();

        /// <summary>
        /// Получение записей по TechTransferId
        /// </summary>
        public async Task<List<Record>> GetRecordsByTechTransferIdAsync(int techTransferId) =>
            await GetRecordsQuery()
                .Where(r => r.TechTransferId == techTransferId)
                .ToListAsync();

        #endregion

        private IQueryable<Record> GetRecordsQuery()
        {
            return _context.Set<Record>()
                .Include(r => r.User) // Подключаем пользователя
                .Include(r => r.TechTransfer) // Подключаем трансфер 
                .Include(r => r.Grade); // Подключаем грейд
        }
    }
}
