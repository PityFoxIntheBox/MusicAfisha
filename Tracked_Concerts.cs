//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicSmth
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tracked_Concerts
    {
        public int ID_Track { get; set; }
        public Nullable<int> ID_User { get; set; }
        public Nullable<int> ID_Concert { get; set; }
    
        public virtual Concerts Concerts { get; set; }
        public virtual Users Users { get; set; }
    }
}
