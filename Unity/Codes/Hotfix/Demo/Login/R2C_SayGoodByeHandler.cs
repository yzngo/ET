﻿namespace ET
{
    [MessageHandler]
    public class R2C_SayGoodByeHandler : AMHandler<R2C_SayGoodBye>
    {
        protected override async void Run(Session session, R2C_SayGoodBye message)
        {
            Log.Debug(message.GoodBye);
            await ETTask.CompletedTask;
        }
    }
}