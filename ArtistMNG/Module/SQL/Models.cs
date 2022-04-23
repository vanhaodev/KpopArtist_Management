using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL
{
    public class ModelArtist
    {
        private ModelArtist() { }
        private static ModelArtist instance = null;
        public static ModelArtist Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModelArtist();
                }
                return instance;
            }
        }

        int artistID;
        string stageName;
        string realName;
        DateTime birthDay;
        string birthPlace;
        DateTime debutDay;
        string description;
        ModelFandom fandom = new ModelFandom();
        float height;
        float weight;
        bool isActivate;

        List<ModelGroup> artistGroup_Add = new List<ModelGroup>();        
        List<ModelImage> artistImage_Add = new List<ModelImage>();
        List<ModelLabel> artistLabel_Add = new List<ModelLabel>();
        List<ModelSNS> artistSNS_Add = new List<ModelSNS>();
        List<ModelSong> artistSong_Add = new List<ModelSong>();

        List<ModelGroup> artistGroup_Update = new List<ModelGroup>();
        List<ModelImage> artistImage_Update = new List<ModelImage>();
        List<ModelLabel> artistLabel_Update = new List<ModelLabel>();
        List<ModelSNS> artistSNS_Update = new List<ModelSNS>();
        List<ModelSong> artistSong_Update = new List<ModelSong>();

        List<ModelGroup> artistGroup_Delete = new List<ModelGroup>();
        List<ModelImage> artistImage_Delete = new List<ModelImage>();
        List<ModelLabel> artistLabel_Delete = new List<ModelLabel>();
        List<ModelSNS> artistSNS_Delete = new List<ModelSNS>();
        List<ModelSong> artistSong_Delete = new List<ModelSong>();       
        //

        //========================================================
        public int ArtistID { get => artistID; set => artistID = value; }
        public string StageName { get => stageName; set => stageName = value; }
        public string RealName { get => realName; set => realName = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public string BirthPlace { get => birthPlace; set => birthPlace = value; }
        public DateTime DebutDay { get => debutDay; set => debutDay = value; }
        public string Description { get => description; set => description = value; }
        public ModelFandom Fandom { get => fandom; set => fandom = value; }
        public float Height { get => height; set => height = value; }
        public float Weight { get => weight; set => weight = value; }
        public bool IsActivate { get => isActivate; set => isActivate = value; }

        public List<ModelGroup> ArtistGroup_Add { get => artistGroup_Add; set => artistGroup_Add = value; }
        public List<ModelImage> ArtistImage_Add { get => artistImage_Add; set => artistImage_Add = value; }
        public List<ModelLabel> ArtistLabel_Add { get => artistLabel_Add; set => artistLabel_Add = value; }
        public List<ModelSNS> ArtistSNS_Add { get => artistSNS_Add; set => artistSNS_Add = value; }
        public List<ModelSong> ArtistSong_Add { get => artistSong_Add; set => artistSong_Add = value; }

        public List<ModelGroup> ArtistGroup_Update { get => artistGroup_Update; set => artistGroup_Update = value; }
        public List<ModelImage> ArtistImage_Update { get => artistImage_Update; set => artistImage_Update = value; }
        public List<ModelLabel> ArtistLabel_Update { get => artistLabel_Update; set => artistLabel_Update = value; }
        public List<ModelSNS> ArtistSNS_Update { get => artistSNS_Update; set => artistSNS_Update = value; }
        public List<ModelSong> ArtistSong_Update { get => artistSong_Update; set => artistSong_Update = value; }

        public List<ModelGroup> ArtistGroup_Delete { get => artistGroup_Delete; set => artistGroup_Delete = value; }
        public List<ModelImage> ArtistImage_Delete { get => artistImage_Delete; set => artistImage_Delete = value; }
        public List<ModelLabel> ArtistLabel_Delete { get => artistLabel_Delete; set => artistLabel_Delete = value; }
        public List<ModelSNS> ArtistSNS_Delete { get => artistSNS_Delete; set => artistSNS_Delete = value; }
        public List<ModelSong> ArtistSong_Delete { get => artistSong_Delete; set => artistSong_Delete = value; }
        

        public void Clear()
        {
            instance = new ModelArtist();
        }
        //
    }
    public class ModelGroup
    {
        int groupID;
        string groupName;
        DateTime debutDay;
        int fandomID;
        string description;

        public int GroupID { get => groupID; set => groupID = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public DateTime DebutDay { get => debutDay; set => debutDay = value; }
        public int FandomID { get => fandomID; set => fandomID = value; }
        public string Description { get => description; set => description = value; }
    }
    public class ModelSong
    {
        int songID;
        string songName;
        DateTime releaseDay;
        string genre;
        string producer;
        string description;

        public int SongID { get => songID; set => songID = value; }
        public string SongName { get => songName; set => songName = value; }
        public DateTime ReleaseDay { get => releaseDay; set => releaseDay = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Producer { get => producer; set => producer = value; }
        public string Description { get => description; set => description = value; }
    }
    public class ModelAlbum
    {

    }
    public class ModelLabel
    {

    }
    public class ModelImage
    {
        int imageID;
        string imageURL;
        string description;
        public int ImageID { get => imageID; set => imageID = value; }    
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public string Description { get => description; set => description = value; }
    }
    public class ModelFandom
    {
        int fandomID;
        string fandomName;
        string description;

        public int FandomID { get => fandomID; set => fandomID = value; }
        public string FandomName { get => fandomName; set => fandomName = value; }
        public string Description { get => description; set => description = value; }
    }
    public class ModelSNS
    {
        string youtube;
        string instagram;
        string facebook;
        string twitter;
        string tiktok;
        string description;

        public string Youtube { get => youtube; set => youtube = value; }
        public string Instagram { get => instagram; set => instagram = value; }
        public string Facebook { get => facebook; set => facebook = value; }
        public string Twitter { get => twitter; set => twitter = value; }
        public string Tiktok { get => tiktok; set => tiktok = value; }
        public string Description { get => description; set => description = value; }
    }
}
