namespace ET
{
    public static class ComputerSystem 
    {
        public class ComputerAwakeSystem: AwakeSystem<Computer>
        {
            public override void Awake(Computer self)
            {
                Log.Debug("Computer Awake");
            }
        }

        public class ComputerUpdateSystem: UpdateSystem<Computer>
        {
            public override void Update(Computer self)
            {
                // Log.Debug("Computer Update");
            }
        }

        public class ComputerDestorySystem: DestroySystem<Computer>
        {
            public override void Destroy(Computer self)
            {
                Log.Debug("Computer Destroy");
            }
        }
        
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