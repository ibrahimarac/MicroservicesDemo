
using Assesment.Core.Exceptions;
using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.CommandsQueries.IletisimBilgileri.Commands.DeleteIletisim;
using Contact.Application.Interfaces.Repositories;
using FluentAssertions;
using MediatR;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Contact.CommandQuery.Tests.Commands
{
    public class DeleteIletisimCommandHandlerTests : DependencyInjections
    {
        private readonly IIletisimRepository _iletisimRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DeleteIletisimCommandHandlerTests()
        {
            _mapper = (IMapper)ServiceProvider.GetService(typeof(IMapper));
            _iletisimRepository = (IIletisimRepository)ServiceProvider.GetService(typeof(IIletisimRepository));
            _mediator= (IMediator)ServiceProvider.GetService(typeof(IMediator));
        }

        [Fact]
        public async void Handle_ShouldDeleteIletisimWithInvalidId()
        {
            var id = Guid.NewGuid();

            var command = new DeleteIletisimCommand { Id = id };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<Response>();

            result.Success.Should().Be(false);
        }
                
    }
}
