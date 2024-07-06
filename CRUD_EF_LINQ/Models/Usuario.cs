using System;
using System.Collections.Generic;

namespace CRUD_EF_LINQ.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Clave { get; set; }

    public int? Estado { get; set; }
}
