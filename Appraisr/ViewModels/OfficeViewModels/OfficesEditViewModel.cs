using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appraisr.ViewModels.OfficeViewModels
{
    public class OfficesEditViewModel : OfficesBaseViewModel
    {
        public int Id
        {
            get { return Office.Id; }
            set { Office.Id = value; }
        }
    }
}