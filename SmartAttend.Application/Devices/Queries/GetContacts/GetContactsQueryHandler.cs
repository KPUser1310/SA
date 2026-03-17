using MediatR;
using SmartAttend.Application.Common.Inferfaces;
using Microsoft.EntityFrameworkCore;

namespace SmartAttend.Application.Devices.Queries.GetContacts
{
    public class GetContactsQueryHandler
        : IRequestHandler<GetContactsQuery, List<ContactDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetContactsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactDto>> Handle(GetContactsQuery request,CancellationToken cancellationToken)
        {
            var contacts = await _context.Accounts
                .AsNoTracking()
                .Where(x => x.CustomerId == request.customerId
                            && x.Status
                            && !x.IsDelete)
                .OrderBy(x => x.FirstName)
                .Select(x => new ContactDto
                {
                    AccountId = x.AccountId,
                    Name = x.FirstName + " " + x.LastName
                })
                .ToListAsync(cancellationToken);

            return contacts;
        }
    }
}