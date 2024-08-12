﻿using HireWise.Common.Entities.RecordModels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IRecordRepository
    {
        /// <summary>
        /// Добавление новой записи
        /// </summary>
        Task<Record> AddRecordAsync(Record record);

        /// <summary>
        /// Получение записи по Id
        /// </summary>
        Task<Record?> GetRecordByIdAsync(Guid id);

        /// <summary>
        /// Получение всех записей
        /// </summary>
        Task<List<Record>> GetAllRecordsAsync();

        /// <summary>
        /// Получение всех опубликованных записей
        /// </summary>
        Task<List<Record>> GetPublishedRecordsAsync();

        /// <summary>
        /// Получение записей по UserId
        /// </summary>
        Task<List<Record>> GetRecordsByUserIdAsync(Guid userId);

        /// <summary>
        /// Получение записей по GradeId
        /// </summary>
        Task<List<Record>> GetRecordsByGradeIdAsync(int gradeId);

        /// <summary>
        /// Получение записей по TechTransferId
        /// </summary>
        Task<List<Record>> GetRecordsByTechTransferIdAsync(int techTransferId);

        /// <summary>
        /// Обновление записи
        /// </summary>
        Task<Record> UpdateRecordAsync(Record record);

        /// <summary>
        /// Удаление записи
        /// </summary>
        Task<bool> DeleteRecordAsync(Guid id);
    }
}
