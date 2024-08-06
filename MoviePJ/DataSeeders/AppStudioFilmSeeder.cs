using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppStudioFilmSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppStudioFilm> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
			builder.HasData(

				//todo Movie
				//!Single
				// Blade Runner
				new AppStudioFilm
				{
					Id = 1,
					FilmId = 1,
					StudioId = 1,
					CreatedDate = now
				},

				// Dad, I'm Sorry
				new AppStudioFilm
				{
					Id = 2,
					FilmId = 2,
					StudioId = 2,
					CreatedDate = now
				},
				
				new AppStudioFilm
				{
					Id = 3,
					FilmId = 2,
					StudioId = 3,
					CreatedDate = now
				},

				// Into The Wild
				new AppStudioFilm
				{
					Id = 4,
					FilmId = 3,
					StudioId = 4,
					CreatedDate = now
				},

				// IT
				new AppStudioFilm
				{
					Id = 5,
					FilmId = 4,
					StudioId = 5,
					CreatedDate = now
				},
				
				new AppStudioFilm
				{
					Id = 6,
					FilmId = 4,
					StudioId = 6,
					CreatedDate = now
				},

				// My Best Summer
				new AppStudioFilm
				{
					Id = 7,
					FilmId = 5,
					StudioId = 7,
					CreatedDate = now
				},

				// Oblivion
				new AppStudioFilm
				{
					Id = 8,
					FilmId = 6,
					StudioId = 8,
					CreatedDate = now
				},
				
				new AppStudioFilm
				{
					Id = 9,
					FilmId = 6,
					StudioId = 9,
					CreatedDate = now
				},

				// Paddington
				new AppStudioFilm
				{
					Id = 10,
					FilmId = 7,
					StudioId = 10,
					CreatedDate = now
				},
				
				new AppStudioFilm
				{
					Id = 11,
					FilmId = 7,
					StudioId = 11,
					CreatedDate = now
				},

				// Spaceman
				new AppStudioFilm
				{
					Id = 12,
					FilmId = 8,
					StudioId = 12,
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppStudioFilm
				{
					Id = 13,
					FilmId = 9,
					StudioId = 13,
					CreatedDate = now
				},

				// The Walk
				new AppStudioFilm
				{
					Id = 14,
					FilmId = 10,
					StudioId = 14,
					CreatedDate = now
				},

				new AppStudioFilm
				{
					Id = 15,
					FilmId = 10,
					StudioId = 15,
					CreatedDate = now
				},

				//!Series
				// Constellation
				new AppStudioFilm
				{
					Id = 16,
					FilmId = 11,
					StudioId = 16,
					CreatedDate = now
				},
				
				new AppStudioFilm
				{
					Id = 17,
					FilmId = 11,
					StudioId = 17,
					CreatedDate = now
				},

				// Harry Potter
				new AppStudioFilm
				{
					Id = 18,
					FilmId = 12,
					StudioId = 18,
					CreatedDate = now
				},
				
				new AppStudioFilm
				{
					Id = 19,
					FilmId = 12,
					StudioId = 19,
					CreatedDate = now
				},

				// Hellbound Village
				new AppStudioFilm
				{
					Id = 20,
					FilmId = 13,
					StudioId = 20,
					CreatedDate = now
				},

				new AppStudioFilm
				{
					Id = 21,
					FilmId = 13,
					StudioId = 21,
					CreatedDate = now
				},

				// Lupin
				new AppStudioFilm
				{
					Id = 22,
					FilmId = 14,
					StudioId = 22,
					CreatedDate = now
				},

				// Money Heist
				new AppStudioFilm
				{
					Id = 23,
					FilmId = 15,
					StudioId = 23,
					CreatedDate = now
				},

				// Parasyte The Grey
				new AppStudioFilm
				{
					Id = 24,
					FilmId = 16,
					StudioId = 24,
					CreatedDate = now
				},

				// PyramidGame
				new AppStudioFilm
				{
					Id = 25,
					FilmId = 17,
					StudioId = 25,
					CreatedDate = now
				},

				// Ripley
				new AppStudioFilm
				{
					Id = 26,
					FilmId = 18,
					StudioId = 26,
					CreatedDate = now
				},

				new AppStudioFilm
				{
					Id = 27,
					FilmId = 18,
					StudioId = 27,
					CreatedDate = now
				},

				// Ted
				new AppStudioFilm
				{
					Id = 28,
					FilmId = 19,
					StudioId = 28,
					CreatedDate = now
				},

				new AppStudioFilm
				{
					Id = 29,
					FilmId = 19,
					StudioId = 29,
					CreatedDate = now
				},

				// The Signal
				new AppStudioFilm
				{
					Id = 30,
					FilmId = 20,
					StudioId = 30,
					CreatedDate = now
				},

				//todo Anime
				//!Single
				// Belle
				new AppStudioFilm
				{
					Id = 31,
					FilmId = 21,
					StudioId = 31,
					CreatedDate = now
				},

				// Grave Of The Fireflies
				// Howls Moving Catsle
				// Kiki Delivery Service
				// My Neighbour Totoro
				// Ponyo
				new AppStudioFilm
				{
					Id = 32,
					FilmId = 22,
					StudioId = 32,
					CreatedDate = now
				},

				new AppStudioFilm
				{
					Id = 33,
					FilmId = 25,
					StudioId = 32,
					CreatedDate = now
				},

				new AppStudioFilm
				{
					Id = 34,
					FilmId = 26,
					StudioId = 32,
					CreatedDate = now
				},

				new AppStudioFilm
				{
					Id = 35,
					FilmId = 27,
					StudioId = 32,
					CreatedDate = now
				},


				new AppStudioFilm
				{
					Id = 36,
					FilmId = 23,
					StudioId = 32,
					CreatedDate = now
				},

				// Josee The Tiger And The Fish
				new AppStudioFilm
				{
					Id = 37,
					FilmId = 24,
					StudioId = 33,
					CreatedDate = now
				},
				// Stand By Me Doraemon
				new AppStudioFilm
				{
					Id = 38,
					FilmId = 28,
					StudioId = 34,
					CreatedDate = now
				},

				// Suzume Door Locking
				new AppStudioFilm
				{
					Id = 39,
					FilmId = 29,
					StudioId = 35,
					CreatedDate = now
				},

				// Twilight
				new AppStudioFilm
				{
					Id = 40,
					FilmId = 30,
					StudioId = 36,
					CreatedDate = now
				},

				//!Series
				// A Sign Of Affection
				new AppStudioFilm
				{
					Id = 41,
					FilmId = 31,
					StudioId = 37,
					CreatedDate = now
				},

				// Chainsaw Man
				new AppStudioFilm
				{
					Id = 42,
					FilmId = 32,
					StudioId = 38,
					CreatedDate = now
				},

				// Conan Detective
				new AppStudioFilm
				{
					Id = 43,
					FilmId = 33,
					StudioId = 39,
					CreatedDate = now
				},

				// Demon Slayer
				new AppStudioFilm
				{
					Id = 44,
					FilmId = 34,
					StudioId = 40,
					CreatedDate = now
				},

				// Doraemon
				new AppStudioFilm
				{
					Id = 45,
					FilmId = 35,
					StudioId = 41,
					CreatedDate = now
				},

				// Drug Store Soliloquy
				new AppStudioFilm
				{
					Id = 46,
					FilmId = 36,
					StudioId = 42,
					CreatedDate = now
				},

				// One Piece
				new AppStudioFilm
				{
					Id = 47,
					FilmId = 37,
					StudioId = 43,
					CreatedDate = now
				},

				// Sorcery Fight
				new AppStudioFilm
				{
					Id = 48,
					FilmId = 38,
					StudioId = 44,
					CreatedDate = now
				},

				// Tokyo Ghoul
				new AppStudioFilm
				{
					Id = 49,
					FilmId = 39,
					StudioId = 45,
					CreatedDate = now
				},

				// Your Lie In April
				new AppStudioFilm
				{
					Id = 50,
					FilmId = 40,
					StudioId = 46,
					CreatedDate = now
				}
			);
		}
	}
}
