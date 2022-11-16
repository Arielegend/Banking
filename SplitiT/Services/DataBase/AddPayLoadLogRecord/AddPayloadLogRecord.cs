using SplitiT.Contracts;

namespace SplitiT.Services.DataBase
{
    public class AddPayloadLogRecord : IAddPayloadLogRecord
    {
        private IResponseGenerator _responseGenerator;
        private readonly ILogger<AddPayloadLogRecord> _logger;


        public AddPayloadLogRecord(IResponseGenerator responseGenerator, ILogger<AddPayloadLogRecord> logger)
        {
            _responseGenerator = responseGenerator;
            _logger = logger;
        }


        /* 
            In case of implementing real DB - 
            signature to this method would be like this.
        */
        public async Task<AddPayloadLogRecordResponse> InsertPayload(string payload) 
        {
            try
            {
                _logger.LogInformation("Inserting Payload record to db");
                return _responseGenerator.GetAddPayloadLogRecordResponse(status: 200, msg: "Done successfuly inserting Payload record to db");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Inserting Payload record to db - Faulure");
                throw new Exception("InsertingPayloadFailure");
            }
        }
    }
}
