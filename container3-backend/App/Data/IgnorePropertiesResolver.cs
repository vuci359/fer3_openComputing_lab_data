 //source: https://www.wikicoode.com/dot-net-c/exclude-property-json-during-serialization-newtonsoft

 namespace openComputingLab.Data;

 public class IgnorePropertiesResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        private readonly HashSet<string> ignoreProps;
        public IgnorePropertiesResolver(IEnumerable<string> propNamesToIgnore)
        {
            this.ignoreProps = new HashSet<string>(propNamesToIgnore);
        }
        public IgnorePropertiesResolver()
        {
            this.ignoreProps = new HashSet<string>();
        }
        internal void ignoreProperty(string propName)
        {
            this.ignoreProps.Add(propName);
        }
        internal void ignoreProperties(List<string> ignoredProperties)
        {
            foreach(var prop in ignoredProperties)
            {
                this.ignoreProps.Add(prop);
            }
        }

        protected override Newtonsoft.Json.Serialization.JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            Newtonsoft.Json.Serialization.JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (this.ignoreProps.Contains(property.PropertyName))
            {
                property.ShouldSerialize = _ => false;
            }
            return property;
        }
    }