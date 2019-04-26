using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib
{
    public class ObjectFactory
    {
        private static List<ObjectFactoryRegistration> _registrations;

        static ObjectFactory()
        {
            //this creates a variable that is a list of strongly typed objects. See the POCO in ObjectFactory.cs
            _registrations = new List<ObjectFactoryRegistration>();
        }

        public static TInterface Create<TInterface>()
        {
            //this method creates an interface for the object as long as the object is not null. 
            var item = _registrations.FirstOrDefault(x => x.Interface == typeof(TInterface))?.Concrete;
            if (item != null)
                return (TInterface)item;

            return default(TInterface);
        }

        public static TInterface Create<TInterface>(string name)
        {
            //this is method overloading. If the object has a name or not, it will receive an Interface that's in the shape of the concrete version
            //method overloading is when a method has the same name, but can take a different amount of agruments being passed to it.
            var item = _registrations.FirstOrDefault(x =>
                x.Interface == typeof(TInterface)
                && x.Name == name)?.Concrete;
            if (item != null)
                return (TInterface)item;

            return default(TInterface);
        }

        //This method says, ' register this object when the Interface matches the concrete version.
        public static void Register<TInterface, TConcrete>(TConcrete concrete)
            where TConcrete : TInterface
        {
            Register<TInterface, TConcrete>(concrete, null);
        }

        //this method is overloading. This one takes a second parameter/argument. It will accept a named object.
        public static void Register<TInterface, TConcrete>(TConcrete concrete, string name)
            where TConcrete : TInterface
        {
            var registration = new ObjectFactoryRegistration
            {
                Interface = typeof(TInterface),
                Concrete = concrete,
                Name = name
            };

            _registrations.Add(registration);
        }

        public interface IPhoto
        {
            string Type { get; set; }
        }

        internal static object Register<T>(string state)
        {
            throw new NotImplementedException();
        }
    }

    //public interface IMuffin
    //{
    //    string Type { get; set; }
    //}

    //public class Muffin : IMuffin
    //{
    //    public string Type { get; set; }
    //}

    //public class Bakery
    //{
    //    public void StartDay()
    //    {
    //        var blueberry = new Muffin
    //        {
    //            Type = "Blueberry"
    //        };
    //        var choc = new Muffin
    //        {
    //            Type = "Chocolate"
    //        };

    //        ObjectFactory.Register<IMuffin, Muffin>(blueberry, blueberry.Type);
    //        ObjectFactory.Register<IMuffin, Muffin>(choc, choc.Type);
    //        ObjectFactory.Register<IMuffin, Muffin>(blueberry);

    //        var customerMuffin = ObjectFactory.Create<IMuffin>("Blueberry");

    //        var customerMuffin2 = ObjectFactory.Create<IMuffin>("Bran");


    //    }
    }
