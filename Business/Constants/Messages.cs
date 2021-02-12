using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages<T> where T: class, IEntity, new()
    {

        public static string Added = new T().GetType().Name + " Added";
        public static string Deleted = new T().GetType().Name + " Deleted";
        public static string Updated = new T().GetType().Name + " Updated";
        public static string GotAll = "Got All " + new T().GetType().Name;
        public static string Unsuccessfull = new T().GetType().Name + " Unsuccessfull";
        public static string NotAvaible = new T().GetType().Name + " Not Avaible";
    }
}
