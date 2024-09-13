using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cheesed
{
    public class Sound
    {
        public List<Sound> sounds = new List<Sound>();

        public Vector2 pos { set; get; }

        public Song sound;

        public float scale { set; get; }


        public float rot { set; get; }

        public Sound()
        {
        }
        public Sound(string SOUND)
        {
            sounds.Add(new Sound { sound = Helper.content.Load<Song>("Sound\\" + SOUND) }) ;
        }

        public void UpdateSound(string SOUND)
        {
            foreach(Sound sound in sounds)
            {
                sound.sound = Helper.content.Load<Song>("Sound\\" + SOUND);
            }
        }

        public void LoopSound()
        {

            MediaPlayer.IsRepeating = true;
            
        }

        public void Play()
        {
            foreach(Sound sound in sounds)
            { 
                if (sound.sound != null || sound.sound != Helper.content.Load<Song>(""))
                {
                    MediaPlayer.Play(sound.sound);
                }
            }
        }

        public void Stop()
        {

           MediaPlayer.Stop();

        }


    }
}
