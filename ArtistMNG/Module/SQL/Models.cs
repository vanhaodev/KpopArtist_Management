using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL
{
    public class ModelArtist
    {
        int artistID = 0;
        string stageName;
        string realName;
        int gender;
        DateTime birthDay;
        string birthPlace;
        DateTime debutDay;
        string description;
        ModelFandom fandom = new ModelFandom();
        float height;
        float weight;
        ModelLabel label = new ModelLabel();
        ModelSNS sns = new ModelSNS();
        bool isActivate;

        List<ModelGroup> artistGroup_Add = new List<ModelGroup>();        
        List<ModelImage> artistImage_Add = new List<ModelImage>();
        List<ModelSong> artistSong_Add = new List<ModelSong>();

        List<ModelGroup> artistGroup_Update = new List<ModelGroup>();
        List<ModelImage> artistImage_Update = new List<ModelImage>();
        List<ModelSong> artistSong_Update = new List<ModelSong>();

        List<ModelGroup> artistGroup_Delete = new List<ModelGroup>();
        List<ModelImage> artistImage_Delete = new List<ModelImage>();
        List<ModelSong> artistSong_Delete = new List<ModelSong>();       
        //

        //========================================================
        public int ArtistID { get => artistID; set => artistID = value; }
        public string StageName { get => stageName; set => stageName = value; }
        public string RealName { get => realName; set => realName = value; }
        public int Gender { get => gender; set => gender = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public string BirthPlace { get => birthPlace; set => birthPlace = value; }
        public DateTime DebutDay { get => debutDay; set => debutDay = value; }
        public string Description { get => description; set => description = value; }
        public ModelFandom Fandom { get => fandom; set => fandom = value; }
        public float Height { get => height; set => height = value; }
        public float Weight { get => weight; set => weight = value; }
        public ModelLabel Label { get => label; set => label = value; }
        public ModelSNS Sns { get => sns; set => sns = value; }
        public bool IsActivate { get => isActivate; set => isActivate = value; }

        public List<ModelGroup> ArtistGroup_Add { get => artistGroup_Add; set => artistGroup_Add = value; }
        public List<ModelImage> ArtistImage_Add { get => artistImage_Add; set => artistImage_Add = value; }
        public List<ModelSong> ArtistSong_Add { get => artistSong_Add; set => artistSong_Add = value; }

        public List<ModelGroup> ArtistGroup_Update { get => artistGroup_Update; set => artistGroup_Update = value; }
        public List<ModelImage> ArtistImage_Update { get => artistImage_Update; set => artistImage_Update = value; }
        public List<ModelSong> ArtistSong_Update { get => artistSong_Update; set => artistSong_Update = value; }

        public List<ModelGroup> ArtistGroup_Delete { get => artistGroup_Delete; set => artistGroup_Delete = value; }
        public List<ModelImage> ArtistImage_Delete { get => artistImage_Delete; set => artistImage_Delete = value; }
        public List<ModelSong> ArtistSong_Delete { get => artistSong_Delete; set => artistSong_Delete = value; }
        
    }

    public class ModelGroup
    {
        int groupID = 0;
        string groupName;
        DateTime debutDay;
        ModelFandom fandom = new ModelFandom();
        string description;
        ModelLabel label = new ModelLabel();
        ModelSNS sns = new ModelSNS();
        bool isActivate;
        public int GroupID { get => groupID; set => groupID = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public DateTime DebutDay { get => debutDay; set => debutDay = value; }
        public ModelFandom Fandom { get => fandom; set => fandom = value; }
        public string Description { get => description; set => description = value; }
        public ModelLabel Label { get => label; set => label = value; }
        public ModelSNS Sns { get => sns; set => sns = value; }
        public bool IsActivate { get => isActivate; set => isActivate = value; }

        List<ModelImage> groupImage_Add = new List<ModelImage>();
        List<ModelImage> groupImage_Update = new List<ModelImage>();
        List<ModelImage> groupImage_Delete = new List<ModelImage>();

        List<ModelSong> groupSong_Add = new List<ModelSong>();
        List<ModelSong> groupSong_Update = new List<ModelSong>();
        List<ModelSong> groupSong_Delete = new List<ModelSong>();


        public List<ModelImage> GroupImage_Add { get => groupImage_Add; set => groupImage_Add = value; }
        public List<ModelImage> GroupImage_Update { get => groupImage_Update; set => groupImage_Update = value; }
        public List<ModelImage> GroupImage_Delete { get => groupImage_Delete; set => groupImage_Delete = value; }
        public List<ModelSong> GroupSong_Add { get => groupSong_Add; set => groupSong_Add = value; }
        public List<ModelSong> GroupSong_Update { get => groupSong_Update; set => groupSong_Update = value; }
        public List<ModelSong> GroupSong_Delete { get => groupSong_Delete; set => groupSong_Delete = value; }
    }
  
    public class ModelSong
    {
        int songID = 0;
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
        int albumID = 0;
        string albumName;
        DateTime releaseDay;
        string description;

        public int AlbumID { get => albumID; set => albumID = value; }
        public string AlbumName { get => albumName; set => albumName = value; }
        public DateTime ReleaseDay { get => releaseDay; set => releaseDay = value; }
        public string Description { get => description; set => description = value; }
    }
    public class ModelLabel
    {
        int labelID = 0;
        string labelName;
        string founder;
        DateTime founded;
        string location;
        string description;

        public int LabelID { get => labelID; set => labelID = value; }
        public string LabelName { get => labelName; set => labelName = value; }
        public string Founder { get => founder; set => founder = value; }
        public DateTime Founded { get => founded; set => founded = value; }
        public string Location { get => location; set => location = value; }
        public string Description { get => description; set => description = value; }
    }
    public class ModelImage
    {
        int imageID = 0;
        string imageURL;
        string description;
        public int ImageID { get => imageID; set => imageID = value; }    
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public string Description { get => description; set => description = value; }
    }
    public class ModelFandom
    {
        int fandomID = 0;
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
        string vlive;
        string spotify;
        string appleMusic;
        string website;
        string description;

        public string Youtube { get => youtube; set => youtube = value; }
        public string Instagram { get => instagram; set => instagram = value; }
        public string Facebook { get => facebook; set => facebook = value; }
        public string Twitter { get => twitter; set => twitter = value; }
        public string Tiktok { get => tiktok; set => tiktok = value; }
        public string Vlive { get => vlive; set => vlive = value; }
        public string Spotify { get => spotify; set => spotify = value; }
        public string AppleMusic { get => appleMusic; set => appleMusic = value; }
        public string Website { get => website; set => website = value; }
        public string Description { get => description; set => description = value; }
    }
}
