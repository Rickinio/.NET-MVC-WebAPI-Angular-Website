//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace byNadiaRapti.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categories
    {
        public Categories()
        {
            this.Images = new HashSet<Images>();
        }
    
        public int Id { get; set; }
        public string Category { get; set; }
    
        public virtual ICollection<Images> Images { get; set; }
    }
}
