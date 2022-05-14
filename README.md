# KpopArtist_Management
[CREATE - UPDATE - DELETE] 
Table:
- Artist (can restore after deleted)
- Group (can not restore - auto DELETE ArtistGroup, GroupFandom, GroupSong) 
- Fandom (can not restore - auto UPDATE FandomID of Artist and Group to FandomID = 0) 
- Song (can not restore - auto DELETE GroupSong, ArtistSong, AlbumSong) 
- Album (can not restore - auto DELETE AlbumSong) 
- SNS (can not restore - auto UPDATE SNSID of Artist and Group to SNSID = 0) 
- Label (can not restore - auto UPDATE LabelID of Artist and Group to LabelID = 0) 
- Image (can not restore - auto DELETE ArtistImage) 

Winform C# Visual Studio 2019 [.NET 4.5]
The language in the app is Vietnamese, you can change it to another language by changing the label control value

SQL file [Artist.sql] (SqlMng 2018)
SQL Connect string [ArtistMNG/Module/SQL/DatabaseManager.cs]

![image](https://user-images.githubusercontent.com/86046654/167543849-d225b28b-3ccc-4825-8460-374f9ae9d0af.png)

