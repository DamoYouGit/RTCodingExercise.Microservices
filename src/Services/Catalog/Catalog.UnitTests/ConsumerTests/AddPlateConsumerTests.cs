using Catalog.API.Interfaces;
using Catalog.API.Services;
using Catalog.Domain;
using IntegrationEvents;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.UnitTests.ConsumerTests
{
    public class AddPlateConsumerTests
    {
        //public async Task Consume_withParams_updateDB() 
        //{
        //    //arrange
        //    ConsumeContext<Sample> context = ConsumeContext<Sample>();
            
        //    var plate = new Plate { Registration = "REG" };
        //    Mock<IPlateRepository> mockREpo = new Mock<IPlateRepository>();
        //    mockREpo.Setup(x => x.AddPlate(plate));

        //    var sut = new AddPlateConsumer(mockREpo.Object);

        //    //act
        //    await sut.Consume(context);
        //}

        //MassTransit test harness only available from version 8
        //currently on 7
        //public async Task Consume_withParams_updateDB()
        //{
            
        //    await using var provider = new ServiceCollection()
        //    .AddMassTransitTestHarness(cfg =>
        //    {
        //        cfg.AddConsumer<SubmitOrderConsumer>();
        //    })
        //.BuildServiceProvider(true);
        //}




    }
}
