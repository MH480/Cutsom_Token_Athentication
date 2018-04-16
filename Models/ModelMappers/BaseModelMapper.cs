using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Models.ModelMappers
{
    public static class BaseModelMapper
    {
        public static TOutModel MapProp<TInModel,TOutModel>(this TInModel sourceObj,TOutModel targetObj ) 
        where TInModel : class
        where TOutModel : class 
        {
            Type T1 = sourceObj.GetType();
            Type T2 = targetObj.GetType();
            
            PropertyInfo[] sourceProprties = T1.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] targetProprties = T2.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            List<string> names = targetProprties.Select(p => p.Name ).ToList();
            foreach (var sourceProp in sourceProprties)
            {
                object osourceVal = sourceProp.GetValue(sourceObj, null);

                int entIndex = Array.IndexOf(names.ToArray(), sourceProp.Name);
                if (entIndex >= 0)
                {
                    var targetProp = targetProprties[entIndex];
                    targetProp.SetValue(targetObj, osourceVal);
                }
            }

            return targetObj;
        }
    }
}