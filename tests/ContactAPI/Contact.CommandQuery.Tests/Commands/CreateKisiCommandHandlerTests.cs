using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.CommandsQueries.Kisiler.Commands.CreateKisi;
using Contact.Application.Interfaces.Repositories;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using Xunit;

namespace Contact.CommandQuery.Tests.Commands
{
    public class CreateKisiCommandHandlerTests : DependencyInjections
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateKisiCommandHandlerTests()
        {
            _mapper = (IMapper)ServiceProvider.GetService(typeof(IMapper));
            _kisiRepository = (IKisiRepository)ServiceProvider.GetService(typeof(IKisiRepository));
            _mediator= (IMediator)ServiceProvider.GetService(typeof(IMediator));
        }

        [Fact]
        public async void Handle_ShouldReturnCreatedKisiId()
        {
            var kisi = new CreateKisiCommand
            {
                Ad="Adı",
                Soyad="Soyadı",
                Firma="Firma"                
            };

            var result=await _mediator.Send(kisi);

            result.Should().BeOfType<DataResponse<Guid>>();
        }

        [Fact]
        public async void Should_Require_Ad_On_Adding()
        {
            var command = new CreateKisiCommand
            {
                Soyad="Soyad",
                Firma="Firma"
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false); 
        }

        [Fact]
        public async void Should_Require_Soyad_On_Adding()
        {
            var command = new CreateKisiCommand
            {
                Ad = "Ad",
                Firma = "Firma"
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

        [Fact]
        public async void Should_Require_Firma_On_Adding()
        {
            var command = new CreateKisiCommand
            {
                Soyad = "Soyad",
                Ad = "Ad"
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

        [Fact]
        public async void Should_Ad_Max_Length_30_Validator()
        {
            var command = new CreateKisiCommand
            {
                Ad="Ad greater than 30.So this will trigger validation result",
                Soyad = "Soyad",
                Firma = "Firma"
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

        [Fact]
        public async void Should_Soyad_Max_Length_30_Validator()
        {
            var command = new CreateKisiCommand
            {
                Ad = "Ad",
                Soyad = "Ad greater than 30.So this will trigger validation result",
                Firma = "Firma"
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

        [Fact]
        public async void Should_Firma_Max_Length_30_Validator()
        {
            var command = new CreateKisiCommand
            {
                Ad = "Ad",
                Soyad = "Soyad",
                Firma = "Ad greater than 30.So this will trigger validation result"
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

    }
}
