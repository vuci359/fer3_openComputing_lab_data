COPY(
	select array_to_json(array_agg(row_to_json(music_data))) from(
		select
			 sng.name-- as "song name"
			,bnd.band_name --as "band name"
			,bnd.members-- as "band members"
			,bnd.genre-- as "genre"
			,alb.name-- as "album name"
			,alb.label-- as "album label"
			,alb.date_released-- as "album release date"
			,sng.length-- as "song length"
			,sng.no_on_album-- as "position on album"
			,sng.lyrics_writers-- as "lyrics writers"
			,sng.music_writers-- as "music writers"
			,sng.lyrics as "lyrics"

		from "Band" as bnd
		join "Album" as alb on bnd.ident = alb.band_ident
		join "Song" as sng on alb.ident = sng.album_ident
	order by sng.name asc
		) music_data
)
TO '/tmp/heavy_metal_songs_data.json'
--NEČE SPREMATI PILO KUD
;
