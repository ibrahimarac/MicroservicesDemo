using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Entities;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Commands.CreateKisi
{
    public class CreateKisiCommand:IRequest<DataResponse<Guid>>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
    }

    public class CreateKisiCommandHandler : IRequestHandler<CreateKisiCommand, DataResponse<Guid>>
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMapper _mapper;

        public CreateKisiCommandHandler(IKisiRepository kisiRepository,IMapper mapper)
        {
            _kisiRepository = kisiRepository;
            _mapper = mapper;
        }

        public async Task<DataResponse<Guid>> Handle(CreateKisiCommand request, CancellationToken cancellationToken)
        {
            var kisiEntity = _mapper.Map<CreateKisiCommand, Kisi>(request);
            await _kisiRepository.Add(kisiEntity);
            return new SuccessDataResponse<Guid>(kisiEntity.Id);
        }
    }

}
