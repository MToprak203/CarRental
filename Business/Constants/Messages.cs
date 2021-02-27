using Core.Entities;
using Entities.Concrete.Properties;
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

    public static class Messages
    {
        public static string CarIsOccupied = "Car is occupied";
        public static string CarHaveMoreThanFiveImage = "Car can't have more than five car images";
        public static string CarHasNoImage = "Car has no images";
    }
}
