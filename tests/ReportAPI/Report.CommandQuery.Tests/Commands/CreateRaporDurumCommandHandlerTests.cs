using Assesment.Core.Results;
using AutoMapper;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.CreateRaporDurum;
using Report.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace Report.CommandQuery.Tests.Commands
{
    public class CreateRaporDurumCommandHandlerTests : DependencyInjections
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IRaporDurumRepository _raporDurumRepository;

        public CreateRaporDurumCommandHandlerTests()
        {
            _mapper = (IMapper)ServiceProvider.GetService(typeof(IMapper));
            _mediator= (IMediator)ServiceProvider.GetService(typeof(IMediator));
            _raporDurumRepository = (IRaporDurumRepository)ServiceProvider.GetService(typeof(IRaporDurumRepository));
        }

        [Fact]
        public async void Handle_When_Rapor_Not_Null_Should_Return_Created_Rapor_Id()
        {
            var raporDurum = new CreateRaporDurumCommand
            {
                Durum="Rapor Added"                
            };

            var result=await _mediator.Send(raporDurum);

            result.Should().BeOfType<DataResponse<Guid>>();
        }


        [Fact]
        public async void Handle_When_RaporDurum_CreateDate_Should_Set()
        {
            var raporDurum = new CreateRaporDurumCommand
            {
                Durum = "Rapor Added"
            };

            var result = await _mediator.Send(raporDurum);

            var dataResult = result as DataResponse<Guid>;

            result.Should().BeOfType<DataResponse<Guid>>();

            var raporDurumInDb = await _raporDurumRepository.GetById(dataResult.Data);

            dataResult.Data.Should().Be(raporDurumInDb.Id);

        }


        [Fact]
        public async void Should_Require_Rapor_Durum_Required_Validator()
        {
            var command = new CreateRaporDurumCommand();

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false); 
        }


        [Fact]
        public async void Should_Require_Rapor_Durum_Max_Length_50_Validator()
        {
            var command = new CreateRaporDurumCommand
            {
                Durum="This value string length greater than 50. So this will trigger Validation Error Result"
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

    }
}
