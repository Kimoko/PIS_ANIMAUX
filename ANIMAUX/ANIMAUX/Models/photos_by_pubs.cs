//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ANIMAUX.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class photos_by_pubs
    {
        public string photo_url { get; set; }
        public int pub_id { get; set; }
    
        public virtual publications publications { get; set; }
    }
}