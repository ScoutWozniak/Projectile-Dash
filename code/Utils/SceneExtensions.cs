using Sandbox.Diagnostics;
using Scene = Sandbox.Scene;


public static partial class SceneExtensions
{
	public static GameObject GetLocalPlayer( this GameObject go )
	{
		return go.Scene.Components.Get<PlayerShooter>( FindMode.InDescendants ).GameObject;
	}
}
