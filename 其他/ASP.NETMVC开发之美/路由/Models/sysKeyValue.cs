//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 路由.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [Bind(Exclude = "")]
    public partial class sysKeyValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysKeyValue()
        {
            this.sysOrganStruct = new HashSet<sysOrganStruct>();
            this.sysRole = new HashSet<sysRole>();
            this.wfProcess = new HashSet<wfProcess>();
            this.wfRequestForm = new HashSet<wfRequestForm>();
            this.wfRequestForm1 = new HashSet<wfRequestForm>();
            this.wfWorkNodes = new HashSet<wfWorkNodes>();
            this.wfWorkNodes1 = new HashSet<wfWorkNodes>();
        }
    
        public int KID { get; set; }
        public int ParentID { get; set; }
        public int KType { get; set; }
        public string KName { get; set; }
        public string Kvalue { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("")]
        [Display(Name = "备注")]
        public string KRemark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysOrganStruct> sysOrganStruct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysRole> sysRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfProcess> wfProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfRequestForm> wfRequestForm { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfRequestForm> wfRequestForm1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfWorkNodes> wfWorkNodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfWorkNodes> wfWorkNodes1 { get; set; }
    }
}
