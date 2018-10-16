using System;

namespace ConsoleApp
{
    internal class MediaPlayer
    {
        public MediaPlayer()
        {
        }

        public void Play() { }
        public void Pause() { }
        public void Stop() { }

        //private AllTracks allSongs = new AllTracks(); 
        //public AllTracks GetAllTracks()
        //{ return allSongs; }

        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();
        public AllTracks GetAllTracks()
        {
            return allSongs.Value;
        }

        Array
    }

    internal class AllTracks
    {
        private Song[] allSongs = new Song[10000];
        public AllTracks()
        {
            Console.WriteLine("load all songs.");
        }

    }

    internal class Song
    {
        public string Name { get; set; }
        public string TrackName { get; set; }
        public string TrackLength { get; set; }
    }
}