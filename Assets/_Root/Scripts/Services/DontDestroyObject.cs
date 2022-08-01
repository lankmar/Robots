using UnityEngine;
namespace Services
{
    public class DontDestroyObject : MonoBehaviour
    {
        private void Awake() =>
            DontDestroyOnLoad(this);
    }
}