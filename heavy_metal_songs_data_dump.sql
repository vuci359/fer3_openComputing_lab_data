--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4
-- Dumped by pg_dump version 15.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Album; Type: TABLE; Schema: public; Owner: vuci359
--

CREATE TABLE public."Album" (
    ident integer NOT NULL,
    band_ident integer NOT NULL,
    name character varying(25) NOT NULL,
    label character varying(25) NOT NULL,
    date_released date NOT NULL
);


ALTER TABLE public."Album" OWNER TO postgres;

--
-- Name: Album_ID_seq; Type: SEQUENCE; Schema: public; Owner: vuci359
--

CREATE SEQUENCE public."Album_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Album_ID_seq" OWNER TO postgres;

--
-- Name: Album_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: vuci359
--

ALTER SEQUENCE public."Album_ID_seq" OWNED BY public."Album".ident;


--
-- Name: Band; Type: TABLE; Schema: public; Owner: vuci359
--

CREATE TABLE public."Band" (
    ident integer NOT NULL,
    band_name character varying(50) NOT NULL,
    genre character varying(15) NOT NULL,
    year_founded integer NOT NULL,
    members character varying(25)[] NOT NULL
);


ALTER TABLE public."Band" OWNER TO postgres;

--
-- Name: Band_ID_seq; Type: SEQUENCE; Schema: public; Owner: vuci359
--

CREATE SEQUENCE public."Band_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Band_ID_seq" OWNER TO postgres;

--
-- Name: Band_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: vuci359
--

ALTER SEQUENCE public."Band_ID_seq" OWNED BY public."Band".ident;


--
-- Name: Song; Type: TABLE; Schema: public; Owner: vuci359
--

CREATE TABLE public."Song" (
    ident integer NOT NULL,
    album_ident integer NOT NULL,
    name character varying(30) NOT NULL,
    length interval NOT NULL,
    no_on_album integer,
    lyrics_writers character varying(25)[],
    music_writers character varying(25)[],
    lyrics text
);


ALTER TABLE public."Song" OWNER TO postgres;

--
-- Name: Song_ID_seq; Type: SEQUENCE; Schema: public; Owner: vuci359
--

CREATE SEQUENCE public."Song_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Song_ID_seq" OWNER TO postgres;

--
-- Name: Song_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: vuci359
--

ALTER SEQUENCE public."Song_ID_seq" OWNED BY public."Song".ident;


--
-- Name: Album ident; Type: DEFAULT; Schema: public; Owner: vuci359
--

ALTER TABLE ONLY public."Album" ALTER COLUMN ident SET DEFAULT nextval('public."Album_ID_seq"'::regclass);


--
-- Name: Band ident; Type: DEFAULT; Schema: public; Owner: vuci359
--

ALTER TABLE ONLY public."Band" ALTER COLUMN ident SET DEFAULT nextval('public."Band_ID_seq"'::regclass);


--
-- Name: Song ident; Type: DEFAULT; Schema: public; Owner: vuci359
--

ALTER TABLE ONLY public."Song" ALTER COLUMN ident SET DEFAULT nextval('public."Song_ID_seq"'::regclass);


--
-- Data for Name: Album; Type: TABLE DATA; Schema: public; Owner: vuci359
--

COPY public."Album" (ident, band_ident, name, label, date_released) FROM stdin;
1	1	Kill 'Em All	Megaforce Records	1983-07-25
2	1	Ride The Lightning	Megaforce Records	1984-07-27
3	1	The Black Album	Elektra Records	1991-08-12
4	3	Appetite for Destruction	Greffen Records	1987-07-21
5	2	Ace of Spades	Bronze Records	1980-11-08
6	2	Bomber	Bronze Records	1979-10-12
7	2	Motorhead	Chriswick Records	1977-08-12
\.


--
-- Data for Name: Band; Type: TABLE DATA; Schema: public; Owner: vuci359
--

COPY public."Band" (ident, band_name, genre, year_founded, members) FROM stdin;
1	Metallica	Trash Metal	1981	{"'James Hetfield'","'Kirk Hamett'","'Robert Trujilo'","'Lars Ulrich'"}
3	Guns N' Roses	Glam Rock	1985	{"Axl Rose","Saul Hudson","Izzy Stradlin","Duff McKagan","Steven Adler"}
2	Motorhead	Rock 'N' Roll	1975	{"Lemmy Kilmister","Phil Campbell","Mikkey Dee"}
\.


--
-- Data for Name: Song; Type: TABLE DATA; Schema: public; Owner: vuci359
--

COPY public."Song" (ident, album_ident, name, length, no_on_album, lyrics_writers, music_writers, lyrics) FROM stdin;
11	7	Iron Horse / Born to Lose	05:21:00	4	{"Lemmy Kilmister"}	{"Phil Taylor","Mick Brown","Guy 'Tramp' Lawrence"}	"Iron Horse / Born To Lose"\n\nHe rides a road, that don't have no end,\nAn open highway, without any bends,\nTramp and his stallion, alone in a dream,\nProud in his colours, as the chromium gleams,\nOn Iron Horse he flies, on Iron Horse he gladly dies,\nIron Horse his wife, Iron Horse his life\n\nHe lives his life, he's living it fast,\nDon't try to hide, when the dice have been cast,\nHe rides a whirlwind, that cuts to the bone,\nLoaded forever, and righteously stoned,\nOn Iron Horse he flies, on Iron Horse he gladly dies,\nIron Horse his wife, Iron Horse his life\n\nYeah, slide it to me!\n\nOne day one day, they'll go for the sun,\nTogether they'll slide, on the eternal run,\nWasted forever, on speed bikes and booze,\nYeah tramp and the brothers, all born to lose,\nOn Iron Horse he flies, on Iron Horse he gladly dies,\nIron Horse his wife, Iron Horse his life 
8	5	Love Me Like a Reptyle	03:21:00	2	{"Lemmy Kilmister"}	{"Lemmy Kilmister","Eddie Clarke","Phil Taylor"}	"Love Me Like A Reptile"\n\nKnew I had to bite you baby when I first set eyes on you,\nThat moment turned me on, I can't believe it's true,\nI like to watch your body sway,\nI got no choice, I'm gonna twist your tail,\nLove Me Like A Reptile, I'm gonna sink my fangs in you\n\nThunder lizard, stony eye, you got me hypnotised,\nHot tongue breaks in and out and I can't believe my eyes,\nAnd your soft white belly, next to mine,\nScaly baby, see you shine,\nLove Me Like A Reptile, you're murder in disguise,\nBlack mamba, murder in disguise\n\nBaby you're a rattlesnake, you know the way I feel,\nFeel you crawling up my back, you've got no love to steal,\nYou know I've got my eyes on you,\nYou're petrified, gonna stick like glue,\nLove Me Like A Reptile, shock you like an electric eel
9	5	(We Are) the Road Crew	03:10:00	6	{"Lemmy Kilmister"}	{"Lemmy Kilmister","Eddie Clarke","Phil Taylor"}	"We Are The Road Crew"\n\nAnother town another place,\nAnother girl, another face,\nAnother truce, another race,\nI'm eating junk, feeling bad,\nAnother night, I'm going mad,\nMy woman's leaving, I feel sad,\nBut I just love the life I lead,\nAnother beer is what I need,\nAnother gig my ears bleed,\nWe are the road crew\n\nAnother town I've left behind,\nAnother drink completely blind,\nAnother hotel I can't find,\nAnother backstage pass for you,\nAnother tube of super glue,\nAnother border to get through,\nI'm driving like a maniac,\nDriving my way to hell and back,\nAnother room a case to pack,\nWe are the road crew\n\nAnother hotel we can burn,\nAnother screw, another turn,\nAnother Europe map to learn,\nAnother truck stop on the way,\nAnother game I learn to play,\nAnother word I learn to say,\nAnother bloody customs post,\nAnother fucking foreign coast,\nAnother set of scars to boast,\nWe are the road crew
10	7	Motorhead	03:13:00	1	{"Lemmy Kilmister"}	{"Lemmy Kilmister"}	"Motörhead"\n\nSunrise, wrong side of another day,\nSky high and six thousand miles away,\nDon't know how long I've been awake,\nWound up in an amazing state,\nCan't get enough,\nAnd you know it's righteous stuff,\nGoes up like prices at Christmas,\nMotörhead, you can call me Motörhead, alright\n\nBrain dead, total amnesia,\nGet some mental anaesthesia,\nDon't move, I'll shut the door and kill the lights,\nAnd if I can't be wrong I could be right,\nAll good clean fun,\nHave another stick of gum,\nMan, you look better already,\nMotörhead, remember me now Motörhead, alright\n\nFourth day, five day marathon,\nWe're moving like a parallelogram,\nDon't move, I'll shut the door and kill the lights,\nI guess I'll see you all on the ice,\nI should be tired,\nAnd all I am is wired,\nAin't felt this good for an hour,\nMotörhead, remember me now, Motörhead alright
12	6	Bomber	03:43:00	10	{"Lemmy Kilmister"}	{"Lemmy Kilmister","Eddie Clarke","Phil Taylor"}	"Bomber"\n\nAin't a hope in hell\nNothin' gonna bring us down\nThe way we fly\nFive miles off the ground\nBecause, we shoot to kill\nAnd you know we always will\nIt's a Bomber\nIt's a Bomber\nIt's a Bomber\n\nScream a thousand miles\nFeel the black death rising moan\nFirestorm coming closer\nNapalm to the bone\nBecause, you know we do it right\nA mission every night\nIt's a Bomber\nIt's a Bomber\nIt's a Bomber\n\nNo nightfighter\nGonna stop us getting through\nSirens make you shiver\nYou bet my aim is true\nBecause, we aim to please\nBring you to your knees\nIt's a Bomber\nIt's a Bomber\nIt's a Bomber 
13	6	Dead Men Tell No Tales	03:07:00	1	{"Lemmy Kilmister"}	{"Lemmy Kilmister","Eddie Clarke","Phil Taylor"}	"Dead Men Tell No Tales"\n\nThis is it!\n\nBreaking up or breaking through,\nBreaking something's all we ever do,\nShoot straight, travel far,\nStone crazy's all we ever are,\nBut I don't care for lies,\nAnd I won't tell you twice,\nBecause when all else fails,\nDead Men Tell No Tales\n\nShooting up away and back,\nA bit of guts is all that you lack,\nFar behind the stable door,\nI know you've met that horse before,\nBut I don't care for skag,\nAnd this sure ain't no blag,\nAt the end of all the tracks and trails,\nDead Men Tell No Tales\n\nYou used to be my friend,\nBut that friendship's coming to an end,\nMy meaning must be clear,\nYou know pity is all that you hear,\nBut if you're doing smack,\nYou won't be coming back,\nI ain't the one to make your bail,\nDead Men Tell No Tales 
14	4	Paradise City	06:46:00	6	{"Axl Rose","Saul Hudson","Izzy Stradlin","Duff McKagan","Steven Adler"}	{"Axl Rose","Saul Hudson","Izzy Stradlin","Duff McKagan","Steven Adler"}	"Paradise City"\n\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\n(Take me home) Oh, won't you please take me home?\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\n(Take me home) Oh, won't you please take me home?\n\nJust an urchin living under the street, I'm a\nHard case that's tough to beat\nI'm your charity case, so buy me something to eat\nI'll pay you at another time, take it to the end of the line\nRags and riches, or so they say, you gotta\nKeep pushing for the fortune and fame\nYou know it's, it's all a gamble when it's just a game\nYou treat it like a capital crime, everybody's doing the time\n\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nOh, won't you please take me home? Yeah-yeah\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nTake me home\n\nStrapped in the chair of the city's gas chamber\nWhy I'm here, I can't quite remember\nThe Surgeon General says it's hazardous to breathe\nI'd have another cigarette\nBut I can't see, tell me who you're gonna believe\n\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nTake me home, yeah-yeah\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nOh, won't you please take me home, oh yeah\n\nSo far–away\nSo far–away\nSo far–away\nSo far–away\n\nCaptain America's been torn apart, now\nHe's a court jester with a broken heart\nHe said, "Turn me around and take me back to the start"\nI must be losing my mind, are you blind? I've seen it all a million times\n\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nTake me home, yeah-yeah\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nOh, won't you please take me home\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nTake me home, yeah-yeah\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nOh, won't you please take me home, home\n\nI wanna go, I wanna know\nOh, won't you please take me home?\nI wanna see, how good it can be\nOh, won't you please take me home?\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\n(Take me home) Oh, won't you please take me home?\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nOh, won't you please take me home?\nTake me down (oh yeah), spin me 'round\nOh, won't you please take me home?\nI wanna see, how good it can be\nOh, won't you please take me home?\nI wanna see, how good it can be\nOh, take me home?\nTake me down to the Paradise City\nWhere the grass is green and the girls are pretty\nOh, won't you please take me home?\nI wanna go, I wanna know\nOh, won't you please take me home?\nBaby
2	1	Hit The Lights	04:17:00	1	{"'James Hetfield'"}	{"'James Hetfield'","'Lars Ulrich'"}	[Verse 1]\nNo life ‘til leather\nWe're gonna kick some ass tonight\nWe got the metal madness\nWhen our fans start screaming, it's right\nWell, all right, yeah\n\n[Pre-Chorus]\nWhen we start to rock\nWe never wanna stop again\n\n[Chorus]\nHit the lights!\nHit the lights!\nHit the lights!\n\n[Verse 2]\nYou know our fans are insane\nWe're gonna blow this place away\nWith volume higher\nThan anything today\nThe only way, yeah\n\n[Pre-Chorus]\nWhen we start to rock\nWe never wanna stop again\nYou might also like\nThe Four Horsemen\nMetallica\nWhiplash\nMetallica\nMotorbreath\nMetallica\n[Chorus]\nHit the lights!\nHit the lights!\nHit the lights!\n\n[Verse 3]\nWith all-out screaming\nWe're gonna rip right through your brain\nWe got the lethal power\nIt is causing you sweet pain\nOh, sweet pain, yeah\n\n[Pre-Chorus]\nWhen we start to rock\nWe never wanna stop again\n\n[Chorus]\nHit the lights!\nHit the lights!\nHit the lights!\nHit the lights!\n\n[Instrumental Break]\n[Guitar Solo]
3	1	The Four Horsemen	07:13:00	2	{"'James Hetfield'"}	{"'James Hetfield'","'Lars Ulrich'","Dave Mustaine"}	"The Four Horsemen"\n\nBy the last breath of the fourth winds blow\nBetter raise your ears\nThe sound of hooves knock at your door\nLock up your wife and children now\nIt's time to wield the blade\nFor now you have got some company\n\nThe Horsemen are drawing nearer\nOn leather steeds they ride\nThey've come to take your life\nOn through the dead of night\nWith the Four Horsemen ride\nOr choose your fate and die\n\nYou have been dying since the day you were born\nYou know it has all been planned\nThe quartet of deliverance rides\nA sinner once a sinner twice\nNo need for confessions now\nCause now you have got the fight of your life\n\nThe Horsemen are drawing nearer\nOn leather steeds they ride\nThey've come to take your life\nOn through the dead of night\nWith the Four Horsemen ride\nOr choose your fate and die\n\nTime\nHas taken its toll on you\nThe lines that crack your face\nFamine\nYour body it has torn through\nWithered in every place\nPestilence\nFor what you have had to endure\nAnd what you have put others through\nDeath\nDeliverance for you for sure\nNow there is nothing you can do\n\nSo gather round young warriors now\nAnd saddle up your steeds\nKilling scores with demon swords\nNow is the death of doers of wrong\nSwing the judgement hammer down\nSafely inside armor blood guts and sweat\n\nThe Horsemen are drawing nearer\nOn leather steeds they ride\nThey've come to take your life\nOn through the dead of night\nWith the Four Horsemen ride\nOr choose your fate and die 
4	2	Fade to Black	06:55:00	4	{"James Hetfield"}	{"James Hetfield","Lars Ulrich","Cliff Burton","Kirk Hammett"}	"Fade To Black"\n\nLife, it seems, will fade away\nDrifting further every day\nGetting lost within myself\nNothing matters, no one else\n\nI have lost the will to live\nSimply nothing more to give\nThere is nothing more for me\nNeed the end to set me free\n\nThings not what they used to be\nMissing one inside of me\nDeathly lost, this can't be real\nCannot stand this hell I feel\n\nEmptiness is filling me\nTo the point of agony\nGrowing darkness taking dawn\nI was me, but now he's gone\n\nNo one but me can save myself, but it's too late\nNow I can't think, think why I should even try\n\nYesterday seems as though it never existed\nDeath greets me warm, now I will just say goodbye\nGoodbye 
5	2	For Whom the Bell Tolls	05:11:00	3	{"James Hetfield"}	{"James Hetfield","Lars Ulrich","Cliff Burton"}	"For Whom The Bell Tolls"\n\nMake his fight on the hill in the early day\nConstant chill deep inside\nShouting gun, on they run through the endless grey\nOn they fight, for they're right, yes, but who's to say?\nFor a hill, men would kill, why? They do not know\nStiffened wounds test their pride\nMen of five, still alive through the raging glow\nGone insane from the pain that they surely know\n\nFor whom the bell tolls\nTime marches on\nFor whom the bell tolls\n\nTake a look to the sky just before you die\nIt's the last time you will\nBlackened roar, massive roar, fills the crumbling sky\nShattered goal fills his soul with a ruthless cry\nStranger now, are his eyes, to this mystery\nHe hears the silence so loud\nCrack of dawn, all is gone except the will to be\nNow they see what will be, blinded eyes to see\n\nFor whom the bell tolls\nTime marches on\nFor whom the bell tolls 
6	3	Enter Sandman	05:31:00	1	{"James Hetfield"}	{"James Hetfield","Lars Ulrich","Kirk Hammett"}	"Enter Sandman"\n\nSay your prayers, little one\nDon't forget, my son\nTo include everyone\n\nI tuck you in, warm within\nKeep you free from sin\nTill the Sandman he comes\n\nSleep with one eye open\nGripping your pillow tight\n\nExit light\nEnter night\nTake my hand\nWe're off to Never—, Neverland\n\nSomething's wrong, shut the light\nHeavy thoughts tonight\nAnd they aren't of Snow White\n\nDreams of war, dreams of liars\nDreams of dragon's fire\nAnd of things that will bite\n\nSleep with one eye open\nGripping your pillow tight\n\nExit light\nEnter night\nTake my hand\nWe're off to Never—, Neverland\n\nNow I lay me down to sleep\nPray the Lord my soul to keep\nIf I die before I wake\nPray the Lord my soul to take\n\nHush little baby, don't say a word\nAnd never mind that noise you heard\nIt's just the beasts under your bed\nIn your closet, in your head\n\nExit light\nEnter night\nGrain of sand\n\nExit light\nEnter night\nTake my hand\nWe're off to Never—, Neverland\n\nWe're off to Never—, Neverland\nTake my hand\nWe're off to Never—, Neverland\nTake my hand\nWe're off to Never—, Neverland\nWe're off to Never—, Neverland\nWe're off to Never—, Neverland\nWe're off to Never—, Neverland 
7	3	The Unforgiven	06:27:00	4	{"James Hetfield"}	{"James Hetfield","Lars Ulrich","Kirk Hammett"}	"The Unforgiven"\n\nNew blood joins this earth,\nAnd quickly he's subdued.\nThrough constant pained disgrace\nThe young boy learns their rules.\n\nWith time the child draws in.\nThis whipping boy done wrong.\nDeprived of all his thoughts\nThe young man struggles on and on he's known\nA vow unto his own,\nThat never from this day\nHis will they'll take away.\n\nWhat I've felt,\nWhat I've known\nNever shined through in what I've shown.\nNever be.\nNever see.\nWon't see what might have been.\n\nWhat I've felt,\nWhat I've known\nNever shined through in what I've shown.\nNever free.\nNever me.\nSo I dub thee unforgiven.\n\nThey dedicate their lives\nTo running all of his.\nHe tries to please them all –\nThis bitter man he is.\n\nThroughout his life the same –\nHe's battled constantly.\nThis fight he cannot win –\nA tired man they see no longer cares.\n\nThe old man then prepares\nTo die regretfully –\nThat old man here is me.\n\nWhat I've felt,\nWhat I've known\nNever shined through in what I've shown.\nNever be.\nNever see.\nWon't see what might have been.\n\nWhat I've felt,\nWhat I've known\nNever shined through in what I've shown.\nNever free.\nNever me.\nSo I dub thee unforgiven.\n\n[Solo]\n\nWhat I've felt,\nWhat I've known\nNever shined through in what I've shown.\nNever be.\nNever see.\nWon't see what might have been.\n\nWhat I've felt,\nWhat I've known\nNever shined through in what I've shown.\nNever free.\nNever me.\nSo I dub thee unforgiven.\n\nNever free.\nNever me.\nSo I dub thee unforgiven.\n\nYou labelled me,\nI'll label you.\nSo I dub thee unforgiven.\n\nNever free.\nNever me.\nSo I dub thee unforgiven.\n\nYou labelled me,\nI'll label you.\nSo I dub thee unforgiven.\n\nNever free.\nNever me.\nSo I dub thee unforgiven. 
15	4	Sweet Child o Mine	05:55:00	9	{"Axl Rose"}	{"Axl Rose","Saul Hudson","Izzy Stradlin","Duff McKagan","Steven Adler"}	"Sweet Child O' Mine"\n\nShe's got a smile that it seems to me\nReminds me of childhood memories\nWhere everything was as fresh as the bright blue sky (Sky)\nNow and then when I see her face\nShe takes me away to that special place\nAnd if I stared too long I'd probably break down and cry\n\nWhoa-oh-oh! Sweet child o' mine\nWhoa, oh-oh-oh! Sweet love of mine\n\nShe's got eyes of the bluest skies\nAs if they thought of rain\nI hate to look into those eyes and see an ounce of pain\nHer hair reminds me of a warm, safe place\nWhere as a child I'd hide\nAnd pray for the thunder and the rain to quietly pass me by\n\nWhoa-oh-oh! Sweet child o' mine\nOoh, oh-oh-oh! Sweet love of mine\n\nOh yeah! Whoa-oh-oh-oh! Sweet child o' mine\nOoh-oh, oh, oh! Sweet love of mine\nWhoa, oh-oh-oh! Sweet child o' mine, ooh yeah\nOoh! Sweet love of mine\n\nWhere do we go?\nWhere do we go now?\nWhere do we go?\nOoh, where do we go?\nWhere do we go now?\nOh, where do we go now?\nWhere do we go? (Sweet child)\nOoh, where do we go now?\nAy, ay, ay, ay, ay, ay, ay, ay\nWhere do we go now? Ah-ah-ah-ah-ah, wow\nWhere do we go?\nOh, where do we go now?\nOh, where do we go?\nWhere do we go now?\nWhere do we go?\nOoh, where do we go now?\nNow, now, now, now, now, now, now\nSweet child, sweet child o' mine 
\.


--
-- Name: Album_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: vuci359
--

SELECT pg_catalog.setval('public."Album_ID_seq"', 7, true);


--
-- Name: Band_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: vuci359
--

SELECT pg_catalog.setval('public."Band_ID_seq"', 3, true);


--
-- Name: Song_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: vuci359
--

SELECT pg_catalog.setval('public."Song_ID_seq"', 15, true);


--
-- Name: Album Album_pkey; Type: CONSTRAINT; Schema: public; Owner: vuci359
--

ALTER TABLE ONLY public."Album"
    ADD CONSTRAINT "Album_pkey" PRIMARY KEY (ident);


--
-- Name: Band Band_pkey; Type: CONSTRAINT; Schema: public; Owner: vuci359
--

ALTER TABLE ONLY public."Band"
    ADD CONSTRAINT "Band_pkey" PRIMARY KEY (ident);


--
-- Name: Song Song_pkey; Type: CONSTRAINT; Schema: public; Owner: vuci359
--

ALTER TABLE ONLY public."Song"
    ADD CONSTRAINT "Song_pkey" PRIMARY KEY (ident);


--
-- PostgreSQL database dump complete
--

