using System;

namespace IoCContainer.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute : Attribute
    {
        public Type AbstrType { get; set; }

        public ExportAttribute()
        {

        }

        public ExportAttribute(Type type)
        {
            AbstrType = type;
        }
    }
}