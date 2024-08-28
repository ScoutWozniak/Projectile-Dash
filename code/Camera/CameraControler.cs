using Sandbox;

public sealed class CameraControler : Component
{
	[Property] Vector3 Offset { get; set; } = new( 0, 0, 512 );
	[Property] GameObject Body { get; set; }

	protected override void OnStart()
	{
		base.OnStart();
		Mouse.Visible = true;
	}

	protected override void OnUpdate()
	{
		Scene.Camera.Transform.Position = Transform.Position + Offset;

		var dir = Mouse.Position - Screen.Size / 2;
		dir = -dir.Normal;
		var targetRot = Rotation.LookAt(new Vector3(dir.y,dir.x,0));
		Body.Transform.Rotation = Rotation.Lerp( Body.Transform.Rotation, targetRot, 0.4f );
	}
}
