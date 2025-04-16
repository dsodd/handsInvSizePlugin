using Rocket.API;

namespace handsInventorySize
{
    public class Configuration : IRocketPluginConfiguration
    {
        public byte Width;
        public byte Height;


        public void LoadDefaults()
        {
            Width = 8;
            Height = 4;
        }
    }
}