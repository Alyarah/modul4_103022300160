using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4_103022300160
{
    public class KodeProduk
    {
        public enum Kode { Laptop, Smartphone, Tablet, Headset, Keyboard, Mouse, Printer, Monitor, Smartwatch, Kamera}
        public static string getKodeProduk(Kode kode)
        {
            string[] kodeElektronik = { "E100", "E101", "E102", "E103", "E104", "E105", "E106", "E107", "E108", "E109" };
            return kodeElektronik[(int)kode];
        }
    }
}
