using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DataModul
{

    public static class IENumerableExtensions
    {
        public static IEnumerable<T> FromDataReader<T>(this IEnumerable<T> list, DbDataReader dr)
        {
            Reflection reflec = new Reflection();
            Object instance;
            List<Object> lstObj = new List<Object>();

            while (dr.Read())
            {
                instance = Activator.CreateInstance(list.GetType().GetGenericArguments()[0]);

                foreach (DataRow drow in dr.GetSchemaTable().Rows)
                {
                    reflec.FillObjectWithProperty(
                        ref instance,
                        drow.ItemArray[0].ToString(),
                        dr[drow.ItemArray[0].ToString()]);
                }

                lstObj.Add(instance);
            }

            List<T> lstResult = new List<T>();
            foreach (Object item in lstObj)
            {
                lstResult.Add((T)Convert.ChangeType(item, typeof(T)));
            }

            return lstResult;
        }
    }
    public class Reflection
    {
        public void FillObjectWithProperty(ref object objectTo, string propertyName, object propertyValue)
        {
            try
            {
                Type tOb2 = objectTo.GetType();
                tOb2.GetProperty(propertyName).SetValue(objectTo, propertyValue);
            }catch{}
        }
    }
}