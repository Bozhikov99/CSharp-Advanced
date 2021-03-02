using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        public Dough(string flour, string technique, int weight)
        {
            Flour = flour;
            BakingTechnique = technique;
            Grams = weight;
        }

        private const int defaultCaloriesPerGram = 2;
        private const int minWeight = 1;
        private const int maxWeight = 200;

        private int grams;
        private string flour;
        private string bakingTechnique;

        public int Grams
        {
            get => grams;
            private set
            {
                Validator.ThrowInvalidWeight(value, minWeight, maxWeight, "Dough weight should be in the range [1..200].");
                grams = value;
            }
        }

        public string Flour
        {
            get => flour;
            private set
            {
                string valueAsLower = value.ToLower();
                Validator.ThrowInvalidValue(valueAsLower, new HashSet<string> { "white", "wholegrain" }, "Invalid type of dough.");
                flour = valueAsLower;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                string valueAsLower = value.ToLower();
                Validator.ThrowInvalidValue(valueAsLower, new HashSet<string> { "crispy", "chewy", "homemade" }, "Invalid type of dough.");
                bakingTechnique = valueAsLower;
            }
        }
        public double TotalCalories()
        {
            double flourModifier = Flour == "white" ? 1.5 : 1.0;
            double techniqueModifier = 0;
            if (BakingTechnique == "crispy")
            {
                techniqueModifier = 0.9;
            }
            else if (bakingTechnique == "chewy")
            {
                techniqueModifier = 1.1;
            }
            else if (bakingTechnique == "homemade")
            {
                techniqueModifier = 1.0;
            }
            return grams * defaultCaloriesPerGram * techniqueModifier * flourModifier;
        }
    }
}