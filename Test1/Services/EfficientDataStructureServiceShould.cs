using NUnit.Framework;
using SplitiT.Services.EfficientDataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Services
{
    internal class EfficientDataStructureServiceShould
    {
        private EfficientDataStructureService _efficientDataStructureService;
        [SetUp]
        public void Setup()
        {
            _efficientDataStructureService = new EfficientDataStructureService();
            _efficientDataStructureService._efficientDataStructure.Add("NOV-9999", new List<string>() { "ID" });

        }

        [Test]
        public void AddPurchaseToDictionary_ReturnTrue()
        {
            var response = _efficientDataStructureService.AddPurchaseToDictionary("NOV-1991", "id1");

            Assert.AreEqual(response, true);
        }
        [Test]
        public void AddPurchaseToDictionary_ReturnFalse()
        {
            var response = _efficientDataStructureService.AddPurchaseToDictionary("NOV-9999", "ID");

            Assert.AreEqual(response, false);
        }

    }
}
