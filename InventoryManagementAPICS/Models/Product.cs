using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace InventoryManagementAPICS.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Rate { get; set; }

    public int Category { get; set; }

    public string? Description { get; set; }

    [ValidateNever]
    public virtual Category CategoryNavigation { get; set; } = null!;
}
