using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialScanner.Model
{
    public interface IScannerToolsBarrel
    {
        (Mat, String) BarrelsScanner();
    }
}

