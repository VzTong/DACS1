using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppStudioSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppStudio> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
			builder.HasData(

				//todo Movie
				//! Single
				// Blade Runner
				new AppStudio
				{
					Id = 1,
					Name = "Alcon Entertainment",
					Cover = "upload/MovieSingle/BladeRunner/Studio/Alcon_Entertainment.jpg",
					CreatedDate = now
				},

				// Dad, I'm Sorry
				new AppStudio
				{
					Id = 2,
					Name = "Tran Thanh Town",
					Cover = "upload/MovieSingle/DadImSorry/Studio/Tran_Thanh_Town.jpg",
					CreatedDate = now
				},
				
				new AppStudio
				{
					Id = 3,
					Name = "HK Film",
					Cover = "upload/MovieSingle/DadImSorry/Studio/HK_Film.jpg",
					CreatedDate = now
				},

				// Into The Wild
				new AppStudio
				{
					Id = 4,
					Name = "River Road Entertainment",
					Cover = "upload/MovieSingle/IntoTheWild/Studio/River_Road_Entertainment.jpg",
					CreatedDate = now
				},

				// IT
				new AppStudio
				{
					Id = 5,
					Name = "New Line Cinema",
					Cover = "upload/MovieSingle/IT/Studio/New_Line_Cinema.jpg",
					CreatedDate = now
				},

				new AppStudio
				{
					Id = 6,
					Name = "Vertigo Entertainment",
					Cover = "upload/MovieSingle/IT/Studio/Vertigo_Entertainment.jpg",
					CreatedDate = now
				},

				// My Best Summer
				new AppStudio
				{
					Id = 7,
					Name = "WeFun Entertainment",
					Cover = "upload/MovieSingle/MyBestSummer/Studio/WeFun_Entertainment.jpg",
					CreatedDate = now
				},

				// Oblivion
				new AppStudio
				{
					Id = 8,
					Name = "Relativity Media",
					Cover = "upload/MovieSingle/Oblivion/Studio/Relativity_Media.jpg",
					CreatedDate = now
				},
				
				new AppStudio
				{
					Id = 9,
					Name = "Chernin Entertainment",
					Cover = "upload/MovieSingle/Oblivion/Studio/Chernin_Entertainment.jpg",
					CreatedDate = now
				},

				// Paddington
				new AppStudio
				{
					Id = 10,
					Name = "Studio Canal",
					Cover = "upload/MovieSingle/Paddington/Studio/StudioCanal.jpg",
					CreatedDate = now
				},
				
				new AppStudio
				{
					Id = 11,
					Name = "Heyday Film",
					Cover = "upload/MovieSingle/Paddington/Studio/Heyday_Film.jpg",
					CreatedDate = now
				},

				// Spaceman
				new AppStudio
				{
					Id = 12,
					Name = "Tango Entertainment",
					Cover = "upload/MovieSingle/Spaceman/Studio/Tango_Entertainment.jpg",
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppStudio
				{
					Id = 13,
					Name = "Magic Light Pictures",
					Cover = "upload/MovieSingle/TheVelveteenRabbit/Studio/Magic_Light_Pictures.jpg",
					CreatedDate = now
				},

				// The Walk
				new AppStudio
				{
					Id = 14,
					Name = "Sony Pictures",
					Cover = "upload/MovieSingle/TheWalk/Studio/Sony_Pictures.jpg",
					CreatedDate = now
				},
				
				new AppStudio
				{
					Id = 15,
					Name = "TriStar Productions",
					Cover = "upload/MovieSingle/TheWalk/Studio/TriStar_Pictures.jpg",
					CreatedDate = now
				},

				//!Series
				// Constellation
				new AppStudio
				{
					Id = 16,
					Name = "MacLaren Entertainment",
					Cover = "upload/MovieSeries/Constellation/Studio/MacLaren Entertainment.jpg",
					CreatedDate = now
				},
				new AppStudio
				{
					Id = 17,
					Name = "Turbine Studios",
					Cover = "upload/MovieSeries/Constellation/Studio/Turbine_Studios.jpg",
					CreatedDate = now
				},

				// Harry Potter
				new AppStudio
				{
					Id = 18,
					Name = "Warner Bros Pictures",
					Cover = "upload/MovieSeries/HarryPotter/Studio/Warner_Bros_Pictures.jpg",
					CreatedDate = now
				},
				
				new AppStudio
				{
					Id = 19,
					Name = "Heyday Film",
					Cover = "upload/MovieSeries/HarryPotter/Studio/Heyday_Film.jpg",
					CreatedDate = now
				},

				// Hellbound Village
				new AppStudio
				{
					Id = 20,
					Name = "K Plus Entertainment",
					Cover = "upload/MovieSeries/HellboundVillage/Studio/K_Plus_Entertainment.jpg",
					CreatedDate = now
				},

				new AppStudio
				{
					Id = 21,
					Name = "Production Q",
					Cover = "upload/MovieSeries/HellboundVillage/Studio/ProductionQ_Studio.jpg",
					CreatedDate = now
				},

				// Lupin
				new AppStudio
				{
					Id = 22,
					Name = "Gaumont Film",
					Cover = "upload/MovieSeries/Lupin/Studio/Gaumont_Film.jpg",
					CreatedDate = now
				},

				// Money Heist
				new AppStudio
				{
					Id = 23,
					Name = "Atres Media",
					Cover = "upload/MovieSeries/MoneyHeist/Studio/Atres_Media.jpg",
					CreatedDate = now
				},

				// Parasyte The Grey
				new AppStudio
				{
					Id = 24,
					Name = "Climax Studios",
					Cover = "upload/MovieSeries/ParasyteTheGrey/Studio/Climax_Studios.jpg",
					CreatedDate = now
				},

				// Pyramid Game
				new AppStudio
				{
					Id = 25,
					Name = "Cj Enm Studios",
					Cover = "upload/MovieSeries/PyramidGame/Studio/Cj_Enm_Studios.jpg",
					CreatedDate = now
				},

				// Ripley
				new AppStudio
				{
					Id = 26,
					Name = "Entertainment 360",
					Cover = "upload/MovieSeries/Ripley/Studio/Entertainment_360.jpg",
					CreatedDate = now
				},

				new AppStudio
				{
					Id = 27,
					Name = "Endemol Shine North America",
					Cover = "upload/MovieSeries/Ripley/Studio/Endemol_Shine_North_America.jpg",
					CreatedDate = now
				},

				// Ted
				new AppStudio
				{
					Id = 28,
					Name = "Media Rights Capital",
					Cover = "upload/MovieSeries/Ted/Studio/Media_Rights_Capital.jpg",
					CreatedDate = now
				},

				new AppStudio
				{
					Id = 29,
					Name = "Bluegrass Films",
					Cover = "upload/MovieSeries/Ted/Studio/Bluegrass_Films.jpg",
					CreatedDate = now
				},

				// The Signal
				new AppStudio
				{
					Id = 30,
					Name = "Constantin Films",
					Cover = "upload/MovieSeries/TheSignal/Studio/Constantin_Film.jpg",
					CreatedDate = now
				},

				//todo Anime
				//!Single
				// Belle
				new AppStudio
				{
					Id = 31,
					Name = "Chizu Studio",
					Cover = "upload/AnimeSingle/Belle/Studio/Chizu_Studio.jpg",
					CreatedDate = now
				},

				// Grave Of The Fireflies
				// Howls Moving Catsle
				// Kiki Delivery Service
				// My Neighbour Totoro
				// Ponyo
				new AppStudio
				{
					Id = 32,
					Name = "Ghibli Studio",
					Cover = "upload/AnimeSingle/GraveOfTheFireflies/Studio/Ghibli_Studio.jpg",
					CreatedDate = now
				},

				// Josee The Tiger And The Fish
				new AppStudio
				{
					Id = 33,
					Name = "Bones Studio",
					Cover = "upload/AnimeSingle/JoseeTheTigerAndTheFish/Studio/Bones_Studio.jpg",
					CreatedDate = now
				},

				// Stand By Me Doraemon
				new AppStudio
				{
					Id = 34,
					Name = "Shin Ei Animation",
					Cover = "upload/AnimeSingle/StandByMeDoraemon/Studio/Shin_Ei_Animation.jpg",
					CreatedDate = now
				},

				// Suzume Door Locking
				new AppStudio
				{
					Id = 35,
					Name = "CoMix Wave Film",
					Cover = "upload/AnimeSingle/SuzumeDoorLocking/Studio/CoMix_Wave_Film.jpg",
					CreatedDate = now
				},

				// Twilight
				new AppStudio
				{
					Id = 36,
					Name = "Twilight Studio",
					Cover = "upload/AnimeSingle/Twilight/Studio/Twilight_Studio.jpg",
					CreatedDate = now
				},

				//!Series
				// A Sign Of Affection
				new AppStudio
				{
					Id = 37,
					Name = "Ajia Do Studio",
					Cover = "upload/AnimeSeries/ASignOfAffection/Studio/Ajiado_Studio.jpg",
					CreatedDate = now
				},

				// Chainsaw Man
				new AppStudio
				{
					Id = 38,
					Name = "Mappa Studio",
					Cover = "upload/AnimeSeries/ChainsawMan/Studio/Mappa_Studio.jpg",
					CreatedDate = now
				},

				// Conan Detective
				new AppStudio
				{
					Id = 39,
					Name = "TMS Entertainment",
					Cover = "upload/AnimeSeries/ConanDetective/Studio/TMS_Entertainment.jpg",
					CreatedDate = now
				},

				// Demon Slayer
				new AppStudio
				{
					Id = 40,
					Name = "Ufortable Studio",
					Cover = "upload/AnimeSeries/DemonSlayer/Studio/Ufotable_Studio.jpg",
					CreatedDate = now
				},

				// Doraemon
				new AppStudio
				{
					Id = 41,
					Name = "Pierrot Studio",
					Cover = "upload/AnimeSeries/Doraemon/Studio/Pierrot_Studio.jpg",
					CreatedDate = now
				},

				// Drug Store Soliloquy
				new AppStudio
				{
					Id = 42,
					Name = "Toho Animation Studio",
					Cover = "upload/AnimeSeries/DrugStoreSoliloquy/Studio/Toho_Animation_Studio.jpg",
					CreatedDate = now
				},

				// One Piece
				new AppStudio
				{
					Id = 43,
					Name = "Toei Animation",
					Cover = "upload/AnimeSeries/OnePiece/Studio/Toei_Animation.jpg",
					CreatedDate = now
				},

				// Sorcery Fight
				new AppStudio
				{
					Id = 44,
					Name = "Mappa Studio",
					Cover = "upload/AnimeSeries/SorceryFight/Studio/Mappa_Studio.jpg",
					CreatedDate = now
				},

				// Tokyo Ghoul
				new AppStudio
				{
					Id = 45,
					Name = "Pierrot Studio",
					Cover = "upload/AnimeSeries/TokyoGhoul/Studio/Pierrot_Studio.jpg",
					CreatedDate = now
				},

				// Your Lie In April
				new AppStudio
				{
					Id = 46,
					Name = "A1 Pictures",
					Cover = "upload/AnimeSeries/YourLieInApril/Studio/A1_Pictures.jpg",
					CreatedDate = now
				}
			);
		}
	}
}
