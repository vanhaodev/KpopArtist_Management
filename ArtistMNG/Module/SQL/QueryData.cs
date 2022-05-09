using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL
{
    public class QueryData
    {
        private QueryData() { }
        private static QueryData instance = null;
        public static QueryData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QueryData();
                }
                return instance;
            }
        }
        public void Clear()
        {
            instance = new QueryData();
        }

        ModelArtist artist = new ModelArtist();
        ModelGroup group = new ModelGroup();
        ModelSong song = new ModelSong();
        ModelAlbum album = new ModelAlbum();
        ModelFandom fandom = new ModelFandom();
        ModelLabel label = new ModelLabel();
        public ModelArtist Artist { get => artist; set => artist = value; }
        public ModelGroup Group { get => group; set => group = value; }
        public ModelSong Song { get => song; set => song = value; }
        public ModelAlbum Album { get => album; set => album = value; }
        public ModelFandom Fandom { get => fandom; set => fandom = value; }
        public ModelLabel Label { get => label; set => label = value; }
    }
}
