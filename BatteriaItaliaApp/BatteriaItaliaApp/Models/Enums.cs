using System;
using System.Collections.Generic;
using System.Text;

namespace BatteriaItaliaApp.Models
{
    public class Enums
    {
        public enum Stato
        {
            Preventivo,
            DaFare,
            InAttesa,
            Finito,
            Ritirato
        }

        public enum Difficolta
        {
            Facile,
            Medio,
            Difficile
        }
    }
}
