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
    
    public partial class Installation_location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Installation_location()
        {
            this.Installed_equipment = new HashSet<Installed_equipment>();
        }
    
        public int Id { get; set; }
        public int Id_adress { get; set; }
        public string Connection_point { get; set; }
        public int Id_coordinates { get; set; }
    
        public virtual Adress Adress { get; set; }
        public virtual Coordinates Coordinates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Installed_equipment> Installed_equipment { get; set; }
    }
}