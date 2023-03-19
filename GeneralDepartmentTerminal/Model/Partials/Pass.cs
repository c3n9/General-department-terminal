using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDepartmentTerminal.Model
{
    public partial class Pass
    {
        public string Passport
        {
            get
            {
                return $"{PassportSeria} {PassportNumber}";
            }
        }
    }
}
