namespace ET
{
	/// <summary>
	/// UnitComponent 用于管理所有的 Unit
	/// </summary>
	[ComponentOf(typeof(Scene))]
	[ChildType(typeof(Unit))]
	public class UnitComponent: Entity, IAwake, IDestroy
	{
	}
}