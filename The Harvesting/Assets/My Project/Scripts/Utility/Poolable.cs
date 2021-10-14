using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Base class for objects to be used in a GameObjectPool.
    /// </summary>
    public abstract class Poolable : MonoBehaviour
    {
        /// <summary>
        /// A reference to the pool.
        /// </summary>
        protected GameObjectPool pool;

        /// <summary>
        /// Initialize the ObjectPool.
        /// </summary>
        /// <param name="_pool"></param>
        public void Init(GameObjectPool _pool)
        {
            pool = _pool;
        }
        /// <summary>
        /// Releases this object and returns it back to the pool.
        /// </summary>
        protected void ReturnToPool()
        {
            if (pool != null)
                pool.ReturnObject(this);
        }
        /// <summary>
        /// To be used in the OnDisable Unity callback.
        /// </summary>
        protected virtual void OnDisabled()
        {
            ReturnToPool();
        }

        /// <summary>
        /// To be used in the OnEnable Unity callback.
        /// </summary>
        protected virtual void OnEnabled()
        {

        }
    }
}
