using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDFIToDB.Models.ViewModel
{
    public class CFDIViewModel
    {
        public CDFI CDFI { get; set; }
        public Percepcion Percepcion { get; set; }
        public List<CDFI> CDFIs { get; set; }
        public List<Percepcion> Percepciones { get; set; }
    }
}
