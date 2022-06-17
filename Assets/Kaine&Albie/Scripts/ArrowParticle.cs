using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class ArrowParticle : MonoBehaviour
    {

        private AudioSource impactSound;


        void Start()
        {
            impactSound = GetComponent<AudioSource>();
            playSoundInterval(2.462f, 2.68f);

        }

        void playSoundInterval(float fromSeconds, float toSeconds)
        {
            if (impactSound)
            {

                if (impactSound.isPlaying)
                {
                    impactSound.Stop();
                }

                impactSound.time = fromSeconds;
                impactSound.pitch = Time.timeScale;
                impactSound.Play();
                impactSound.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
            }
        }
    }
}
