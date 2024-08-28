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
        }
}
