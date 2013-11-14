using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartR.Lib.Messaging
{
    public static class TypeExtensions
    {
        public static bool IsGenericTypeOf(this Type t, Type genericDefinition)
        {
            return t.IsGenericType && genericDefinition.IsGenericType && t.GetGenericTypeDefinition() == genericDefinition.GetGenericTypeDefinition();
        }
    }
}
