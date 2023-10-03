namespace ET
{
    public static class ComputerSystem 
    {
        public static void Start(this Computer self)
        {
            Log.Debug("Computer Start");
            self.AddComponent<PCCaseComponent>().StartPower();
            self.AddComponent<MouseComponent>().Click();
            self.AddComponent<KeyboardComponent>().Input();
            self.AddComponent<MonitorComponent>().Display();
        }
    }
}