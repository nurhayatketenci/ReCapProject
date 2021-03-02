using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string ProductAdded = "ürün eklendi";
        public static string ProductDelete = "ürün silindi";
        public static string ProductUpdate = "ürün güncellendi";
        public static string ProductNameInvalid = "ürün ismi gecersiz";
        public static List<Car> MaintenanceTime;
        public static string ProductListed="ürünler listelendi";
        public  static string CarHaveNoImage="resim yok";
        public static string pictureNotFound="resim bulunamadı";
        public  static string ImageExtensionInvalid="geçersiz";
        public static string MaxProduct="En çok 5 ürün eklenebilir";
    }
}
