using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SplitiT.Contracts;
using SplitiT.Contracts.Responses;
using SplitiT.Models.Sources;
using SplitiT.Services;
using SplitiT.Services.DataBase;
using SplitiT.Services.DataBase.AddPurchaseHistory;
using SplitiT.Services.EfficientDataStructure;
using SplitiT.Services.JsonValidators;
using SplitiT.Services.Payloads;
using SplitiT.Services.Validators;
using SplitiT.Services.Validators.RequestsValidators;

namespace SplitiT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayloadController : ControllerBase
    {
        private readonly ILogger<PayloadController> _logger;
        private readonly IPayload1Service _payload1Service;
        private readonly IPayload2Service _payload2Service;
        private readonly IPayload3Service _payload3Service;
        private readonly IResponseGenerator _responseGenerator;
        private readonly IAddPayloadLogRecord _addPayloadLogRecord;
        private readonly IAuthorizeService _authorizeService;
        private readonly IAddPurchaseHistory _addPurchaseHistory;
        private readonly IPayloadValidatorService _payloadValidatorService;
        private readonly IEfficientDataStructureService _efficientDataStructureService;
        private readonly IGetPurchasesRequestValidator _getPurchasesRequestValidator;
        private readonly IAddPayloadRequestValidator _addPayloadRequestValidator;

        public PayloadController(
            ILogger<PayloadController> logger,
            IPayload1Service payload1Service,
            IPayload2Service payload2Service,
            IPayload3Service payload3Service,
            IResponseGenerator responseGenerator,
            IAddPayloadLogRecord addPayloadLogRecord, 
            IAuthorizeService authorizeService,
            IAddPurchaseHistory addPurchaseHistory,
            IPayloadValidatorService payloadValidatorService,
            IEfficientDataStructureService efficientDataStructureService,
            IGetPurchasesRequestValidator getPurchasesRequestValidator,
            IAddPayloadRequestValidator addPayloadRequestValidator)

        {
            _logger = logger;
            _payload1Service = payload1Service;
            _payload2Service = payload2Service;
            _payload3Service = payload3Service;
            _responseGenerator = responseGenerator;
            _addPayloadLogRecord = addPayloadLogRecord;
            _authorizeService = authorizeService;
            _addPurchaseHistory = addPurchaseHistory;
            _payloadValidatorService = payloadValidatorService;
            _efficientDataStructureService = efficientDataStructureService;
            _getPurchasesRequestValidator = getPurchasesRequestValidator;
            _addPayloadRequestValidator = addPayloadRequestValidator;
        }

        [HttpPost]
        public async Task<AddPayloadResponse> Post(AddPayloadRequest req)
        {
            string message = $"Handling Post request with params | source - {req.Source} | payload with length - {req.Payload.Length}";
            _logger.LogInformation(message);

            try
            {
                //Record the payload as a log into a dedicated repository 
                await _addPayloadLogRecord.InsertPayload(req.Payload);

                //Validating request
                _addPayloadRequestValidator.ValidateRequest(req);

                //Initializing relevant PayloadService (According to source)
                JObject jObject = JObject.Parse(req.Payload);
                InitPayloadService(jObject, req.Payload, req.Source);

                //Authorizing by transactionId
                await _authorizeService.AuthorizeTransactionId(GetTransactionId(req.Source));

                //Mapping the entire purchaseHistory array to Purchases Dictionary
                var responseAddPurchaseHistoryArray = _addPurchaseHistory.AddEntirePurchaseHistoryArray(GetPurchaseHistoryObject(req.Source));

                string finalMsg = $"Done handling post request, Added {responseAddPurchaseHistoryArray.Success} / {responseAddPurchaseHistoryArray.Total}";
                Console.WriteLine(finalMsg);
                return _responseGenerator.GetAddPayloadResponse(status: 200, msg: finalMsg);
            }

            catch (Exception ex)
            {
                return HandleAddPayloadExceptions(ex);
            }
        }

        [HttpGet("{month}/{year}")]
        public GetPurchasesByMonthAndYearResponse GetPurchasesHistory(string month, int year)
        {
            try
            {
                //Validating request
                _getPurchasesRequestValidator.ValidateRequest(new GetPurchasesByMonthAndYearRequest { Month=month, Year= year});

                //Getting purchasesHistory from dictionary using key 'Month-Year' 
                string monthYearString = month.ToUpper() + "-" + year.ToString();
                var purchaseHIstory = _efficientDataStructureService.GetPurchasesByMonthAndYear(monthYearString);
                
                //Printing Data to console
                PrintPurchaseHistoryToConsole(purchaseHIstory, monthYearString);

                return _responseGenerator.GetPurchasesByMonthAndYearResponse(status: 200, msg: $"Done displaying purchases id's for {monthYearString}");
            }

            catch (Exception ex)
            {
                return HandleGetPurchasesExceptions(ex);
            }
        }
        private static void PrintPurchaseHistoryToConsole(IList<string> purchaseHIstory, string monthYearString)
        {
            if(purchaseHIstory.Count == 0)
            {
                Console.WriteLine($"\nThere are no purchases made in {monthYearString}\n");
                return;
            }

            Console.WriteLine($"\nPurchases Id's made in {monthYearString}\nThere are {purchaseHIstory.Count} purchases this month\n");
            foreach (var purchaseId in purchaseHIstory)
            {
                Console.WriteLine($"\t{purchaseId}");
            }
        }
        private GetPurchasesByMonthAndYearResponse HandleGetPurchasesExceptions(Exception ex)
        {
            switch (ex.Source)
            {
                case "SplitiT":
                    switch (ex.Message)
                    {
                        case "InvalidParamsForGetPurchases":
                            return _responseGenerator.GetPurchasesByMonthAndYearResponse(status: 400, msg: "Not good params for this query");

                        case "InvalidParamsForGetPurchases-Month":
                            return _responseGenerator.GetPurchasesByMonthAndYearResponse(status: 400, msg: "Month should one of the following -> " +
                                "JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC");

                        case "InvalidParamsForGetPurchases-Year":
                            return _responseGenerator.GetPurchasesByMonthAndYearResponse(status: 400, msg: "Year should be a positive integer");
                    }
                    break;
            }
            return _responseGenerator.GetPurchasesByMonthAndYearResponse(status: 500, msg: "Unknown Error");
        }
        private AddPayloadResponse HandleAddPayloadExceptions(Exception ex)
        {
            switch (ex.Source)
            {
                case "Newtonsoft.Json":
                    return _responseGenerator.GetAddPayloadResponse(status: 400, msg: "Not a valid json format in request.payload");


                case "SplitiT":
                    switch (ex.Message)
                    {
                        case "JsonNotValid":
                            return _responseGenerator.GetAddPayloadResponse(status: 400, msg: "Json Schema is not supported for this source");

                        case "UnknownSource":
                            return _responseGenerator.GetAddPayloadResponse(status: 400, msg: "Unknown source");

                        case "TransactionIdEmpty":
                            return _responseGenerator.GetAddPayloadResponse(status: 401, msg: "Not an authorized TransactionId (TransactionIdEmpty)");

                        case "BadRequestAuthentication":
                            return _responseGenerator.GetAddPayloadResponse(status: 400, msg: "Bad request for authentication");

                        case "InsertingPayloadFailure":
                            return _responseGenerator.GetAddPayloadResponse(status: 500, msg: "Failed to upload a record of the payload to db");

                        case "BadRequest_ParamsEmpty":
                            return _responseGenerator.GetAddPayloadResponse(status: 400, msg: "Bad request, request should be of format {source:string, payload:string}");

                        case "SplitItServer":
                            return _responseGenerator.GetAddPayloadResponse(status: 500, msg: "SplitIt server Unknown Error");

                        case "SplitItServer_NotFound":
                            return _responseGenerator.GetAddPayloadResponse(status: 500, msg: "SplitIt server not found");

                        case "SplitItServer_BadRequestAuthentication":
                            return _responseGenerator.GetAddPayloadResponse(status: 500, msg: "Cold not authenticate with SplitIt server... bad request");

                        case "SplitItServer_Unauthorized":
                            return _responseGenerator.GetAddPayloadResponse(status: 401, msg: "Not an authorized TransactionId");

                        case "SplitItServer_Forbidden":
                            return _responseGenerator.GetAddPayloadResponse(status: 401, msg: "SplitIt server - Forbidden");
                        
                        default:
                            break;
                    }
                    break;
            }
            return _responseGenerator.GetAddPayloadResponse(status: 500, msg: "Unknown error");

        }
        private IList<PurchaseHistory> GetPurchaseHistoryObject(string source)
        {
            switch (source)
            {
                case "S1":
                    return _payload1Service.GetPurchaseHistory();
                case "S2":
                    return _payload2Service.GetPurchaseHistory();
                case "S3":
                    return _payload3Service.GetPurchaseHistory();
            }
            throw new Exception("UnknownSource");

        }
        private string GetTransactionId(String source)
        {
            switch (source)
            {
                case "S1":
                    return _payload1Service.GetTransactionId();

                case "S2":
                    return _payload2Service.GetTransactionId();

                case "S3":
                    return _payload3Service.GetTransactionId();
            }
            throw new Exception("UnknownSource");
        }
        private void InitPayloadService(JObject jObject, string payload, string source)
        {
            switch (source)
            {
                case "S1":
                    if (_payloadValidatorService.Validate(jObject, SourcesEnum.S1.ToString()))
                    {
                        _payload1Service.InitPayload(payload);
                    }
                    return;

                case "S2":
                    if (_payloadValidatorService.Validate(jObject, SourcesEnum.S2.ToString()))
                    {
                        _payload2Service.InitPayload(payload);
                    }
                    return;

                case "S3":
                    if (_payloadValidatorService.Validate(jObject, SourcesEnum.S3.ToString()))
                    {
                        _payload3Service.InitPayload(payload);
                    }
                    return;
            }
            throw new Exception("UnknownSource");
        }
    }
}