using PG_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PG_Project.ViewModel
{
    public class PhotographerClient
    {
        public IEnumerable<PG> photographers { get; set; }
        public Client Client { get; set; }
    }
}