using Sandbox;
using System.Threading.Tasks;

public sealed class DestroyAfter : Component
{
	[Property, Range( 1.0f, 120.0f )] float Length { get; set; } = 1.0f;
	protected override void OnStart()
	{
		_ = DestroyAfterSec();
	}
	async Task DestroyAfterSec()
	{
		await Task.DelaySeconds( Length );
		GameObject.Destroy();
	}
}
