
using Assesment.Core.Exceptions;
using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.CommandsQueries.IletisimBilgileri.Commands.CreateIletisim;
using Contact.Application.Interfaces.Repositories;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions.Specialized;

namespace Contact.CommandQuery.Tests.Commands
{
    public class CreateIletisimCommandHandlerTests:DependencyInjections
    {
        private readonly IIletisimRepository _iletisimRepository;
        private readonly IKisiRepository _kisiRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateIletisimCommandHandlerTests()
        {
            _mapper = (IMapper)ServiceProvider.GetService(typeof(IMapper));
            _iletisimRepository = (IIletisimRepository)ServiceProvider.GetService(typeof(IIletisimRepository));
            _kisiRepository=(IKisiRepository)ServiceProvider.GetService(typeof(IKisiRepository));
            _mediator= (IMediator)ServiceProvider.GetService(typeof(IMediator));
        }

        [Fact]
        public async void Handle_ShouldReturnCreatedIletisimId()
        {
            var kisi = await _kisiRepository.GetAll();

            var iletisim = new CreateIletisimCommand
            {
                KisiId = kisi.First().Id,
                Email = "email@email.com",
                Konum = "konum",
                Telefon = "telefon"
            };

            var result=await _mediator.Send(iletisim);

            result.Should().BeOfType<DataResponse<Guid>>();
        }

        [Fact]
        public async void ShouldRequireValidIletisimEmail()
        {
            var kisi = await _kisiRepository.GetAll();
            
            var command = new CreateIletisimCommand
            {
                KisiId = kisi.First().Id,
                Email = "invalid email", //is not valid email
                Konum = "konum",
                Telefon = "telefonghghghghghghghghghghghghghghghghghg"
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false); 
        }


        [Fact]
        public async void ShouldRequireValidTelNo()
        {
            var kisi = await _kisiRepository.GetAll();
            var command = new CreateIletisimCommand
            {
                KisiId = kisi.First().Id,
                Email = "invalid email",
                Konum = "konum",
                Telefon = "xxxxxxxxxxxxxxxxxxxxxx" //max length 14
            };

            var result= await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

    }
}
