using Sandbox;

public sealed class Level : Component
{
	[Property] Vector3 Boundary { get; set; }

	protected override void DrawGizmos()
	{
		base.DrawGizmos();
		Gizmo.Draw.LineBBox(BBox.FromPositionAndSize(Vector3.Zero, Boundary));
	}

	public bool InBoundary(Vector3 point)
	{
		return (BBox.FromPositionAndSize( Vector3.Zero, Boundary ).Contains( point ));
	}
}
