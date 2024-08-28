using Sandbox;
using System;

public sealed class PlayerShooter : Component
{
	[Property] GameObject Projectile { get; set; }
	[Property] GameObject Body { get; set; }

	[Property, Range( 0.0f, 5.0f )] float CoolDown { get; set; } = 1.0f;

	[Property] float MaxBloomAng { get; set; } = 2.0f;

	float CurrentBloom { get; set; } = 0.0f;

	TimeSince LastFire { get; set; }

	protected override void OnFixedUpdate()
	{
		if ( Input.Down( "attack1" ) && LastFire > CoolDown )
		{
			Fire();
		}

		CurrentBloom -= 0.01f;
		CurrentBloom = CurrentBloom.Clamp( 0.0f, 5.0f );
	}

/*	protected override void OnUpdate()
	{
		base.OnUpdate();
		Gizmo.Draw.ScreenText( CurrentBloom.ToString(), Screen.Size / 2 , flags:TextFlag.Center);
	}*/

	void AddBloom()
	{
		CurrentBloom += 0.4f;
		CurrentBloom = CurrentBloom.Clamp( 0.0f, 5.0f );
	}

	void Fire()
	{
		var go = Projectile.Clone();
		go.Transform.Position = Transform.Position;
		var devianceAng = new Angles();
		devianceAng.yaw = Game.Random.Float( -MaxBloomAng, MaxBloomAng ) * CurrentBloom;
		go.Transform.Rotation = Body.Transform.Rotation * devianceAng;
		LastFire = 0;
		AddBloom();
		Sound.Play( "ship.fire", Transform.Position );
	}
}
