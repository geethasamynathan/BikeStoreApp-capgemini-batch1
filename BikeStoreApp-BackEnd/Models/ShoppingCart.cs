﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeStoreApp_BackEnd.Models;

public partial class ShoppingCart
{
    [Key]
    public int CartId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
