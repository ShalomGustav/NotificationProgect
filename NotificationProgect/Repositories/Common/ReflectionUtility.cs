using System.Linq.Expressions;
using System.Reflection;

namespace NotificationProgect.Repositories.Common
{
    public static class ReflectionUtility
    {

        public static Type[] GetTypeInheritanceChainTo(this Type type, Type toBaseType)
        {
            var retVal = new List<Type>();

            retVal.Add(type);
            var baseType = type.BaseType;
            while (baseType != toBaseType && baseType != typeof(object))
            {
                retVal.Add(baseType);
                baseType = baseType.BaseType;
            }
            return retVal.ToArray();
        }

        public static bool IsDerivativeOf(this Type type, Type typeToCompare)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var retVal = type.BaseType != null;
            if (retVal)
            {
                retVal = type.BaseType == typeToCompare;
            }
            if (!retVal && type.BaseType != null)
            {
                retVal = type.BaseType.IsDerivativeOf(typeToCompare);
            }
            return retVal;
        }
    }
}
