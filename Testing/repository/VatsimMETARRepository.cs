using System.Collections.Generic;
using System.Linq;
using domain;
using domain.VatsimMETARAggregate;

namespace repository
{
    public class VatsimMETARRepository : GenericRepository<VatsimMETAR>, IVatsimMETARRepository
    {
        public VatsimMETARRepository(WebApiDbContext context) : base(context)
        {
            
        }

        //place data retrieval methods here
    }
}