using Dev_Assignment.DAL.Data;
using Dev_Assignment.DAL.Models;
using Dev_Assignment.Services;
using Dev_Assignment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Dev_Assignment.Tests
{
    public class InsuranceServiceTests
    {
        List<InsuredItem> insuredItems;
        Mock<IDataContext> mockContext;
        IInsuranceService insuranceService;
        [SetUp]
        public void Setup()
        {
            #region build lists 
            insuredItems = new List<InsuredItem>{
                new InsuredItem { Id = 1, categoryId = 1, value = 2500, Name = "TV" },
                new InsuredItem { Id = 2, categoryId = 1, value = 500, Name = "Playstation 5" },
                new InsuredItem { Id = 3, categoryId = 1, value = 1500, Name = "Laptop" },
                new InsuredItem { Id = 4, categoryId = 1, value = 4000, Name = "Electric guitar" },

                new InsuredItem { Id = 5, categoryId = 2, value = 100, Name = "Shoes" },
                new InsuredItem { Id = 6, categoryId = 2, value = 2000, Name = "Suit" },
                new InsuredItem { Id = 7, categoryId = 2, value = 400, Name = "Jacket" },

                new InsuredItem { Id = 8, categoryId = 3, value = 2200, Name = "Oven" },
                new InsuredItem { Id = 9, categoryId = 3, value = 1500, Name = "Dishwasher" },
                new InsuredItem { Id = 10, categoryId = 3, value = 790, Name = "Microwave" }
                };
            #endregion

            #region DB context
            mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.InsuredItems).Returns(insuredItems.AsQueryable().BuildMockDbSet().Object);
            mockContext.Setup(c => c.InsuredItems.Add(It.IsAny<InsuredItem>()))
                .Callback<InsuredItem>(i=> insuredItems.Add(i));
            mockContext.Setup(c => c.SaveChanges()).Returns(1);
            #endregion

            insuranceService = new InsuranceService(mockContext.Object);
        }

        [Test]
        public async Task GetInsuredItemsAsyn_ReturnsAllItems()
        {
            var response = await insuranceService.GetInsuredItemsAsyn();

            Assert.IsNotNull(response);
            Assert.AreEqual(insuredItems.Count(), response.Count());
        }

        [Test]
        public async Task AddInsuredItemsAsyn_ReturnsProperId()
        {
            var newItem = new InsuredItem { categoryId = 1, Id = 40, Name = "new item", value = 29 };
            var response = await insuranceService.AddInsuredItemAsyn(newItem);

            Assert.IsNotNull(response);
            Assert.AreEqual(response, newItem.Id);
        }

        [Test]
        public async Task AddInsuredItemsAsyn_ReturnsTrue()
        {
            var newItem = new InsuredItem { categoryId = 1, Id = 40, Name = "new item", value = 29 };
            var response = await insuranceService.DeleteInsuredItemAsyn(1);

            Assert.IsTrue(response);
        }
    }
}