namespace Nancy.Demo.PostSharp
{
    using System.Collections.Generic;

    public class FruitViewModel : IViewModel
    {
        public FruitViewModel()
        {
            this.Cached = true;
        }

        public List<Fruit> Fruits { get; set; }

        public bool Cached { get; set; }
    }
}