using System;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemyDeathHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            GetComponent<HealthHandler>().OnDeath += HandleDeath;
        }

        private void HandleDeath(object sender, EventArgs e)
        {
            Destroy(gameObject);
        }
    }
}
