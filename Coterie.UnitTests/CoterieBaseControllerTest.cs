using Coterie.Api.Interfaces;
using Coterie.Api.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.UnitTests
{
    public class CoterieBaseControllerTest
    {
        // Sample Moq setup
        protected Mock<IRatingService> MockTestService;

        protected RatingService RatingService;

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            MockTestService = new Mock<IRatingService>();

            RatingService = new RatingService();
        }

        [Test]
        public void GetRating_Returns_ExpectedGivenExample()
        {
            // Arrange


            // Assert

            // Act
        }

        [TearDown]
        public void Cleanup()
        {
            // Sample reset after each test is ran
            MockTestService.Reset();
        }
    }
}
