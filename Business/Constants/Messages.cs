using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductDelete = "ürün silindi";
        public static string ProductUpdate = "ürün güncellendi";
        public static string ProductNameInvalid = "ürün ismi gecersiz";
        internal static List<Car> MaintenanceTime;
        internal static string ProductListed;
    }
}
