namespace Nancy.Demo.PostSharp
{
    using global::PostSharp.Aspects;
    using System;

    [Serializable]
    public class CacheViewModelAttribute : MethodInterceptionAspect
    {
        /// <summary>
        ///    Cache name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Cache duration (in seconds).
        /// </summary>
        public int Duration { get; set; }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new InvalidOperationException("Name property is null");
            }

            var viewModel = Cache.Get(this.Name);
            if (viewModel == null)
            {
                base.OnInvoke(args);
                Cache.Add(this.Name, args.ReturnValue, this.Duration);
            }
            else
            {
                var convertedVIewModel = (IViewModel)viewModel;
                convertedVIewModel.Cached = true;
                args.ReturnValue = convertedVIewModel;
            }
        }
    }
}