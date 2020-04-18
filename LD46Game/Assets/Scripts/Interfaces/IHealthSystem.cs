namespace Assets.Scripts.Interfaces {
    public interface IHealthSystem {
        float GetHealth();
        void SetHealth(float value);
        void Damage(float amount);
        void Heal(float amount);
    }
}
