namespace Game.UI
{
    public sealed class HealthEffectHandler
    {
        private readonly HealthScreen _screen;
        private readonly int _maxHealth;
        private int _previousHealth;

        public HealthEffectHandler(HealthScreen screen, int maxHealth, int initialHealth)
        {
            _screen = screen;
            _maxHealth = maxHealth;
            _previousHealth = initialHealth;
        }

        public void UpdateHealth(int newHealth)
        {
            var percent = newHealth / (float)_maxHealth;
            _screen.ChangePercent(percent);

            if (newHealth < _previousHealth)
            {
                var damage = _previousHealth - newHealth;
                _screen.TakeDamage(damage);
            }

            _previousHealth = newHealth;
        }
    }
}