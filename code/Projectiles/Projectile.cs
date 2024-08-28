using Sandbox;

public sealed class Projectile : Component
{
	[Property, Range( 0.0f, 20.0f, clamped: false )] float Speed { get; set; } = 5.0f;


	[Property] public TagSet IgnoreTags { get; set; }
	protected override void OnFixedUpdate()
	{
		Transform.Position += Transform.Rotation.Forward * Speed;
		var startPos = Transform.Position;
		var endPos = startPos + Transform.Rotation.Forward * Speed;

		var tr = Scene.Trace.Ray(startPos,endPos).Radius(5.0f).WithoutTags(IgnoreTags).Run();

		if (tr.Hit && !tr.GameObject.Components.TryGet<MeshComponent>( out var mesh ) )
		{
			if ( tr.GameObject.Components.TryGet<Health>( out var health ) )
				health.Hurt( new( 1, GameObject, GameObject ) );
			GameObject.Destroy();
		}
		else
		{
			Transform.Position = endPos;
		}
	}
}
