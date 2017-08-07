using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appraisr.Models;
using Appraisr.Data;
using System.Web.Mvc;

namespace Appraisr.ViewModels.OfficeViewModels
{
    public abstract class OfficesBaseViewModel
    {
        public Office Office { get; set; } = new Office();

       
    }
}