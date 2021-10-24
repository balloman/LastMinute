using UnityEngine;

namespace Extensions
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Instantly points toward a target point
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target">The point to look at</param>
        public static void LookAt2D(this Transform transform, Vector2 target)
        {
            transform.up = transform.position - (Vector3) target;
        }
        
        /// <summary>
        /// Instantly points toward a game object
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target">The game object to look at</param>
        public static void LookAt2D(this Transform transform, Transform target)
        {
            LookAt2D(transform, target.position);
        }

        /// <summary>
        /// Looks at a specific point over time
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target">The point to look at</param>
        /// <param name="speed">How fast to rotate</param>
        public static void SlowLookAt2D(this Transform transform, Vector2 target, float speed)
        {
            var direction = (Vector3) target - transform.position;
            var toRotation = Quaternion.LookRotation(transform.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }

        /// <summary>
        /// Looks at a specific transform over time
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target">The transform of the <see cref="GameObject"/> to point at</param>
        /// <param name="speed">How fast to rotate</param>
        public static void SlowLookAt2D(this Transform transform, Transform target, float speed)
        {
            SlowLookAt2D(transform, target.position, speed);
        }
    }
}
