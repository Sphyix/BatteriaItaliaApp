using System;
using static BatteriaItaliaApp.Models.Enums;

namespace BatteriaItaliaApp.Models
{
    public class WorkOrder : Client
    {
        public string WorkId { get; set; }
        public string TipoOggetto { get; set; }
        public Stato Stato { get; set; }
        public Difficolta Difficolta { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }

        public static explicit operator WorkOrder(Item v)
        {
            throw new NotImplementedException();
        }
    }
}