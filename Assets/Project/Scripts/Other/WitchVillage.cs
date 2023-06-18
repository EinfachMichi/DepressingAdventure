using System;
using DialogSystem;
using UnityEngine;

namespace Other
{
    public class WitchVillage : MonoBehaviour
    {
        public Dialog dialog;

        private void Start()
        {
            Invoke("LateStart", 0.2f);
        }

        private void LateStart()
        {
            DialogManager.Instance.StartDialog(dialog);
        }
    }
}