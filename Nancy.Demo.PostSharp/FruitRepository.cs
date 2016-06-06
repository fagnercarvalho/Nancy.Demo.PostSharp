namespace Nancy.Demo.PostSharp
{
    using System.Collections.Generic;
    using System.Linq;

    public class FruitRepository : IRepository<Fruit>
    {
        public List<Fruit> Get()
        {
            return
                new[]
                {
                    new Fruit { Id = 1, Name = "Pineapple" },
                    new Fruit { Id = 2, Name = "Apple" },
                    new Fruit { Id = 3, Name = "Grape" },
                    new Fruit { Id = 4, Name = "Strawberry" },
                    new Fruit { Id = 5, Name = "Watermelon" }
                }.ToList();
        }
    }

    public interface IRepository<T> where T : class
    {
        List<T> Get();
    }
}