namespace Nancy.Demo.PostSharp
{
    using Nancy;
    using Nancy.TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IRepository<Fruit>>(new FruitRepository());
        }
    }
}