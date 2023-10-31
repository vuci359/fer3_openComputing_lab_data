select bnd.band_name as "band name", bnd.members as "band members",
		bnd.genre as "genre", alb.name as "album name", alb.label as "album label",
		alb.date_released as "album release date", sng.name as "song name",
		sng.length as "song length", sng.no_on_album as "position on album",
		sng.lyrics_writers as "lyrics writers", sng.music_writers as "music writers"
from "Band" as bnd
join "Album" as alb on bnd.ident = alb.band_ident
join "Song" as sng on alb.ident = sng.album_ident
order by sng.name asc;