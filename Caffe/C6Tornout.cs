
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Caffe
{

using System;
    using System.Collections.Generic;
    
public partial class C6Tornout
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public C6Tornout()
    {

        this.C6ShiftReporting = new HashSet<C6ShiftReporting>();

    }


    public int TornoutID { get; set; }

    public string Name { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<C6ShiftReporting> C6ShiftReporting { get; set; }

}

}