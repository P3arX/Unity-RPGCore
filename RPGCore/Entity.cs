using UnityEngine;

namespace RPGCore
{
    public abstract class Entity : MonoBehaviour
    {
        [Header("Entity fields")]
        [SerializeField] private uint _level;

        [SerializeField] private string _name;

        public uint Level => _level;

        public string Name => _name;

        public delegate void LevelChangeDelegate(uint newLevel);
        public event LevelChangeDelegate OnLevelChange;

        protected virtual void Awake()
        {
            
        }

        /// <summary>
        /// Sets the entity's name. Logs a warning if the name is null or white space.
        /// </summary>
        /// <param name="name">The new name of the entity.</param>
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) Debug.LogWarning($"Null or whitespace name was given to {gameObject.name}");

            _name = name;
        }

        /// <summary>
        /// Sets the entity's level. Logs a warning if the level is 0.
        /// </summary>
        /// <param name="level">The level to set the entity to.</param>
        public void SetLevel(uint level)
        {
            if (level == 0) Debug.LogWarning($"Level of {gameObject.name} was set to 0.");

            _level = level;

            if (OnLevelChange != null) OnLevelChange.Invoke(_level);
        }

        /// <summary>
        /// Increases the entity's level by 1.
        /// </summary>
        public void LevelUp()
        {
            SetLevel(_level + 1);
        }
    }
}
