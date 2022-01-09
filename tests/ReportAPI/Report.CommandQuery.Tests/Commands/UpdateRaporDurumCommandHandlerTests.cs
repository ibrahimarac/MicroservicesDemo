using Assesment.Core.Results;
using AutoMapper;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.UpdateRaporDurum;
using Report.Application.Dtos;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Report.CommandQuery.Tests.Commands
{
    public class UpdateRaporDurumCommandHandlerTests : DependencyInjections
    {
        private readonly IRaporDurumRepository _raporDurumRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateRaporDurumCommandHandlerTests()
        {
            _raporDurumRepository = (IRaporDurumRepository)ServiceProvider.GetService(typeof(IRaporDurumRepository));
            _mediator= (IMediator)ServiceProvider.GetService(typeof(IMediator));
            _mapper = (IMapper)ServiceProvider.GetService(typeof(IMapper));
        }



        [Theory]
        [InlineData("Yeni Rapor Durumu")]
        public async void Update_Rapor_Durum_When_RaporDurum_IsNotNull_Should_Updated(string durum)
        {
            var raporDurumEntity = (await _raporDurumRepository.GetAll()).OrderByDescending(k => k.CreateDate)
                .Skip(1).Take(1).First();

            var command = new UpdateRaporDurumCommand
            {
                Durum = raporDurumEntity.Durum,
                Id = raporDurumEntity.Id
            };

            //güncellemeyi deneyelim

            command.Durum = durum;

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<RaporDurum>>();

            result.Success.Should().Be(true);

            (result as DataResponse<RaporDurum>).Data.LastupDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(10));
        }


    }
}
