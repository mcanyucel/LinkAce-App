using LinkAce_Mobile.Models;

namespace LinkAce_Mobile.Repositories;

internal interface ILinkRepository
{
    Task<IEnumerable<LinkAceLink>> GetAllLinks();
}
