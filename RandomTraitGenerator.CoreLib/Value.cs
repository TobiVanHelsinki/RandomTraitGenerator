namespace RandomTraitGenerator
{
    class Value
    {
        public Value(double probability, string name)
        {
            Probability = probability > 1 ? 1 : probability;
            Name = name;
        }

        public Value(double probability, string name, Trait traitList) : this(probability, name)
        {
            Subvariants = traitList;
        }

        public double Probability { get; set; }
        public string Name { get; set; }

        public Trait Subvariants { get; set; }
        public bool HasSubvariants => Subvariants != null;

        public override string ToString()
        {
            return Name; 
        }
        
    }
}
