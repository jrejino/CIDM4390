using System;
using domain.NOAAStationAggregate;
using domain.VatsimMETARAggregate;

namespace BookStore.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        INOAAStationRepository Stations { get; }
        IVatsimMETARRepository METARs { get; }
        int Complete();
    }
}