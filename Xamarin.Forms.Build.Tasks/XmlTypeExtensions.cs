using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Build.Tasks
{
	static class XmlTypeExtensions
	{
		static Dictionary<ModuleDefinition, IList<XmlnsDefinitionAttribute>> s_xmlnsDefinitions = 
			new Dictionary<ModuleDefinition, IList<XmlnsDefinitionAttribute>>();
		static object _nsLock = new object();

		static IList<XmlnsDefinitionAttribute> GatherXmlnsDefinitionAttributes(ModuleDefinition module)
		{
<<<<<<< HEAD
			var xmlnsDefinitions = new List<XmlnsDefinitionAttribute>();

			if (module.AssemblyReferences?.Count > 0) {
				// Search for the attribute in the assemblies being
				// referenced.
				foreach (var asmRef in module.AssemblyReferences) {
					var asmDef = module.AssemblyResolver.Resolve(asmRef);
					foreach (var ca in asmDef.CustomAttributes) {
						if (ca.AttributeType.FullName == typeof(XmlnsDefinitionAttribute).FullName) {
							var attr = GetXmlnsDefinition(ca, asmDef);
							xmlnsDefinitions.Add(attr);
						}
					}
=======
			//this could be extended to look for [XmlnsDefinition] in all assemblies
			var assemblies = new [] {
				typeof(XamlLoader).Assembly,
				typeof(View).Assembly,
			};

			s_xmlnsDefinitions = new List<XmlnsDefinitionAttribute>();

			foreach (var assembly in assemblies)
				foreach (XmlnsDefinitionAttribute attribute in assembly.GetCustomAttributes(typeof(XmlnsDefinitionAttribute), false)) {
					s_xmlnsDefinitions.Add(attribute);
					attribute.AssemblyName = attribute.AssemblyName ?? assembly.FullName;
>>>>>>> Update from origin (#11)
				}
			} else {
				// Use standard XF assemblies
				// (Should only happen in unit tests)
				var requiredAssemblies = new[] {
					typeof(XamlLoader).Assembly,
					typeof(View).Assembly,
				};
				foreach (var assembly in requiredAssemblies)
					foreach (XmlnsDefinitionAttribute attribute in assembly.GetCustomAttributes(typeof(XmlnsDefinitionAttribute), false)) {
						attribute.AssemblyName = attribute.AssemblyName ?? assembly.FullName;
						xmlnsDefinitions.Add(attribute);
					}
			}

			s_xmlnsDefinitions[module] = xmlnsDefinitions;
			return xmlnsDefinitions;
		}

		public static TypeReference GetTypeReference(string xmlType, ModuleDefinition module, BaseNode node)
		{
			var split = xmlType.Split(':');
			if (split.Length > 2)
				throw new XamlParseException($"Type \"{xmlType}\" is invalid", node as IXmlLineInfo);

			string prefix, name;
			if (split.Length == 2) {
				prefix = split[0];
				name = split[1];
			} else {
				prefix = "";
				name = split[0];
			}
			var namespaceuri = node.NamespaceResolver.LookupNamespace(prefix) ?? "";
			return GetTypeReference(new XmlType(namespaceuri, name, null), module, node as IXmlLineInfo);
		}

		public static TypeReference GetTypeReference(string namespaceURI, string typename, ModuleDefinition module, IXmlLineInfo xmlInfo)
		{
			return new XmlType(namespaceURI, typename, null).GetTypeReference(module, xmlInfo);
		}
	
		public static TypeReference GetTypeReference(this XmlType xmlType, ModuleDefinition module, IXmlLineInfo xmlInfo)
		{
			IList<XmlnsDefinitionAttribute> xmlnsDefinitions = null;
			lock (_nsLock) {
				if (!s_xmlnsDefinitions.TryGetValue(module, out xmlnsDefinitions))
					xmlnsDefinitions = GatherXmlnsDefinitionAttributes(module);
			}

<<<<<<< HEAD
			var typeArguments = xmlType.TypeArguments;
=======
			if (lookupAssemblies.Count == 0) {
				string ns;
				string typename;
				string asmstring;
				string targetPlatform;

				XmlnsHelper.ParseXmlns(namespaceURI, out typename, out ns, out asmstring, out targetPlatform);
				asmstring = asmstring ?? module.Assembly.Name.Name;
				if (ns != null)
					lookupAssemblies.Add(new XmlnsDefinitionAttribute(namespaceURI, ns) {
						AssemblyName = asmstring
					});
			}

			lookupNames.Add(elementName + "Extension");
			lookupNames.Add(elementName);

			for (var i = 0; i < lookupNames.Count; i++)
			{
				var name = lookupNames[i];
				if (name.Contains(":"))
					name = name.Substring(name.LastIndexOf(':') + 1);
				if (typeArguments != null)
					name += "`" + typeArguments.Count; //this will return an open generic Type
				lookupNames[i] = name;
			}
>>>>>>> Update from origin (#11)

			IList<XamlLoader.FallbackTypeInfo> potentialTypes;
			TypeReference type = xmlType.GetTypeReference(
				xmlnsDefinitions,
				module.Assembly.Name.Name,
				(typeInfo) =>
				{
					string typeName = typeInfo.TypeName.Replace('+', '/'); //Nested types
					return module.GetTypeDefinition((typeInfo.AssemblyName, typeInfo.ClrNamespace, typeName));
				},
				out potentialTypes);

			if (type != null && typeArguments != null && type.HasGenericParameters)
			{
				type =
					module.ImportReference(type)
						.MakeGenericInstanceType(typeArguments.Select(x => GetTypeReference(x, module, xmlInfo)).ToArray());
			}

			if (type == null)
				throw new XamlParseException($"Type {xmlType.Name} not found in xmlns {xmlType.NamespaceUri}", xmlInfo);

			return module.ImportReference(type);
		}

		public static XmlnsDefinitionAttribute GetXmlnsDefinition(this CustomAttribute ca, AssemblyDefinition asmDef)
		{
			var attr = new XmlnsDefinitionAttribute(
							ca.ConstructorArguments[0].Value as string,
							ca.ConstructorArguments[1].Value as string);

			string assemblyName = null;
			if (ca.Properties.Count > 0)
				assemblyName = ca.Properties[0].Argument.Value as string;
			attr.AssemblyName = assemblyName ?? asmDef.Name.FullName;
			return attr;
		}
	}
}
