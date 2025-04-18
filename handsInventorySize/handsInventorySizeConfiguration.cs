using Rocket.API;

namespace handsInventorySize
{
    public class HandsInventorySizeConfiguration : IRocketPluginConfiguration
    {
        public ContainerSize Beta { get; set; }
        public ContainerSize Kappa { get; set; }
        public ContainerSize Sigma { get; set; }

        public void LoadDefaults()
        {
            Beta = new ContainerSize { Width = 8, Height = 4 };
            Kappa = new ContainerSize { Width = 8, Height = 4 };
            Sigma = new ContainerSize { Width = 8, Height = 4 };
        }
    }

    public class ContainerSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
