using System;

namespace DirectLifeChallenge
{
    public class ShoppingItem
    {
        public string Name { get; }
        public decimal Value { get; }

        public ShoppingItem(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
