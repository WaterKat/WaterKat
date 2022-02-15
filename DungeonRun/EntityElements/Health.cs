namespace WaterKat.DungeonRun.EntityElements
{
    public class Health
    {
        public float currentHealth = 100;
        public float maxHealth = 100;

        public delegate void SimpleHealthDelegate();
        public SimpleHealthDelegate OnDeath;

        public void TakeDamage (float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnDeath?.Invoke();
            }
        }

        public void TakeHeal(float heal)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        public void Kill()
        {
            currentHealth = 0;
            OnDeath?.Invoke();
        }
    }
}