using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {
            // 2.1.3
            var songs = new Song[] {
                new Song("キセキ","a",153),
                new Song("マリーゴールド","b",120),
                new Song("365日","ac",170),
            };
            PrintSongs(songs);
        }

        // 2.1.4
        private static void PrintSongs(Song[] songs) { 

            foreach (var song in songs) {
                //ヒント 153秒の場合(00:02:23)
                Console.WriteLine(@"{0},{1} {2:mm\:ss}",song.Title,song.ArtistName,
                                    TimeSpan.FromSeconds(song.Length));
            }
        }
    }
}
