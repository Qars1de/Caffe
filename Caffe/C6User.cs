
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
    
public partial class C6User
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public C6User()
    {

        this.C6Order = new HashSet<C6Order>();

        this.C6ShiftReporting = new HashSet<C6ShiftReporting>();

    }


    public int UserID { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Patronymic { get; set; }

    public Nullable<int> Phone { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public Nullable<int> UserStatus { get; set; }

    public Nullable<int> Role { get; set; }



    public virtual C6Role C6Role { get; set; }

    public virtual C6UserStatus C6UserStatus { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<C6Order> C6Order { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<C6ShiftReporting> C6ShiftReporting { get; set; }

}

}
