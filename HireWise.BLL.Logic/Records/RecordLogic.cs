using AutoMapper;
using HireWise.BLL.Logic.Contracts.Records;
using HireWise.BLL.Logic.Contracts.Users;
using HireWise.Common.Entities.RecordModels.DB;
using HireWise.Common.Entities.RecordModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.Records
{
    public class RecordLogic : IRecordLogic
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IUserLogic _userLogic;
        private readonly IMapper _mapper;

        private readonly ILogger<RecordLogic> _logger;

        public RecordLogic(
            IRecordRepository recordRepository,
            IUserLogic userLogic,
            IMapper mapper,
            ILogger<RecordLogic> logger)
        {
            _recordRepository = recordRepository;
            _userLogic = userLogic;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateAsync(RecordInputModel inputRecord)
        {
            var record = _mapper.Map<Record>(inputRecord);

            try
            {
                await _recordRepository.AddRecordAsync(record);
                _logger.LogInformation($"Record was created with ID: {record.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(RecordInputModel inputRecord, Guid id)
        {
            try
            {
                var record = await _recordRepository.GetRecordByIdAsync(id);

                if (record is null)
                {
                    var message = $"There is no record with this Id: {id}";
                    _logger.LogError(message);
                    throw new NullReferenceException();
                }

                _mapper.Map(inputRecord, record);

                await _recordRepository.UpdateRecordAsync(record);
                _logger.LogDebug($"Record with Id: {record.Id} was updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _recordRepository.DeleteRecordAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task<Record?> GetRecordByIdAsync(Guid id) => 
            await _recordRepository.GetRecordByIdAsync(id);

        public IAsyncEnumerable<Record> GetAllRecordsAsync() =>
             _recordRepository.GetAllRecordsAsync();

        public IAsyncEnumerable<Record> GetPublishedRecordsAsync() => 
            _recordRepository.GetPublishedRecordsAsync();

        public IAsyncEnumerable<Record> GetPublishedByGradeAndTechIdsAsync(int techTransferId, int gradeId) =>
            _recordRepository.GetPublishedByGradeAndTechIdsAsync(techTransferId, gradeId);

        public IAsyncEnumerable<Record> GetPublishedByTechIdAsync(int techTransferId) => 
            _recordRepository.GetPublishedByTechIdAsync(techTransferId);

        public IAsyncEnumerable<Record> GetRecordsByUserIdAsync(Guid userId) => 
            _recordRepository.GetRecordsByUserIdAsync(userId);

        public IAsyncEnumerable<Record> GetRecordsByGradeIdAsync(int gradeId) => 
            _recordRepository.GetRecordsByGradeIdAsync(gradeId);

        public IAsyncEnumerable<Record> GetRecordsByTechTransferIdAsync(int techTransferId) => 
            _recordRepository.GetRecordsByTechTransferIdAsync(techTransferId);
    }
}
