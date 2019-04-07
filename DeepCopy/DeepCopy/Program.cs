using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime now = DateTime.UtcNow;

            MusicCollection mcoll = new MusicCollection("MyPhone", "Phone");

            MusicFile mfile1 = new MusicFile("Brandenburg Concerto No. 1 in F Major.mp3");
            mfile1.General.Accessed = now;
            mfile1.General.Created = now.AddMonths(-1);
            mfile1.Description.Album = "Bach - Brandenburg Collection";
            mfile1.Description.Genre = "Baroque";

            MusicFile mfile2 = new MusicFile("The Four Seasons.mp3");
            mfile2.General.Accessed = now;
            mfile2.General.Created = now.AddMonths(-2);
            mfile2.Description.Album = "Antonio Vivaldi - The Four Seasons";
            mfile2.Description.Genre = "Classical";

            mcoll.AddMusic(mfile1);
            mcoll.AddMusic(mfile2);

            MusicCollection mcol2 = (MusicCollection)mcoll.Clone();
            mcol2.DeviceName = "MyiPad";
            mcol2.DeviceType = "Tablet";
            mcol2.MusicFiles[1].Description.Genre = "Baroque";

            Console.WriteLine(mcoll.MusicFiles[1].Description.Genre); // Returns Classical when deep-copied
            Console.WriteLine(mcol2.MusicFiles[1].Description.Genre); // Returns Baroque
        }
    }
}
