using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SplitiT.Models.Sources;
using SplitiT.Services;
using SplitiT.Services.DataBase.AddPurchaseHistory;
using SplitiT.Services.EfficientDataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;

namespace Test1.Services
{
    public class AddPurchaseHistoryShould
    {
        private Mock<EfficientDataStructureService> _efficientDataStructureServiceMock;
        private Mock<ILogger<AddPurchaseHistory>> _logger;
        private AddPurchaseHistory _addPurchaseHistoryMock;
        private Mock<ResponseGenerator> _responseGeneratorMock;

        [SetUp]
        public void Setup()
        {
            _responseGeneratorMock = new Mock<ResponseGenerator>();
            _efficientDataStructureServiceMock = new Mock<EfficientDataStructureService>();
            _logger = new Mock<ILogger<AddPurchaseHistory>>();

            _addPurchaseHistoryMock = new AddPurchaseHistory(_responseGeneratorMock.Object, _logger.Object, _efficientDataStructureServiceMock.Object);
         }

    [Test]
    public void ReturnFalse_ValidatePurchase_BadPurchaseHistoryObject()
    {
        var response =  _addPurchaseHistoryMock.AddEntirePurchaseHistoryArray(new List<PurchaseHistory> { });
        Assert.AreEqual(response.Total, 0);
        Assert.AreEqual(response.Status, 200);
        Assert.AreEqual(response.Message, "");
        Assert.AreEqual(response.Total, 0);
    }
}
}
