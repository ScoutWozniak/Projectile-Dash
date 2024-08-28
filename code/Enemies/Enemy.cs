using Sandbox;

public sealed class Enemy : Component, IDeathListener
{
	[Property] GameObject DeathSpawn { get; set; }
	[Property] float Speed { get; set; } = 2.0f;

	GameObject Player { get; set; }
	protected override void OnStart()
	{
		Player = Scene.GetLocalPlayer();
	}

	protected override void OnFixedUpdate()
	{
		Transform.Rotation = Rotation.LookAt( Player.Transform.Position - Transform.Position );

		var moveDir = Transform.Rotation.Forward * Speed;
		Transform.Position += moveDir;
	}

	void IDeathListener.OnDeath() {
		//var go = DeathSpawn.Clone( Transform.Position );
	}
}
