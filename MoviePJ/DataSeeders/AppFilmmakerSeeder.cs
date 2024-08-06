using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppFilmmakerSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppFilmmaker> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
			builder.HasData(

				//todo Movie
				//!Single
				// Blade Runner
				new AppFilmmaker
				{
					Id = 1,
					FilmId = 1,
					MakerId = 1,
					CreatedDate = now
				},

				// Dad, I'm Sorry
				new AppFilmmaker
				{
					Id = 2,
					FilmId = 2,
					MakerId = 2,
					CreatedDate = now
				},

				// Into The Wild
				new AppFilmmaker
				{
					Id = 3,
					FilmId = 3,
					MakerId = 3,
					CreatedDate = now
				},

				// IT
				new AppFilmmaker
				{
					Id = 4,
					FilmId = 4,
					MakerId = 4,
					CreatedDate = now
				},

				// My Best Summer
				new AppFilmmaker
				{
					Id = 5,
					FilmId = 5,
					MakerId = 5,
					CreatedDate = now
				},

				// Oblivion
				new AppFilmmaker
				{
					Id = 6,
					FilmId = 6,
					MakerId = 6,
					CreatedDate = now
				},
				
				new AppFilmmaker
				{
					Id = 7,
					FilmId = 6,
					MakerId = 7,
					CreatedDate = now
				},

				// Paddington
				new AppFilmmaker
				{
					Id = 8,
					FilmId = 7,
					MakerId = 8,
					CreatedDate = now
				},

				// Spaceman
				new AppFilmmaker
				{
					Id = 9,
					FilmId = 8,
					MakerId = 9,
					CreatedDate = now
				},
				
				new AppFilmmaker
				{
					Id = 10,
					FilmId = 8,
					MakerId = 10,
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppFilmmaker
				{
					Id = 11,
					FilmId = 9,
					MakerId = 11,
					CreatedDate = now
				},
				
				new AppFilmmaker
				{
					Id = 12,
					FilmId = 9,
					MakerId = 12,
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppFilmmaker
				{
					Id = 13,
					FilmId = 10,
					MakerId = 13,
					CreatedDate = now
				},
				
				new AppFilmmaker
				{
					Id = 14,
					FilmId = 10,
					MakerId = 14,
					CreatedDate = now
				},

				//!Series
				// Constellation
				new AppFilmmaker
				{
					Id = 15,
					FilmId = 11,
					MakerId = 15,
					CreatedDate = now
				},

				// Harry Potter
				new AppFilmmaker
				{
					Id = 16,
					FilmId = 12,
					MakerId = 16,
					CreatedDate = now
				},
				
				new AppFilmmaker
				{
					Id = 17,
					FilmId = 12,
					MakerId = 17,
					CreatedDate = now
				},

				// Hellbound Village
				new AppFilmmaker
				{
					Id = 18,
					FilmId = 13,
					MakerId = 18,
					CreatedDate = now
				},

				// Lupin
				new AppFilmmaker
				{
					Id = 19,
					FilmId = 14,
					MakerId = 19,
					CreatedDate = now
				},

				new AppFilmmaker
				{
					Id = 20,
					FilmId = 14,
					MakerId = 20,
					CreatedDate = now
				},

				// Money Heist
				new AppFilmmaker
				{
					Id = 21,
					FilmId = 15,
					MakerId = 21,
					CreatedDate = now
				},

				// Parasyte The Grey
				new AppFilmmaker
				{
					Id = 22,
					FilmId = 16,
					MakerId = 22,
					CreatedDate = now
				},

				// Pyramid Game
				new AppFilmmaker
				{
					Id = 23,
					FilmId = 17,
					MakerId = 23,
					CreatedDate = now
				},

				// Ripley
				new AppFilmmaker
				{
					Id = 24,
					FilmId = 18,
					MakerId = 24,
					CreatedDate = now
				},

				// Ted
				new AppFilmmaker
				{
					Id = 25,
					FilmId = 19,
					MakerId = 25,
					CreatedDate = now
				},

				// The Signal
				new AppFilmmaker
				{
					Id = 26,
					FilmId = 20,
					MakerId = 26,
					CreatedDate = now
				},

				//todo Anime
				//!Single
				// Belle
				new AppFilmmaker
				{
					Id = 27,
					FilmId = 21,
					MakerId = 27,
					CreatedDate = now
				},
				// Grave Of The Fireflies
				new AppFilmmaker
				{
					Id = 28,
					FilmId = 22,
					MakerId = 28,
					CreatedDate = now
				},

				// Howls Moving Catsle
				// Kiki Delivery Service
				// My Neighbour Totoro
				// Ponyo
				new AppFilmmaker
				{
					Id = 29,
					FilmId = 23,
					MakerId = 29,
					CreatedDate = now
				},
				new AppFilmmaker
				{
					Id = 30,
					FilmId = 25,
					MakerId = 29,
					CreatedDate = now
				},

				new AppFilmmaker
				{
					Id = 31,
					FilmId = 26,
					MakerId = 29,
					CreatedDate = now
				},

				new AppFilmmaker
				{
					Id = 32,
					FilmId = 27,
					MakerId = 29,
					CreatedDate = now
				},

				// Josee The Tiger And The Fish
				new AppFilmmaker
				{
					Id = 33,
					FilmId = 24,
					MakerId = 30,
					CreatedDate = now
				},

				// Stand By Me Doraemon
				new AppFilmmaker
				{
					Id = 34,
					FilmId = 28,
					MakerId = 31,
					CreatedDate = now
				},

				// Suzume Door Locking
				new AppFilmmaker
				{
					Id = 35,
					FilmId = 29,
					MakerId = 32,
					CreatedDate = now
				},

				// Twilight
				new AppFilmmaker
				{
					Id = 36,
					FilmId = 30,
					MakerId = 33,
					CreatedDate = now
				},

				//!Series
				// A Sign Of Affection
				new AppFilmmaker
				{
					Id = 37,
					FilmId = 31,
					MakerId = 34,
					CreatedDate = now
				},

				// Chainsaw Man
				new AppFilmmaker
				{
					Id = 38,
					FilmId = 32,
					MakerId = 35,
					CreatedDate = now
				},

				// Conan Detective
				new AppFilmmaker
				{
					Id = 39,
					FilmId = 33,
					MakerId = 36,
					CreatedDate = now
				},

				// Demon Slayer
				new AppFilmmaker
				{
					Id = 40,
					FilmId = 34,
					MakerId = 37,
					CreatedDate = now
				},

				// Doraemon
				new AppFilmmaker
				{
					Id = 41,
					FilmId = 35,
					MakerId = 38,
					CreatedDate = now
				},

				// Drug Store Soliloquy
				new AppFilmmaker
				{
					Id = 42,
					FilmId = 36,
					MakerId = 39,
					CreatedDate = now
				},

				// One Piece
				new AppFilmmaker
				{
					Id = 43,
					FilmId = 37,
					MakerId = 40,
					CreatedDate = now
				},

				// Sorcery Fight
				new AppFilmmaker
				{
					Id = 44,
					FilmId = 38,
					MakerId = 41,
					CreatedDate = now
				},

				// Tokyo Ghoul
				new AppFilmmaker
				{
					Id = 45,
					FilmId = 39,
					MakerId = 42,
					CreatedDate = now
				},

				// Your Lie In April
				new AppFilmmaker
				{
					Id = 46,
					FilmId = 40,
					MakerId = 43,
					CreatedDate = now
				}
			);
		}
	}
}
