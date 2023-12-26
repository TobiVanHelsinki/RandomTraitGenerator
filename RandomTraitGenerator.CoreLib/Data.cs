using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RandomTraitGenerator
{
    internal class Data
    {
        internal static IEnumerable<Trait> String2Data(string v)
        {
            var Ret = new List<Trait>();
            var xml = XDocument.Parse(v);
            foreach (var item in xml.Elements("TraitList"))
            {
                foreach (var XML_trait in item.Elements("Trait"))
                {
                    try
                    {
                        Ret.Add(ExtractTrait(XML_trait));
                    }
                    catch (Exception)
                    {
                        if (System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Break();
                    }
                }
            }
            return Ret;
        }

        private static Trait ExtractTrait(XElement XML_trait)
        {
            var trait = new Trait(XML_trait.Attribute("Name").Value);
            foreach (var XML_value in XML_trait.Elements("Value"))
            {
                try
                {
                    var XML_P = XML_value.Attribute("P");
                    var XML_Name = XML_value.Attribute("Name");
                    double.TryParse(XML_P?.Value?.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var d);
                    var value = new Value(d, XML_Name.Value);
                    var XML_SubItems = XML_value.Elements("Trait");
                    if (XML_SubItems.Count() > 0)
                    {
                        value.Subvariants = ExtractTrait(XML_SubItems.First());
                    }
                    trait.Add(value);
                }
                catch (Exception)
                {
                    if (System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Break();
                }
            }
            return trait;
        }
    }
}
