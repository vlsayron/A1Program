using System;

namespace CustomContainer.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute : Attribute
    {
        public Type AbstractType { get; set; }

        public ExportAttribute(Type type)
        {
            AbstractType = type;
        }
    }
}