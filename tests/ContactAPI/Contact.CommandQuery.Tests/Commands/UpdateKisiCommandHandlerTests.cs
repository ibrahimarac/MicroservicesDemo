using Assesment.Core.Results;
using AutoMapper;
using Contact.Application.CommandsQueries.Kisiler.Commands.CreateKisi;
using Contact.Application.CommandsQueries.Kisiler.Commands.UpdateKisi;
using Contact.Application.Interfaces.Repositories;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Contact.Application.Dtos;
using Contact.Domain.Entities;

namespace Contact.CommandQuery.Tests.Commands
{
    public class UpdateKisiCommandHandlerTests : DependencyInjections
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMediator _mediator;

        public UpdateKisiCommandHandlerTests()
        {
            _kisiRepository = (IKisiRepository)ServiceProvider.GetService(typeof(IKisiRepository));
            _mediator= (IMediator)ServiceProvider.GetService(typeof(IMediator));
        }


        [Theory]
        [InlineData("yeniAd", "yeniSoyad","yeniFirma")]
        public async void UpdateKisi_WhenKisiIsNotNull_Should_Update_Kisi(string ad,string soyad,string firma)
        {
            var kisiEntity = (await _kisiRepository.GetAll()).OrderByDescending(k => k.CreateDate)
                .First();

            var command = new UpdateKisiCommand
            {
                Id = kisiEntity.Id,
                Kisi = new KisiUpdateDto
                {
                    Ad = "Ad",
                    Soyad = "Soyad",
                    Firma = "Firma"
                }
            };

            //güncellemeyi deneyelim

            command.Kisi.Ad = ad;
            command.Kisi.Soyad = soyad;
            command.Kisi.Firma = firma;

            var result=await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<Kisi>>();

            result.Success.Should().Be(true);

            (result as DataResponse<Kisi>).Data.LastupDate.Should().BeCloseTo(DateTime.Now,TimeSpan.FromSeconds(10));
        }


        [Fact]
        public async void Should_Ad_Max_Length_30_Validator_On_Update()
        {
            var kisiEntity = (await _kisiRepository.GetAll()).OrderByDescending(k => k.CreateDate)
                .First();

            var command = new UpdateKisiCommand
            {
                Id = kisiEntity.Id,
                Kisi = new KisiUpdateDto
                {
                    Ad = "Ad greater than 30.So this will trigger validation result",
                    Soyad = "Soyad",
                    Firma = "Firma"
                }                
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

        [Fact]
        public async void Should_Soyad_Max_Length_30_Validator_On_Update()
        {
            var kisiEntity = (await _kisiRepository.GetAll()).OrderByDescending(k => k.CreateDate)
                .First();

            var command = new UpdateKisiCommand
            {
                Id = kisiEntity.Id,
                Kisi = new KisiUpdateDto
                {
                    Ad = "Ad greater than 30.So this will trigger validation result",
                    Soyad = "Soyad",
                    Firma = "Firma"
                }
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

        [Fact]
        public async void Should_Firma_Max_Length_30_Validator_On_Update()
        {
            var kisiEntity = (await _kisiRepository.GetAll()).OrderByDescending(k => k.CreateDate)
                .First();

            var command = new UpdateKisiCommand
            {
                Id = kisiEntity.Id,
                Kisi = new KisiUpdateDto
                {
                    Ad = "Ad greater than 30.So this will trigger validation result",
                    Soyad = "Soyad",
                    Firma = "Firma"
                }
            };

            var result = await _mediator.Send(command);

            result.Should().BeOfType<DataResponse<IEnumerable<ValidationFailure>>>();

            result.Success.Should().Be(false);
        }

    }
}
