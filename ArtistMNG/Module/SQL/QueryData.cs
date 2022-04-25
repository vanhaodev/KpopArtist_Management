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
        public ModelArtist Artist { get => artist; set => artist = value; }
        public ModelGroup Group { get => group; set => group = value; }
    }
}
