
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
    
public partial class C6OrderMenu
{

    public int OrderMenuID { get; set; }

    public Nullable<int> Menu { get; set; }

    public Nullable<int> OrderID { get; set; }

    public int Kolvo { get; set; }



    public virtual C6Menu C6Menu { get; set; }

    public virtual C6Order C6Order { get; set; }

}

}
