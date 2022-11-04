using UnityEngine;

namespace RPGCore
{
    public abstract class LivingEntity : Entity
    {
        [Header("LivingEntity fields")]
        [SerializeField] private uint _baseMaxHealth;
        [SerializeField] private uint _healthOnStart;
        [Tooltip("True: The current health of the entity is set to max.\nFalse: The current health stays as is it in the inspector.")]
        [SerializeField] private bool _healthMaxOnStart = true;

        [Space(10)]
        [SerializeField] private uint _maxHealthIncreasePerLevel;

        private uint _currentHealth;

        public uint BaseMaxHealth => _baseMaxHealth;

        public uint CurrentHealth => _currentHealth;

        public virtual uint MaxHealth => _baseMaxHealth;

        public abstract void DecreaseCurrentHealth(uint amount);

        public abstract void IncreaseCurrentHealth(uint amount);

        protected override void Awake()
        {
            base.Awake();

            if(_healthOnStart > MaxHealth || _healthMaxOnStart) _healthOnStart = MaxHealth;
            _currentHealth = _healthOnStart;
        }
    }
}
