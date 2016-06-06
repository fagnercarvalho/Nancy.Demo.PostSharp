namespace Nancy.Demo.PostSharp
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        private readonly IRepository<Fruit> fruitRepository;

        public IndexModule(IRepository<Fruit> fruitRepository)
        {
            this.fruitRepository = fruitRepository;

            this.Get["/"] = parameters => this.View["index", this.GetFruits()];
        }

        [CacheViewModel(Name = "Fruits", Duration = 10)]
        public FruitViewModel GetFruits()
        {
            return new FruitViewModel { Fruits = this.fruitRepository.Get(), Cached = false };
        }
    }
}