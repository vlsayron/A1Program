using System.Configuration;
namespace ConsoleBcl.Models.Configuration.ForTest2
{
    public class RuleElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RuleElement)element).Folder;
        }
       
        public RuleElement GetRuleElement(string id)
        {
            return (RuleElement)this.BaseGet((object)id);
        }
    }
}
