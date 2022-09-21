﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string ProductCountOfCategoryError = "Kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExits = "Bu isimde zaten başka bir ürün var.";
        public static string CategoryLimitExceeded = "Kategori limiti aşıldı, yeni ürün eklenemiyor.";
    }
}
