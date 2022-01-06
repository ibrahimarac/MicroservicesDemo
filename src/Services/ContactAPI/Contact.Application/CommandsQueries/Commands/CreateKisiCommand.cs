using Contact.Application.Interfaces.Common;
using ContactReport.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Commands
{
    public class CreateKisiCommand:IRequest<Guid>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
    }

    public class CreateKisiCommandHandler : IRequestHandler<CreateKisiCommand, Guid>
    {
        private readonly IContactDbContext _context;

        public CreateKisiCommandHandler(IContactDbContext context)
        {
            _context = context;
        }

        public Task<Guid> Handle(CreateKisiCommand request, CancellationToken cancellationToken)
        {
            var kisi=new Kisi
            {

            }
        }
    }

}
