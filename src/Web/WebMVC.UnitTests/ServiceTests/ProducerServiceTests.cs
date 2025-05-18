using GreenPipes.Caching;
using IntegrationEvents;
using MassTransit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Services;
using Xunit;

namespace WebMVC.UnitTests.ServiceTests
{
    public class ProducerServiceTests
    {
        private readonly ProducerService _sut;
        private readonly Mock<IPublishEndpoint> _mockPublishEndpoint;
        public ProducerServiceTests()
        {
            _mockPublishEndpoint = new Mock<IPublishEndpoint>();
            _sut = new ProducerService(_mockPublishEndpoint.Object);
        }

        [Fact]
        public async Task AddPlate_WithMessageEvent_ShouldAddMessageToQueue()
        {
            //arrange
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            var TestSample = new Sample { Registration = "REG" };
            _mockPublishEndpoint.Setup(x => x.Publish(TestSample, cancellationToken));

            //act
            var result = await _sut.AddPlate(TestSample);
            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task ReservePlate_WithMessageEvent_ShouldAddMessageToQueue()
        {
            //arrange
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            
            _mockPublishEndpoint.Setup(x => x.Publish("REG", cancellationToken));

            //act
            var result = await _sut.ReservePlate("REG");
            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task UnreservePlate_WithMessageEvent_ShouldAddMessageToQueue()
        {
            //arrange
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;


            _mockPublishEndpoint.Setup(x => x.Publish("REG", cancellationToken));

            //act
            var result = await _sut.UnreservePlate("REG");
            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task SellPlate_WithMessageEvent_ShouldAddMessageToQueue()
        {
            //arrange
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;


            _mockPublishEndpoint.Setup(x => x.Publish("REG", cancellationToken));

            //act
            var result = await _sut.SellPlate("REG");
            //assert
            Assert.True(result);
        }
    }
}
