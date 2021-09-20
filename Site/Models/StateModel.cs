using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class StateModel
    {
        public int FilmSayisi { get; set; }
        public int SiparisSayisi { get; set; }
        public int BeklenenSiparisSayisi { get; set; }
        public int KargolanSiparisSayisi { get; set; }
        public int TamamlananSiparisSayisi { get; set; }
        public int PaketlenenSiparisSayisi { get; set; }
        public int KiralanasSayisi { get; set; }
        public int BeklenenKiralıkSayisi { get; set; }
        public int KargolanKiralıkSayisi { get; set; }
        public int TamamlananKiralananSayisi { get; set; }
        public int PaketlenenKiralıkSayisi { get; set; }
        public int ToplamKiralamaFiyatı { get; set; }

    }
}