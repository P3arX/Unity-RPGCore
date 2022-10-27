using UnityEngine;

namespace RPGCore
{
    public abstract class LivingEntity : Entity
    {
        [Header("LivingEntity fields")]
        [SerializeField] private uint _baseMaxHealth;

        [Space(10)]
        [SerializeField] private uint _maxHealthIncreasePerLevel;

        private uint _currentHealth;

        public uint BaseMaxHealth => _baseMaxHealth;

        public uint CurrentHealth => _currentHealth;

        public abstract void DecreaseCurrentHealth(uint amount);

        public abstract void IncreaseCurrentHealth(uint amount);

        protected override void Awake()
        {
            base.Awake();


        }
    }
}
