using BolsaIR.Application.Features.BrokerageNotes.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.ReadServices;

public sealed class BrokerageNoteReadService : IBrokerageNoteReadService
{
	private readonly BolsaIRDbContext _context;

	public BrokerageNoteReadService(BolsaIRDbContext context)
	{
		_context = context;
	}

	public async Task<bool> ExistsForBrokerAsync(Guid brokerId)
	{
		return await _context.BrokerageNotes
			.AsNoTracking()
			.AnyAsync(x => x.BrokerId == brokerId);
	}

	public async Task<BrokerageNote?> GetForProcessingAsync(
	Guid brokerageNoteId,
	CancellationToken cancellationToken = default)
	{
		return await _context.BrokerageNotes
			.Include(x => x.Operations)
				.ThenInclude(x => x.Asset)
			.FirstOrDefaultAsync(
				x => x.Id == brokerageNoteId,
				cancellationToken);
	}
}