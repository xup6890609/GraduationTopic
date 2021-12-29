
public class HealthSystem
{
    public int health;
    public int healthMax;
    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    //讀取血量資料
    public int GetHealth()
    {
        return health;
    }

    //減血
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
            health = 0;
    }

    //增血
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax)
            health = healthMax;
    }
}

