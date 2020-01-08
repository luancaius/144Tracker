using System;

namespace WebAPI.Model
{
    public class Prediction
    {
        public string Name { get; set; }
        public DateTime PredictionValue { get; set; }
        public string Distance { get; set; }
        public DateTime DateTime { get; set; }
    }
}