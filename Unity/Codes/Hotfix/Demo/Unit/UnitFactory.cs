using UnityEngine;

namespace ET
{
	/// <summary>
	/// Unit 工厂辅助类
	/// </summary>
    public static class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        unitComponent.Add(unit);
	        
	        unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);
	        unit.Forward = new Vector3(unitInfo.ForwardX, unitInfo.ForwardY, unitInfo.ForwardZ);
	        
	        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
	        for (int i = 0; i < unitInfo.Ks.Count; ++i)
	        {
		        numericComponent.Set(unitInfo.Ks[i], unitInfo.Vs[i]);
	        }
	        
	        unit.AddComponent<MoveComponent>();
	        if (unitInfo.MoveInfo != null)
	        {
		        if (unitInfo.MoveInfo.X.Count > 0)
		        {
			        using (ListComponent<Vector3> list = ListComponent<Vector3>.Create())
			        {
				        list.Add(unit.Position);
				        for (int i = 0; i < unitInfo.MoveInfo.X.Count; ++i)
				        {
					        list.Add(new Vector3(unitInfo.MoveInfo.X[i], unitInfo.MoveInfo.Y[i], unitInfo.MoveInfo.Z[i]));
				        }

				        unit.MoveToAsync(list).Coroutine();
			        }
		        }
	        }

	        unit.AddComponent<ObjectWait>();

	        unit.AddComponent<XunLuoPathComponent>();
	        
	        Game.EventSystem.Publish(new EventType.AfterUnitCreate() {Unit = unit});
            return unit;
        }
        
        
        /// <summary>
        /// Player 工厂类
        /// </summary>
        /// <param name="currentScene"></param>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        public static Unit CreatePlayer(Scene currentScene, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        unit.UnitType = UnitType.Player;
	        // Player 可以行走，添加 Move 组件
	        unit.AddComponent<MoveComponent>();
	        
	        unitComponent.Add(unit);
	        
	        unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);
	        // 抛出事件，供 View 层使用
	        Game.EventSystem.Publish(new EventType.AfterUnitCreate() {Unit = unit});
            return unit;
        }
        
        /// <summary>
        /// NPC 工厂类
        /// </summary>
        /// <param name="currentScene"></param>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        public static Unit CreateNpc(Scene currentScene, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        unit.UnitType = UnitType.Npc;
	        
	        unitComponent.Add(unit);
	        
	        unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);
	        Game.EventSystem.Publish(new EventType.AfterUnitCreate() {Unit = unit});
            return unit;
        }
        
        /// <summary>
        /// Monster 工厂类
        /// </summary>
        /// <param name="currentScene"></param>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        public static Unit CreateMonster(Scene currentScene, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        unit.UnitType = UnitType.Monster;
			
	        // Monster 可以行走，添加 Move 组件
	        unit.AddComponent<MoveComponent>();
	        // Monster 可以巡逻，添加 XunLuoPathComponent 组件
	        unit.AddComponent<XunLuoPathComponent>();
	        
	        unitComponent.Add(unit);
	        
	        unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);
	        Game.EventSystem.Publish(new EventType.AfterUnitCreate() {Unit = unit});
            return unit;
        }
    }
}
