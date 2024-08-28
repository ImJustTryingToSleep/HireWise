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
            //if (ValidateInputData(inputRecord))
            //    return;

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
                //if (ValidateInputData(inputRecord))
                //    return;

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

        //private bool ValidateInputData(RecordInputModel record) =>
        //    Validate(() => record != null, "No data on the record.") &&
        //    Validate(() => !string.IsNullOrWhiteSpace(record.Name), "Record title is null.") &&
        //    Validate(() => record.Link != null, "Record link is null.") &&
        //    Validate(() => record.Grade != null, "Grade level missing.") &&
        //    Validate(() => record.TechTransfer != null, "Technical transfer missing.");


        //private bool Validate(Func<bool> validationFunc, string errorMessage)
        //{
        //    if (validationFunc())
        //        return true;

        //    _logger.LogError(errorMessage);
        //    return false;
        //}
    }
}
