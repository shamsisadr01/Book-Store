﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L5.Presentation.Facade
{
    class CacheKeys
    {
        public static string User(long id) => $"user-{id}";
        public static string UserToken(string hashToken) => $"tok-{hashToken}";
        public static string Product(string slug) => $"product-{slug}";
        public static string ProductSingle(string slug) => $"p-s-{slug}";
        public static string Categories = "categories";
    }
}
