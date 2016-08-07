using Ninject.Modules;
using NodesUtility.Business;
using NodesUtility.Interfaces;

namespace NodesUtility.Infrastructure
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            string indentation = "    ";
            Bind<INodeDescriber>().To<NodeDescriber>()
                .WithConstructorArgument("indentation", indentation);
            Bind<INodeWriter>().To<NodeWriter>();
        }
    }
}
