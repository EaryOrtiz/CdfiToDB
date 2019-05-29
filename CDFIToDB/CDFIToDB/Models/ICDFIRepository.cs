using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDFIToDB.Models
{
    public interface ICDFIRepository
    {
        IQueryable<CDFI> CDFIs { get;}
        IQueryable<Percepcion> Percepciones { get; }

        void SaveCDFI(CDFI Cdfi);
        void SavePercepcion(Percepcion percepcion);

        CDFI DeleteCDFI(int ID);
        Percepcion DeletePercepcion(int ID);
    }
}
