//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Composition;
//using System.Linq;
//using System.Reflection;

//namespace CustomerDal.MainHost
//{
//    public class Container
//    {
//        readonly Dictionary<Type, Type> _registeredDependencies = new Dictionary<Type, Type>();




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

//            var constructor = implementation.GetConstructors()[0];
//            var constructorParameters = constructor.GetParameters();

//            if (constructorParameters.Length == 0)
//            {
//                var properties = implementation.GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(ImportAttribute)));
//                var dependencies = properties.Select(x => new KeyValuePair<string, object>(x.Name, CreateInstance(x.PropertyType))).ToArray();
//                var instance = Activator.CreateInstance(implementation);
//                foreach (var property in properties)
//                {
//                    property.SetValue(instance, dependencies.FirstOrDefault(x => x.Key == property.Name).Value);
//                }
//                return instance;
//            }
//            return Activator.CreateInstance(implementation, constructorParameters.Select(x => CreateInstance(x.ParameterType)).ToArray());
//        }


//        public void AddAssembly(Assembly assembly)
//        {
//            var types = assembly.GetTypes().Where(x => x.Attributes.GetType().Name == "ICustomerDAL");
//            foreach (var type in types)
//            {
//                CreateInstance(type);
//            }
//        }
//    }
//}
