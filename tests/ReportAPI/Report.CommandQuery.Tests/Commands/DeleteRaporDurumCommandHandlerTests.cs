using Assesment.Core.Results;
using FluentAssertions;
using MediatR;
using Report.Application.CommandQueries.RaporDurumIslemleri.Commands.DeleteRaporDurum;
using Report.Application.Interfaces.Repositories;
using System;
using System.Linq;
using Xunit;

namespace Report.CommandQuery.Tests.Commands
{
    public class DeleteRaporDurumCommandHandlerTests : DependencyInjections
    {
        private readonly IRaporDurumRepository _raporDurumRepository;
        private readonly IRaporRepository _raporRepository;
        private readonly IMediator _mediator;

        public DeleteRaporDurumCommandHandlerTests()
        {
            _raporDurumRepository = (IRaporDurumRepository)ServiceProvider.GetService(typeof(IRaporDurumRepository));
            _raporRepository=(IRaporRepository)ServiceProvider.GetService(typeof(IRaporRepository));
            _mediator= (IMediator)ServiceProvider.GetService(typeof(IMediator));
        }

        [Fact]
        public async void Handle_Should_Delete_When_Id_Invalid()
        {
            var id = Guid.NewGuid();

            var command = new DeleteRaporDurumCommand
            {
                Id=id
            };

            var result=await _mediator.Send(command);

            result.Should().BeOfType<Response>();

            result.Success.Should().Be(false);
        }

        [Fact]
        public async void Handle_Remove_RaporDurum_When_Id_Is_Correct()
        {
            var entities = await _raporDurumRepository.GetAll();

            var id = entities.OrderByDescending(rd => rd.CreateDate).First().Id;

            var command = new DeleteRaporDurumCommand
            {
                Id=id
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<Response>();

            result.Success.Should().Be(true); 
        }

    }
}
