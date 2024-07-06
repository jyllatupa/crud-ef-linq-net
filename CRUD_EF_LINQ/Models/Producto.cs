using System;
using System.Collections.Generic;

namespace CRUD_EF_LINQ.Models;

public partial class Producto
{
    public int CodProducto { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }
}
