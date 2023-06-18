using UnityEngine;

namespace Main
{
    public class WitchVillageMusic : MonoBehaviour
    {
        public AudioSource Source;

        private void Start()
        {
            Source.Play();
        }
    }
}