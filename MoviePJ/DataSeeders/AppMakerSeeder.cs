using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppMakerSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppMaker> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
			builder.HasData(

				//todo Movie
				//!Single
				// Blade Runner
				new AppMaker
				{
					Id = 1,
					FullName = "Denis Villeneuve",
					Avatar = "upload/MovieSingle/BladeRunner/FilmMaker/Denis_Villeneuve.jpg",
					CreatedDate = now
				},

				// Dad, I'm Sorry
				new AppMaker
				{
					Id = 2,
					FullName = "Trấn Thành",
					Avatar = "upload/MovieSingle/DadImSorry/FilmMaker/Tran_Thanh.jpg",
					CreatedDate = now
				},

				// Into The Wild
				new AppMaker
				{
					Id = 3,
					FullName = "Sean Penn",
					Avatar = "upload/MovieSingle/IntoTheWild/FilmMaker/Sean_Penn.JPG",
					CreatedDate = now
				},

				// IT
				new AppMaker
				{
					Id = 4,
					FullName = "Andy Muschietti",
					Avatar = "upload/MovieSingle/IT/FilmMaker/Andy_Muschietti.jpg",
					CreatedDate = now
				},

				// My Best Summer
				new AppMaker
				{
					Id = 5,
					FullName = "Zhang Disha",
					Avatar = "upload/MovieSingle/MyBestSummer/FilmMaker/Disha_Zhang.jpg",
					CreatedDate = now
				},

				// Oblivion
				new AppMaker
				{
					Id = 6,
					FullName = "Joseph Kosinski",
					Avatar = "upload/MovieSingle/Oblivion/FilmMaker/Joe_Kosinski.jpg",
					CreatedDate = now
				},
				
				new AppMaker
				{
					Id = 7,
					FullName = "Peter Chernin",
					Avatar = "upload/MovieSingle/Oblivion/FilmMaker/Peter_Chernin.jpg",
					CreatedDate = now
				},

				// Paddington
				new AppMaker
				{
					Id = 8,
					FullName = "David Heyman",
					Avatar = "upload/MovieSingle/Paddington/FilmMaker/David_Heyman.jpg",
					CreatedDate = now
				},

				// Spaceman
				new AppMaker
				{
					Id = 9,
					FullName = "Johan Renck",
					Avatar = "upload/MovieSingle/Spaceman/FilmMaker/Johan_Renck.jpg",
					CreatedDate = now
				},
				
				new AppMaker
				{
					Id = 10,
					FullName = "Colby Day",
					Avatar = "upload/MovieSingle/Spaceman/FilmMaker/Colby_Day.jpg",
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppMaker
				{
					Id = 11,
					FullName = "Jennifer Perrott",
					Avatar = "upload/MovieSingle/TheVelveteenRabbit/FilmMaker/Jennifer_Perrott.jpg",
					CreatedDate = now
				},
				
				new AppMaker
				{
					Id = 12,
					FullName = "Rick Thiele",
					Avatar = "upload/MovieSingle/TheVelveteenRabbit/FilmMaker/Rick_Thiele.jpg",
					CreatedDate = now
				},

				// The Walk
				new AppMaker
				{
					Id = 13,
					FullName = "Robert Zemeckis",
					Avatar = "upload/MovieSingle/TheWalk/FilmMaker/Robert_Zemeckis.jpg",
					CreatedDate = now
				},
				
				new AppMaker
				{
					Id = 14,
					FullName = "Steve Starkey",
					Avatar = "upload/MovieSingle/TheWalk/FilmMaker/Steve_Starkey.jpg",
					CreatedDate = now
				},

				//!Series
				// Constellation
				new AppMaker
				{
					Id = 15,
					FullName = "Michelle Maclaren",
					Avatar = "upload/MovieSeries/Constellation/FilmMaker/Michelle_Maclaren.jpg",
					CreatedDate = now
				},

				// Harry Potter
				new AppMaker
				{
					Id = 16,
					FullName = "David Heyman",
					Avatar = "upload/MovieSeries/HarryPotter/FilmMaker/David_Heyman.jpg",
					CreatedDate = now
				},
				
				new AppMaker
				{
					Id = 17,
					FullName = "Chris Columbus",
					Avatar = "upload/MovieSeries/HarryPotter/FilmMaker/Chris_Columbus.jpeg",
					CreatedDate = now
				},

				// Hellbound Village
				new AppMaker
				{
					Id = 18,
					FullName = "Trần Hữu Tấn",
					Avatar = "upload/MovieSeries/HellboundVillage/FilmMaker/Tran_Huu_Tan.jpg",
					CreatedDate = now
				},

				// Lupin
				new AppMaker
				{
					Id = 19,
					FullName = "Louis Leterrier",
					Avatar = "upload/MovieSeries/Lupin/FilmMaker/Louis_Leterrier.jpg",
					CreatedDate = now
				},

				new AppMaker
				{
					Id = 20,
					FullName = "Marcela Said",
					Avatar = "upload/MovieSeries/Lupin/FilmMaker/Marcela_Said.jpg",
					CreatedDate = now
				},

				// Money Heist
				new AppMaker
				{
					Id = 21,
					FullName = "Jesus Colmenar",
					Avatar = "upload/MovieSeries/MoneyHeist/FilmMaker/Jesus_Colmenar.jpg",
					CreatedDate = now
				},

				// Parasyte The Grey
				new AppMaker
				{
					Id = 22,
					FullName = "Yeon Sang Ho",
					Avatar = "upload/MovieSeries/ParasyteTheGrey/FilmMaker/Yeon_Sang_Ho.jpg",
					CreatedDate = now
				},

				// Pyramid Game
				new AppMaker
				{
					Id = 23,
					FullName = "Park So Yoen",
					Avatar = "upload/MovieSeries/PyramidGame/FilmMaker/Park_So_Yeon.jpeg",
					CreatedDate = now
				},

				// Ripley
				new AppMaker
				{
					Id = 24,
					FullName = "Steven Zaillian",
					Avatar = "upload/MovieSeries/Ripley/FilmMaker/Steven_Zaillian.jpg",
					CreatedDate = now
				},

				// Ted
				new AppMaker
				{
					Id = 25,
					FullName = "Seth MacFarlane",
					Avatar = "upload/MovieSeries/Ted/FilmMaker/Seth_MacFarlane.jpg",
					CreatedDate = now
				},

				// The Signal
				new AppMaker
				{
					Id = 26,
					FullName = "Philipp Leinemann",
					Avatar = "upload/MovieSeries/TheSignal/FilmMaker/Philpp_Leinemann.jpg",
					CreatedDate = now
				},

				//todo Anime
				//!Single
				// Belle
				new AppMaker
				{
					Id = 27,
					FullName = "Hosoda Mamoru",
					Avatar = "upload/AnimeSingle/Belle/FilmMaker/Hosoda_Mamoru.jpg",
					CreatedDate = now
				},

				// Grave Of The Fireflies
				new AppMaker
				{
					Id = 28,
					FullName = "Takahata Isao",
					Avatar = "upload/AnimeSingle/GraveOfTheFireflies/FilmMaker/Takahata_Isao.jpg",
					CreatedDate = now
				},

				// Howls Moving Catsle
				// Kiki Delivery Service
				// My Neighbour Totoro
				// Ponyo
				new AppMaker
				{
					Id = 29,
					FullName = "Miyazaki Hayao",
					Avatar = "upload/AnimeSingle/HowlsMovingCatsle/FilmMaker/Miyazaki_Hayao.jpg",
					CreatedDate = now
				},

				// Josee The Tiger And The Fish
				new AppMaker
				{
					Id = 30,
					FullName = "Koutarou Tamura",
					Avatar = "upload/AnimeSingle/JoseeTheTigerAndTheFish/FilmMaker/Kotaro_Tamura.jpg",
					CreatedDate = now
				},

				// Stand By Me Doraemon
				new AppMaker
				{
					Id = 31,
					FullName = "Takashi Yamazaki",
					Avatar = "upload/AnimeSingle/StandByMeDoraemon/FilmMaker/Takashi_Yamazaki.jpg",
					CreatedDate = now
				},

				// Suzume Door Locking
				new AppMaker
				{
					Id = 32,
					FullName = "Shinkai Makoto",
					Avatar = "upload/AnimeSingle/SuzumeDoorLocking/FilmMaker/Makoto_Shinkai.jpg",
					CreatedDate = now
				},

				// Twilight
				new AppMaker
				{
					Id = 33,
					FullName = "Yutaka Yamamoto",
					Avatar = "upload/AnimeSingle/Twilight/FilmMaker/Yutaka_Yamamoto.jpg",
					CreatedDate = now
				},

				//!Series
				// A Sign Of Affection
				new AppMaker
				{
					Id = 34,
					FullName = "Murano Yuuta",
					Avatar = "upload/AnimeSeries/ASignOfAffection/FilmMaker/Murano_Yuuta.jpg",
					CreatedDate = now
				},

				// Chainsaw Man
				new AppMaker
				{
					Id = 35,
					FullName = "Nakayama Ryuu",
					Avatar = "upload/AnimeSeries/ChainsawMan/FilmMaker/Nakayama_Ryuu.jpg",
					CreatedDate = now
				},

				// Conan Detective
				new AppMaker
				{
					Id = 36,
					FullName = "Kodama Kenji",
					Avatar = "upload/AnimeSeries/ConanDetective/FilmMaker/Kodama_Kenji.jpg",
					CreatedDate = now
				},

				// Demon Slayer
				new AppMaker
				{
					Id = 37,
					FullName = "Kondou Hikaru",
					Avatar = "upload/AnimeSeries/DemonSlayer/FilmMaker/Kondou_Hikaru.jpg",
					CreatedDate = now
				},

				// Doraemon
				new AppMaker
				{
					Id = 38,
					FullName = "Kusuba Kouzou",
					Avatar = "upload/AnimeSeries/Doraemon/FilmMaker/Kusuba_KouZou.jpg",
					CreatedDate = now
				},

				// Drug Store Soliloquy
				new AppMaker
				{
					Id = 39,
					FullName = "Naganuma Norihiro",
					Avatar = "upload/AnimeSeries/DrugStoreSoliloquy/FilmMaker/Naganuma_Norihiro.jpg",
					CreatedDate = now
				},

				// One Piece
				new AppMaker
				{
					Id = 40,
					FullName = "Uda Kounosuke",
					Avatar = "upload/AnimeSeries/OnePiece/FilmMaker/Uda_Konosuke.jpg",
					CreatedDate = now
				},

				// Sorcery Fight
				new AppMaker
				{
					Id = 41,
					FullName = "Park Seong Hu",
					Avatar = "upload/AnimeSeries/SorceryFight/FilmMaker/Park_Seong_Hu.jpg",
					CreatedDate = now
				},

				// Tokyo Ghoul
				new AppMaker
				{
					Id = 42,
					FullName = "Morita Shuuhei",
					Avatar = "upload/AnimeSeries/TokyoGhoul/FilmMaker/Morita_Shuuhei.jpg",
					CreatedDate = now
				},

				// Your Lie In April
				new AppMaker
				{
					Id = 43,
					FullName = "Ishiguro Kyouhei",
					Avatar = "upload/AnimeSeries/YourLieInApril/FilmMaker/Ishiguro_Kyouhei.jpg",
					CreatedDate = now
				}
			);
		}
	}
}
