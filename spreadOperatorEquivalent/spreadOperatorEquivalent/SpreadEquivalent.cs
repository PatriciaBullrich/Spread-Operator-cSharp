using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace spreadOperatorEquivalent
{
    public static class SpreadEquivalent {
        /// <summary>
        /// This class intends to be an equivalent of the js spread operator like {...object1, ...object2}
        /// this class uses reflecion to get the properties and change the values depending if the second object has values
        /// IMPORTANT this will only work properly with nullable attributes or object/string
        /// in c# primitives like int, char, bool have a defualt value and this class will overwrite your first object with them
        /// make sure to use pirmitives with the ? at the end like int?, double?
        /// This class should work great to work with json and Apis especially when updating to a Database
        /// </summary>
        /// <param name="completeInstance"> the first object which has all the data</param>
        /// <param name="newValues"> the second object only filled with what you want to change from the first one</param>
        /// <returns> The same type of class passed to the generic type</returns

        public static bool isFalsy(int? value)
        {
            //supossing my atributes are nullable
            try
            {
                return !value.HasValue;
            }
            catch
            {
                Console.WriteLine("error");
            }
            return false;
        }


        public static bool isFalsy(char? value)
        {
            //supossing my atributes are nullable
            try
            {
                return !value.HasValue;
            }
            catch
            {
                Console.WriteLine("error");
            }
            return false;
        }


        public static bool isFalsy(bool? value)
        {
            //supossing my atributes are nullable
            try
            {
                return !value.HasValue;
            }
            catch
            {
                Console.WriteLine("error");
            }
            return false;
        }

        public static bool isFalsy(double? value)
        {
            //supossing my atributes are nullable
            try
            {
                return !value.HasValue;
            }
            catch
            {
                Console.WriteLine("error");
            }
            return false;
        }

        public static bool isFalsy(float? value)
        {
            //supossing my atributes are nullable
            try
            {
                return !value.HasValue;
            }
            catch
            {
                Console.WriteLine("error");
            }
            return false;
        }


        public static bool isFalsy(decimal? value)
        {
            //supossing my atributes are nullable
            try
            {
                return !value.HasValue;
            }
            catch
            {
                Console.WriteLine("error");
            }
            return false;
        }

        public static bool isFalsy(short? value)
        {
            //supossing my atributes are nullable
            try
            {
                return !value.HasValue;
            }
            catch
            {
                Console.WriteLine("error");
            }
            return false;
        }
        public static bool isFalsy(byte? value)
        {
            //supossing my atributes are nullable
            try
            {
                return !value.HasValue;
            }
            catch
            {
                Console.WriteLine("error");
            }
            return false;
        }

        public static bool isFalsy(object value)
        {
            return value == null;
        }
        public static T spread<T>(T completeInstace, T newValues)
        {
            Type type = typeof(T);
            T aux = (T)Activator.CreateInstance(type);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            try
            {
                foreach (var f in fields)
                {

                    if (!isFalsy(f.GetValue(newValues)))
                    {
                        f.SetValue(aux, f.GetValue(newValues));
                    }
                    else
                    {
                        f.SetValue(aux, f.GetValue(completeInstace));
                    }
                }
            }
            catch
            {
                throw;
            }
            return aux;
        } 

    }
}
