using System;
using System.Collections.Generic;
using System.Text;
using TWD.Core.Entities.Concrete;

namespace TWD.Northwind.BLL.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product is added";
        public static string ProductUpdated = "Product is updated";
        public static string ProductDeleted = "Product is deleted";

        public static string CategoryAdded = "Category is added";
        public static string CategoryUpdated = "Category is updated";
        public static string CategoryDeleted = "Category is deleted";

        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password is wrong";
        public static string SuccesfulLogin = "Login is succesfull";
        public static string UserAlreadyExists = "User already exists";
        public static string UserRegistered = "User is succesfully registered";
        public static string AccessTokenCreated = "Access token is succesfully created";

        public static string AuthorizationDenied = "You are not authorized";
        public static string ProductNameIsAlreadyExists = "Product name is already exists";
        public static string InternalServerError = "Internal Server Error";
    }
}
