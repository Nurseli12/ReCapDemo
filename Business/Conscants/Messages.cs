using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Conscants
{
    public static class Messages
    {
        //for ProductManager Messages
        public static string ProductAdded = "Product added";
        public static string ProductAddError = "Product couldn't be added";
        public static string ProductUpdate = "Product updated";
        public static string ProductUpdateError = "Product couldn't be updated";
        public static string ProductDelete = "Product deleted";
        public static string ProductDeleteError = "Product couldn't be deleted";
        public static string ProductListed = "Product Listed";
        public static string ProductErrorListed = "Product couldn't be listed";
        //for CustomerManager Messages
        public static string CustomerAdded = "Customer added";
        public static string CustomerAddError = "Customer couldn't be added";
        public static string isAvailable = "Car is Rental";
        public static string isnotAvailable = "Car isn't Rental Now";

        //for CarImageManager Messages

        public static string CarImageAdded = "Car Image added";
        public static string CarImageNotFound = "Car Image couldn't be founded";
        public static string CarImageDeleted = "Car Image is deleted";
        public static string CarImageUpdated = "Car Image is Updated";
    }
}