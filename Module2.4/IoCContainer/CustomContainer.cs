//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Threading;
//using IoCContainer.Attributes;
//using System.Reflection.Emit;


//namespace IoCContainer
//{

//    public class CustomContainer
//    {
//        readonly Dictionary<Type, Type> _registeredDependencies = new Dictionary<Type, Type>();

//        public void AddType<T1, T2>()
//        {
//            _registeredDependencies.Add(typeof(T1), typeof(T2));
//        }

//        public void AddType(Type contract, Type implementation)
//        {
//            _registeredDependencies.Add(contract, implementation);
//        }
//        public void AddType(Type contract)
//        {
//            _registeredDependencies.Add(contract, contract);
//        }


//        public T CreateInstance<T>()
//        {
//            return (T)CreateInstance(typeof(T));
//        }

//        public object CreateInstance(Type instanceType)
//        {
//            var implementation = instanceType;
//            if (_registeredDependencies.ContainsKey(instanceType))
//            {
//                implementation = _registeredDependencies[instanceType];
//            }

//            var constructors = implementation.GetConstructors();

//            if (constructors.Length == 0)
//            {
//                return null;
//            }

//            var constructor = constructors[0];
//            var constructorParameters = constructor.GetParameters();

//            if (constructorParameters.Length == 0)
//            {
//                var properties = implementation.GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(ImportAttribute)));
//                var dependencies = properties.Select(x => new KeyValuePair<string, object>(x.Name, CreateInstance(x.PropertyType))).ToArray();
//                var instance = Activator.CreateInstance(implementation);
//                return instance;
//            }

          

//            return Activator.CreateInstance(implementation, constructorParameters.Select(x => CreateInstance(x.ParameterType)).ToArray());
//        }


//    }


//}
