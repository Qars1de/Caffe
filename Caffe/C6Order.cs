
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
    
public partial class C6Order
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public C6Order()
    {

        this.C6OrderMenu = new HashSet<C6OrderMenu>();

    }


    public int OrderID { get; set; }

    public Nullable<System.DateTime> Date { get; set; }

    public Nullable<int> UserID { get; set; }

    public Nullable<int> OrderStatus { get; set; }



    public virtual C6OrderStatus C6OrderStatus { get; set; }

    public virtual C6User C6User { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<C6OrderMenu> C6OrderMenu { get; set; }

}

}
