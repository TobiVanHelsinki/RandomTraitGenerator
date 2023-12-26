using System.Collections.Generic;
using System.Linq;
using TLIB;

namespace RandomTraitGenerator
{
    internal class Trait : List<Value>
    {
        internal string Name { get; set; }

        internal Trait(string v)
        {
            Name = v;
        }

        internal IEnumerable<(Trait List, Value T)> RandomTrait()
        {
            var RandMax = this.Sum(x => x.Probability);
            var RandVal = StaticRandom.NextDouble();
            var TrickVal = RandVal * RandMax;
            var (Sum, t) = this.Aggregate<Value, (double Sum, Value t)>((0, null), (a, c) => a = a.Sum < TrickVal ? (a.Sum + c.Probability, c) : a);
            if (Sum < TrickVal || Sum > TrickVal + 1)
            {
                if (System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Break();
            }
            var RetList = new List<(Trait List, Value T)>() { (this,t) };
            if (t.HasSubvariants)
            {
                return RetList.Concat(t.Subvariants.RandomTrait());
            }
            return RetList;
        }
    }
}