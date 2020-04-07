using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CustomContainer.Attributes;

namespace CustomContainer
{
    public class IoCContainer
    {
        readonly Dictionary<Type, Type> _registeredDependencies = new Dictionary<Type, Type>();

        
        public void AddType<T1>()
        {
            _registeredDependencies.Add(typeof(T1), typeof(T1));
        }
        
        public void AddType<T1, T2>()
        {
            _registeredDependencies.Add(typeof(T1), typeof(T2));
        }


        public void AddType(Type type)
        {
            _registeredDependencies.Add(type, type);
        }
        
        public void AddType(Type instanceType, Type implementationType)
        {
            _registeredDependencies.Add(instanceType, implementationType);
        }


        public void AddAssembly(Assembly assembly)
        {
            var typeCollection = assembly.GetTypes();

            foreach (var type in typeCollection)
            {
                if (type.GetCustomAttribute<ImportConstructorAttribute>() != null ||
                    type.GetProperties().Any(prop => prop.GetCustomAttribute<ImportAttribute>() != null))
                {
                    _registeredDependencies.Add(type, type);
                }

                if (type.GetCustomAttribute<ExportAttribute>() != null)
                {
                    var instanceType = type.GetCustomAttribute<ExportAttribute>()?.AbstractType;

                    _registeredDependencies.Add(instanceType ?? type, type);

                }
            }
        }

        public T CreateInstance<T>()
        {
            return (T)CreateInstance(typeof(T));
        }

        public object CreateInstance(Type type)
        {
            if (!_registeredDependencies.TryGetValue(type, out var implementationType))
            {
                return null;
            }

            object[] constructorParams = null;

            var parameters = implementationType.GetConstructors().FirstOrDefault()?.GetParameters();

            if (parameters != null)
            {
                var count = parameters.Length;

                var initObjects = new object[count];

                for (var i = 0; i < count; i++)
                {
                    initObjects[i] = CreateInstance(parameters[i].ParameterType);
                }

                constructorParams = initObjects;
            }

            return Activator.CreateInstance(implementationType, constructorParams);
        }
        
    }
}