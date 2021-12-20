﻿using System;
using System.Reflection;

namespace Utils
{
    public static class AssetsInjector
    {
        private static readonly Type _injectAssetAttributeType = typeof(InjectAssetAttribute);
        
        public static T Inject<T>(this AssetsContext context, T target)
        {
            var targetType = target.GetType();
            var allFields = GetFields(targetType);

            if (allFields.Length == 0)
            {
                targetType = target.GetType().BaseType;
                if(targetType != null)
                    allFields = GetFields(targetType);
            }

            for (int i = 0; i < allFields.Length; i++)
            {
                var fieldInfo = allFields[i];
                var injectAssetAttribute = fieldInfo.GetCustomAttribute(_injectAssetAttributeType) as InjectAssetAttribute;
                if (injectAssetAttribute == null)
                {
                    continue;
                }
                var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                fieldInfo.SetValue(target, objectToInject);
            }	

            return target;
        }

        private static FieldInfo[] GetFields(IReflect targetType)
        {
           return targetType.GetFields(BindingFlags.NonPublic 
                                 | BindingFlags.Public 
                                 | BindingFlags.Instance);
        }
    }
}