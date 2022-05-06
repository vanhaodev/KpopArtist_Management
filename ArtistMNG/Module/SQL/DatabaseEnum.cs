using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL
{
    public enum DatabaseTable
    {
        None = 0, Artist, Group, Song, Album, Label, Image, SNS, Fandom
    }
    public enum DatabaseExecuteState
    {
        None = 0, Select, Insert, Update, Hide, Delete
    }
}
