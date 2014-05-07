using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using byNadiaRapti.Models;

namespace byNadiaRapti.Models
{
    public class UploadedImagesDetails
    {
        public string Category { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}