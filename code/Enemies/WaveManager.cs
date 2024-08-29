using Sandbox;

public sealed class WaveManager : Component
{
	[Property] GameObject EnemySpawn { get; set; }

	protected override void OnStart()
	{
		base.OnStart();
		SpawnWave();
	}

	void SpawnWave()
	{
		for (int i = 0; i < 10; i++)
		{
			var spawnAng = Game.Random.Float( 360 );
			var newAngs = new Angles( 0, spawnAng, 0 );
			var spawnPos = newAngs.Forward * 1000.0f;
			SpawnEnemy( spawnPos );
		}
	}

	void SpawnEnemy(Vector3 pos)
	{
		var go = EnemySpawn.Clone(pos);
	}
}
