using Sandbox;

public sealed class Health : Component
{
	[Property] int MaxHealth { get; set; }

	[Property] public int CurHealth { get; set; }

	[Property] bool Invincible = false;

	
	protected override void OnStart()
	{
		base.OnStart();
		CurHealth = MaxHealth;
	}

	public void Hurt(DamageInfo dmg)
	{
		CurHealth -= (int)dmg.Damage;

		if ( CurHealth <= 0 )
			OnDeath();
	}

	void OnDeath()
	{
		foreach(var listen in Components.GetAll<IDeathListener>())
		{
			listen.OnDeath();
		}
		if ( Invincible )
			return;

		GameObject.Destroy();
	}
}
