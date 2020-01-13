namespace DomainModel
{
    public class Prediction
    {
        public string Name { get; }
        public double Value { get; }

        public Prediction(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}