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
    
    public partial class Abonent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Id_installed_equipment { get; set; }
        public int Id_phone { get; set; }
    
        public virtual Installed_equipment Installed_equipment { get; set; }
        public virtual Phone Phone { get; set; }
    }
}