//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Telecome
{
    using System;
    using System.Collections.Generic;
    
    public partial class Port
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Port()
        {
            this.Installed_equipment = new HashSet<Installed_equipment>();
        }
    
        public int Id { get; set; }
        public int Id_port_type { get; set; }
        public int Count { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Installed_equipment> Installed_equipment { get; set; }
        public virtual Port_type Port_type { get; set; }
    }
}
