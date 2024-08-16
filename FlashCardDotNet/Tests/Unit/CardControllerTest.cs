using FlashCardDotNet.Controllers;
using FlashCardDotNet.Entities;
using FlashCardDotNet.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace FlashCardDotNet.Tests.Unit
{
    public class CardControllerTest
    {
        private CardController cardController;
        private Mock<CardServiceInterface> mockService;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<CardServiceInterface>();
            cardController = new CardController(mockService.Object);
        }

        [Test]
        public async Task PostCardSuccess()
        {
            Card card = new Card();
            mockService.Setup(service => service.AddACard(It.IsAny<Card>())).ReturnsAsync(card);

            dynamic result = await cardController.AddCard(card);

            var actionResult = result as CreatedAtActionResult;
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.StatusCode, Is.EqualTo(200));
            Assert.That(actionResult.Value, Is.EqualTo(card));
        }
    }
}
