using Sandbox;

public sealed class PlayerShooter : Component
{
	[Property] GameObject Projectile { get; set; }
	[Property] GameObject Body { get; set; }

	[Property, Range( 0.0f, 5.0f )] float CoolDown { get; set; } = 1.0f;

	TimeSince LastFire { get; set; }

	protected override void OnFixedUpdate()
	{
		if ( Input.Down( "attack1" ) && LastFire > CoolDown )
		{
			Fire();
		}

	}

	void Fire()
	{
		var go = Projectile.Clone();
		go.Transform.Position = Transform.Position;
		go.Transform.Rotation = Body.Transform.Rotation;
		LastFire = 0;

		Sound.Play( "ship.fire", Transform.Position );
	}
}
