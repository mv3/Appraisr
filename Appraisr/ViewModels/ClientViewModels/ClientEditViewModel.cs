using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appraisr.ViewModels.ClientViewModels
{
    public class ClientEditViewModel : ClientBaseViewModel
    {
        public int Id
        {
            get { return Client.Id; }
            set { Client.Id = value; }
        }
    }
}