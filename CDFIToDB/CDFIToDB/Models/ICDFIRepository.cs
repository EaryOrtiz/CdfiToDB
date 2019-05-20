using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDFIToDB.Models
{
    public interface ICDFIRepository
    {
        IQueryable<CDFI> CDFIs { get;}
        void SaveCDFI(CDFI Cdfi);
        CDFI DeleteCDFI(int ID);
    }
}
