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
    
    public partial class idea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public idea()
        {
            this.comments = new HashSet<comment>();
            this.reactions = new HashSet<reaction>();
        }
    
        public int id_ideas { get; set; }
        public Nullable<int> id_account { get; set; }
        public Nullable<int> thumb_up { get; set; }
        public Nullable<int> thumb_down { get; set; }
        public Nullable<int> views { get; set; }
        public System.DateTime ideas_date { get; set; }
        public string Content { get; set; }
        public Nullable<int> id_toppic { get; set; }
        public byte[] file { get; set; }
        public byte[] img { get; set; }
    
        public virtual account account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }
        public virtual topic topic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reaction> reactions { get; set; }
    }
}
