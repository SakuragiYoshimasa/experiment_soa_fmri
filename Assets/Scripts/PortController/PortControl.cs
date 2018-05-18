using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Runtime.InteropServices;

namespace inpoutx64{
    class PortControl {
        [DllImport("inpoutx64", EntryPoint = "Out32")]
        public static extern void Output(int adress, int value); // decimal
        [DllImport("inpoutx64")]
        public static extern void DlPortWritePortUshort(ushort PortAddress, ushort Data);
        [DllImport("inpoutx64")]
        public static extern bool IsInpOutDriverOpen();
    }
}
