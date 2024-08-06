using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppGenresFilmSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppGenresFilm> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
			builder.HasData(

				//todo Movie
				//!Single
				// Blade Runner
				new AppGenresFilm
				{
					Id = 1,
					FilmId = 1,
					GenresId = 1,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 2,
					FilmId = 1,
					GenresId = 3,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 3,
					FilmId = 1,
					GenresId = 4,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 4,
					FilmId = 1,
					GenresId = 14,
					CreatedDate = now
				},

				// Dad, I'm Sorry
				new AppGenresFilm
				{
					Id = 5,
					FilmId = 2,
					GenresId = 1,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 6,
					FilmId = 2,
					GenresId = 5,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 7,
					FilmId = 2,
					GenresId = 7,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 8,
					FilmId = 2,
					GenresId = 15,
					CreatedDate = now
				},

				// Into The Wild
				new AppGenresFilm
				{
					Id = 9,
					FilmId = 3,
					GenresId = 1,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 10,
					FilmId = 3,
					GenresId = 3,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 11,
					FilmId = 3,
					GenresId = 4,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 12,
					FilmId = 3,
					GenresId = 7,
					CreatedDate = now
				},

				// IT
				new AppGenresFilm
				{
					Id = 13,
					FilmId = 4,
					GenresId = 1,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 14,
					FilmId = 4,
					GenresId = 7,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 15,
					FilmId = 4,
					GenresId = 10,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 16,
					FilmId = 4,
					GenresId = 17,
					CreatedDate = now
				},

				// My Best Summer
				new AppGenresFilm
				{
					Id = 17,
					FilmId = 5,
					GenresId = 1,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 18,
					FilmId = 5,
					GenresId = 7,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 19,
					FilmId = 5,
					GenresId = 13,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 20,
					FilmId = 5,
					GenresId = 16,
					CreatedDate = now
				},

				// Oblivion
				new AppGenresFilm
				{
					Id = 21,
					FilmId = 6,
					GenresId = 1,
					CreatedDate = now
				},
				new AppGenresFilm
				{
					Id = 22,
					FilmId = 6,
					GenresId = 3,
					CreatedDate = now
				},

				// Paddington
				new AppGenresFilm
				{
					Id = 23,
					FilmId = 7,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 24,
					FilmId = 7,
					GenresId = 5,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 25,
					FilmId = 7,
					GenresId = 8,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 26,
					FilmId = 7,
					GenresId = 14,
					CreatedDate = now
				},

				// Spaceman
				new AppGenresFilm
				{
					Id = 27,
					FilmId = 8,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 28,
					FilmId = 8,
					GenresId = 4,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 29,
					FilmId = 8,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 30,
					FilmId = 8,
					GenresId = 14,
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppGenresFilm
				{
					Id = 31,
					FilmId = 9,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 32,
					FilmId = 9,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 33,
					FilmId = 9,
					GenresId = 8,
					CreatedDate = now
				},

				// The Walk
				new AppGenresFilm
				{
					Id = 34,
					FilmId = 10,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 35,
					FilmId = 10,
					GenresId = 4,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 36,
					FilmId = 10,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 37,
					FilmId = 10,
					GenresId = 11,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 38,
					FilmId = 10,
					GenresId = 17,
					CreatedDate = now
				},

				//!Series
				// Constellation
				new AppGenresFilm
				{
					Id = 39,
					FilmId = 11,
					GenresId = 1,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 40,
					FilmId = 11,
					GenresId = 4,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 41,
					FilmId = 11,
					GenresId = 7,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 42,
					FilmId = 11,
					GenresId = 14,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 43,
					FilmId = 11,
					GenresId = 17,
					CreatedDate = now
				},
				
				// Harry Potter
				new AppGenresFilm
				{
					Id = 44,
					FilmId = 12,
					GenresId = 1,
					CreatedDate = now
				},
				
				new AppGenresFilm
				{
					Id = 45,
					FilmId = 12,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 46,
					FilmId = 12,
					GenresId = 14,
					CreatedDate = now
				},

				// Hellbound Village
				new AppGenresFilm
				{
					Id = 47,
					FilmId = 13,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 48,
					FilmId = 13,
					GenresId = 10,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 49,
					FilmId = 13,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 50,
					FilmId = 13,
					GenresId = 12,
					CreatedDate = now
				},

				// Lupin
				new AppGenresFilm
				{
					Id = 51,
					FilmId = 14,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 52,
					FilmId = 14,
					GenresId = 3,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 53,
					FilmId = 14,
					GenresId = 4,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 54,
					FilmId = 14,
					GenresId = 17,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 55,
					FilmId = 14,
					GenresId = 12,
					CreatedDate = now
				},

				// Money Heist
				new AppGenresFilm
				{
					Id = 56,
					FilmId = 15,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 57,
					FilmId = 15,
					GenresId = 3,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 58,
					FilmId = 15,
					GenresId = 17,
					CreatedDate = now
				},

				// Parasyte The Grey
				new AppGenresFilm
				{
					Id = 59,
					FilmId = 16,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 60,
					FilmId = 16,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 61,
					FilmId = 16,
					GenresId = 10,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 62,
					FilmId = 16,
					GenresId = 14,
					CreatedDate = now
				},

				// Pyramid Game
				new AppGenresFilm
				{
					Id = 63,
					FilmId = 17,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 64,
					FilmId = 17,
					GenresId = 7,
					CreatedDate = now
				},

				// Ripley
				new AppGenresFilm
				{
					Id = 65,
					FilmId = 18,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 66,
					FilmId = 18,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 67,
					FilmId = 18,
					GenresId = 12,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 68,
					FilmId = 18,
					GenresId = 17,
					CreatedDate = now
				},

				// Ted
				new AppGenresFilm
				{
					Id = 69,
					FilmId = 19,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 70,
					FilmId = 19,
					GenresId = 5,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 71,
					FilmId = 19,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 72,
					FilmId = 19,
					GenresId = 14,
					CreatedDate = now
				},

				// The Signal
				new AppGenresFilm
				{
					Id = 73,
					FilmId = 20,
					GenresId = 1,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 74,
					FilmId = 20,
					GenresId = 7,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 75,
					FilmId = 20,
					GenresId = 12,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 76,
					FilmId = 20,
					GenresId = 14,
					CreatedDate = now
				},

				//todo Anime
				//!Single
				// Belle
				new AppGenresFilm
				{
					Id = 77,
					FilmId = 21,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 78,
					FilmId = 21,
					GenresId = 20,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 79,
					FilmId = 21,
					GenresId = 25,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 80,
					FilmId = 21,
					GenresId = 26,
					CreatedDate = now
				},

				// Grave Of The Fireflies
				new AppGenresFilm
				{
					Id = 81,
					FilmId = 22,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 82,
					FilmId = 22,
					GenresId = 20,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 83,
					FilmId = 22,
					GenresId = 24,
					CreatedDate = now
				},

				// Howls Moving Catsle
				new AppGenresFilm
				{
					Id = 84,
					FilmId = 23,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 85,
					FilmId = 23,
					GenresId = 20,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 86,
					FilmId = 23,
					GenresId = 25,
					CreatedDate = now
				},

				// Josee The Tiger And The Fish
				new AppGenresFilm
				{
					Id = 87,
					FilmId = 24,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 88,
					FilmId = 24,
					GenresId = 19,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 89,
					FilmId = 24,
					GenresId = 20,
					CreatedDate = now
				},

				// Kiki Delivery Service
				new AppGenresFilm
				{
					Id = 90,
					FilmId = 25,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 91,
					FilmId = 25,
					GenresId = 20,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 92,
					FilmId = 25,
					GenresId = 23,
					CreatedDate = now
				},

				// My Neighbour Totoro
				new AppGenresFilm
				{
					Id = 93,
					FilmId = 26,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 94,
					FilmId = 26,
					GenresId = 23,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 95,
					FilmId = 26,
					GenresId = 25,
					CreatedDate = now
				},

				// Ponyo
				new AppGenresFilm
				{
					Id = 96,
					FilmId = 27,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 97,
					FilmId = 27,
					GenresId = 23,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 98,
					FilmId = 27,
					GenresId = 25,
					CreatedDate = now
				},

				// Stand By Me Doraemon
				new AppGenresFilm
				{
					Id = 99,
					FilmId = 28,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 100,
					FilmId = 28,
					GenresId = 23,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 101,
					FilmId = 28,
					GenresId = 25,
					CreatedDate = now
				},

				// Suzume Door Locking
				new AppGenresFilm
				{
					Id = 102,
					FilmId = 29,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 103,
					FilmId = 29,
					GenresId = 20,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 104,
					FilmId = 29,
					GenresId = 25,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 105,
					FilmId = 29,
					GenresId = 26,
					CreatedDate = now
				},

				// Twilight
				new AppGenresFilm
				{
					Id = 106,
					FilmId = 30,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 107,
					FilmId = 30,
					GenresId = 19,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 108,
					FilmId = 30,
					GenresId = 20,
					CreatedDate = now
				},

				//!Series
				// A Sign Of Affection
				new AppGenresFilm
				{
					Id = 109,
					FilmId = 31,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 110,
					FilmId = 31,
					GenresId = 20,
					CreatedDate = now
				},

				// Chainsaw Man
				new AppGenresFilm
				{
					Id = 111,
					FilmId = 32,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 112,
					FilmId = 32,
					GenresId = 21,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 113,
					FilmId = 32,
					GenresId = 25,
					CreatedDate = now
				},

				// Conan Detective
				new AppGenresFilm
				{
					Id = 114,
					FilmId = 33,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 115,
					FilmId = 33,
					GenresId = 23,
					CreatedDate = now
				},

				// Demon Slayer
				new AppGenresFilm
				{
					Id = 116,
					FilmId = 34,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 117,
					FilmId = 34,
					GenresId = 19,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 118,
					FilmId = 34,
					GenresId = 24,
					CreatedDate = now
				},

				// Doraemon
				new AppGenresFilm
				{
					Id = 119,
					FilmId = 35,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 120,
					FilmId = 35,
					GenresId = 23,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 121,
					FilmId = 35,
					GenresId = 25,
					CreatedDate = now
				},

				// Drug Store Soliloquy
				new AppGenresFilm
				{
					Id = 122,
					FilmId = 36,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 123,
					FilmId = 36,
					GenresId = 20,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 124,
					FilmId = 36,
					GenresId = 24,
					CreatedDate = now
				},

				// One Piece
				new AppGenresFilm
				{
					Id = 125,
					FilmId = 37,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 126,
					FilmId = 37,
					GenresId = 19,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 128,
					FilmId = 37,
					GenresId = 25,
					CreatedDate = now
				},

				// Sorcery Fight
				new AppGenresFilm
				{
					Id = 129,
					FilmId = 38,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 130,
					FilmId = 38,
					GenresId = 21,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 131,
					FilmId = 38,
					GenresId = 25,
					CreatedDate = now
				},

				// Tokyo Ghoul
				new AppGenresFilm
				{
					Id = 132,
					FilmId = 39,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 133,
					FilmId = 39,
					GenresId = 21,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 134,
					FilmId = 39,
					GenresId = 25,
					CreatedDate = now
				},

				// Your Lie In April
				new AppGenresFilm
				{
					Id = 135,
					FilmId = 40,
					GenresId = 2,
					CreatedDate = now
				},

				new AppGenresFilm
				{
					Id = 136,
					FilmId = 40,
					GenresId = 20,
					CreatedDate = now
				}
			);
		}
	}
}
