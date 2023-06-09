//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeneralDepartmentTerminal.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pass()
        {
            this.PassDocument = new HashSet<PassDocument>();
            this.PassLog = new HashSet<PassLog>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patromic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string PassportSeria { get; set; }
        public string PassportNumber { get; set; }
        public byte[] Photo { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public string VisitPurpose { get; set; }
        public int PassStatusId { get; set; }
        public Nullable<int> UserId { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual PassStatus PassStatus { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PassDocument> PassDocument { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PassLog> PassLog { get; set; }
    }
}
