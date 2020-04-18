namespace Assets.Scripts.Interfaces {
    public interface IHealthSystem {
        float Health { get; set; }
        void Damage(float amount);
        void Heal(float amount);
    }
}
