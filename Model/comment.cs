//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class comment
    {
        public int id_comment { get; set; }
        public string content_cmt { get; set; }
        public Nullable<int> id_account { get; set; }
        public Nullable<int> id_ideas { get; set; }
        public System.DateTime time { get; set; }
    
        public virtual account account { get; set; }
        public virtual idea idea { get; set; }
    }
}
