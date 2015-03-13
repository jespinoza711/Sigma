using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gnecco.Sigma.Utils
{
    public class BuscadorObjetos
    {
        public static List<T> BuscarTodosLosObjetosDelTipo<T>(object value) where T : class
        {

            HashSet<object> exploredObjects = new HashSet<object>();
            List<T> found = new List<T>();

            BuscarTodosLosObjetosDelTipo(value, exploredObjects, found);

            return found;
        }
        private static void BuscarTodosLosObjetosDelTipo<T>(object value, HashSet<object> exploredObjects, List<T> found) where T : class
        {
            if (value == null)
                return;

            if (exploredObjects.Contains(value))
                return;

            exploredObjects.Add(value);

            IEnumerable enumerable = value as IEnumerable;

            if (enumerable != null)
            {
                foreach (object item in enumerable)
                {
                    BuscarTodosLosObjetosDelTipo<T>(item, exploredObjects, found);
                }
            }
            else
            {
                T possibleMatch = value as T;

                if (possibleMatch != null)
                {
                    found.Add(possibleMatch);
                }

                Type type = value.GetType();

                PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty);

                foreach (PropertyInfo property in properties)
                {
                    object propertyValue = property.GetValue(value, null);

                    BuscarTodosLosObjetosDelTipo<T>(propertyValue, exploredObjects, found);
                }

            }
        }
    }
}
