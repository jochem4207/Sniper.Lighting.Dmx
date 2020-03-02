namespace Sniper.Lighting.DMX.DemoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
            demo.ConnectToController();
            demo.TurnLightsOn();
            demo.Disconnect();
        }
    }
}
