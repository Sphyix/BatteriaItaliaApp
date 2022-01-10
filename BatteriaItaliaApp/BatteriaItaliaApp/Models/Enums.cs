using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Ritirato,
            NonFattibile
        }

        public enum Difficolta
        {
            [Description("Green")]
            Facile,
            [Description("Yellow")]
            Medio,
            [Description("Red")]
            Difficile
        }

        public enum Errors
        {
            EmptyUser,
            EmptyPsw,
            EmptyBoth,
            WrongLogin
        }
    }
}
