using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.CommandsQueries.IletisimBilgileri.Commands.DeleteIletisim;
using Contact.Application.CommandsQueries.Kisiler.Commands.DeleteKisi;
using Contact.Application.Interfaces.Repositories;
using FluentAssertions;
using MediatR;
using System;
using Xunit;

namespace Contact.CommandQuery.Tests.Commands
{
    public class DeleteKisiCommandHandlerTests : DependencyInjections
    {
        private readonly IIletisimRepository _iletisimRepository;
        private readonly IMediator _mediator;

        public DeleteKisiCommandHandlerTests()
        {
            _iletisimRepository = (IIletisimRepository)ServiceProvider.GetService(typeof(IIletisimRepository));
            _mediator= (IMediator)ServiceProvider.GetService(typeof(IMediator));
        }

        [Fact]
        public async void Handle_Should_Delete_Kisi_With_Invalid_Id()
        {
            var id = Guid.NewGuid();

            var command = new DeleteKisiCommand { Id = id };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<Response>();

            result.Success.Should().Be(false);
        }
                
    }
}
