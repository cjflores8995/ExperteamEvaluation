using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Helpers
{
    public static class Mapping<T>
    {
        public static List<string> FieldProperty = new List<string> {
            "System.Boolean",
            "System.String",
            "System.Int16",
            "System.Int32",
            "System.Int64",
            "System.int",
            "System.Double",
            "System.Decimal",
            "System.Char",
            "System.DateTime",
            "System.DateTimeOffset"
            
        };

        public static bool ValidateTypeProperty(string property)
        {
            bool Valid = false;

            try
            {
                foreach (string p in FieldProperty)
                {
                    if (p.Equals(property))
                    {
                        Valid = true;
                        break;
                    }
                }
            }
            catch
            {
                Valid = false;
            }
            return Valid;
        }

        public static T MapOut(T original, T update)
        {

            try
            {

                if (original == null)
                {
                    throw new NullReferenceException(Mensajes.NULL_OBJECT);
                }
                else
                {
                    int i = 0;

                    foreach (PropertyInfo pi in original.GetType().GetProperties().Where(p => !p.GetGetMethod().GetParameters().Any()))
                    {
                        try
                        {
                            if (i != 0)
                            {
                                if (ValidateTypeProperty(pi.PropertyType.FullName.ToString()))
                                {
                                    original.GetType().GetProperty(pi.Name).SetValue(original, pi.GetValue(update, null), null);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                            //logger.Error(ex.Message);
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return original;
                
            }

            return original;
        }
    }
}
