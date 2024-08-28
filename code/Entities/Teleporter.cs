using Sandbox;

public sealed class Teleporter : Component, IDeathListener
{
	[Property] SphereCollider Collider { get; set; }
	GameObject Player { get; set; }

	static TimeSince CoolDown { get; set; }
	protected override void OnStart()
	{
		base.OnStart();
		Player = Scene.GetLocalPlayer();
		CoolDown = 1.0f;
	}

	protected override void OnFixedUpdate()
	{ 
		// HACK
		Collider.Enabled = Transform.Position.Distance( Player.Transform.Position ) > 0.1f;
	}

	void IDeathListener.OnDeath()
	{
		if ( CoolDown < 0.5f )
			return;
		Player.Transform.Position = Transform.Position;
		Sound.Play( "tele.use", Transform.Position );
		CoolDown = 0;
	}
}
