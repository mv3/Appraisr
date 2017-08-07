using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using Appraisr.Data;
using System.Web.Mvc;

namespace Appraisr.ViewModels.ClientViewModels
{
    public abstract class ClientBaseViewModel
    {
        public Client Client { get; set; } = new Client();       
        
    }
}