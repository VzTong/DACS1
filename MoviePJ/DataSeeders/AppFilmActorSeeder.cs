using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppFilmActorSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppFilmActor> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
			builder.HasData(

				//todo Movie
				//!Single
				// Blade Runner
				new AppFilmActor
				{
					Id = 1,
					AppFilmId = 1,
					AppActorId = 1,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 2,
					AppFilmId = 1,
					AppActorId = 2,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 3,
					AppFilmId = 1,
					AppActorId = 3,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 4,
					AppFilmId = 1,
					AppActorId = 4,
					CreatedDate = now
				},

				// Dad, I'm Sorry
				new AppFilmActor
				{
					Id = 5,
					AppFilmId = 2,
					AppActorId = 5,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 6,
					AppFilmId = 2,
					AppActorId = 6,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 7,
					AppFilmId = 2,
					AppActorId = 7,
					CreatedDate = now
				},

				// Into The Wild
				new AppFilmActor
				{
					Id = 8,
					AppFilmId = 3,
					AppActorId = 8,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 9,
					AppFilmId = 3,
					AppActorId = 9,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 10,
					AppFilmId = 3,
					AppActorId = 10,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 11,
					AppFilmId = 3,
					AppActorId = 11,
					CreatedDate = now
				},

				// IT
				new AppFilmActor
				{
					Id = 12,
					AppFilmId = 4,
					AppActorId = 12,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 13,
					AppFilmId = 4,
					AppActorId = 13,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 14,
					AppFilmId = 4,
					AppActorId = 14,
					CreatedDate = now
				},

				// My Best Summer
				new AppFilmActor
				{
					Id = 15,
					AppFilmId = 5,
					AppActorId = 15,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 16,
					AppFilmId = 5,
					AppActorId = 16,
					CreatedDate = now
				},

				// Oblivion
				new AppFilmActor
				{
					Id = 17,
					AppFilmId = 6,
					AppActorId = 17,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 18,
					AppFilmId = 6,
					AppActorId = 18,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 19,
					AppFilmId = 6,
					AppActorId = 19,
					CreatedDate = now
				},

				// Paddington
				new AppFilmActor
				{
					Id = 20,
					AppFilmId = 7,
					AppActorId = 20,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 21,
					AppFilmId = 7,
					AppActorId = 21,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 22,
					AppFilmId = 7,
					AppActorId = 22,
					CreatedDate = now
				},

				// Spaceman
				new AppFilmActor
				{
					Id = 23,
					AppFilmId = 8,
					AppActorId = 23,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 24,
					AppFilmId = 8,
					AppActorId = 24,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 25,
					AppFilmId = 8,
					AppActorId = 25,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 26,
					AppFilmId = 8,
					AppActorId = 26,
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppFilmActor
				{
					Id = 27,
					AppFilmId = 9,
					AppActorId = 27,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 28,
					AppFilmId = 9,
					AppActorId = 28,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 29,
					AppFilmId = 9,
					AppActorId = 29,
					CreatedDate = now
				},

				// The Walk
				new AppFilmActor
				{
					Id = 30,
					AppFilmId = 10,
					AppActorId = 30,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 31,
					AppFilmId = 10,
					AppActorId = 31,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 32,
					AppFilmId = 10,
					AppActorId = 32,
					CreatedDate = now
				},

				//!Series
				// Constellation
				new AppFilmActor
				{
					Id = 33,
					AppFilmId = 11,
					AppActorId = 33,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 34,
					AppFilmId = 11,
					AppActorId = 34,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 35,
					AppFilmId = 11,
					AppActorId = 35,
					CreatedDate = now
				},

				// Harry Potter
				new AppFilmActor
				{
					Id = 36,
					AppFilmId = 12,
					AppActorId = 36,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 37,
					AppFilmId = 12,
					AppActorId = 37,
					CreatedDate = now
				},
				
				new AppFilmActor
				{
					Id = 38,
					AppFilmId = 12,
					AppActorId = 38,
					CreatedDate = now
				},

				// Hellbound Village
				new AppFilmActor
				{
					Id = 39,
					AppFilmId = 13,
					AppActorId = 39,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 40,
					AppFilmId = 13,
					AppActorId = 40,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 41,
					AppFilmId = 13,
					AppActorId = 41,
					CreatedDate = now
				},

				// Lupin
				new AppFilmActor
				{
					Id = 42,
					AppFilmId = 14,
					AppActorId = 42,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 43,
					AppFilmId = 14,
					AppActorId = 43,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 44,
					AppFilmId = 14,
					AppActorId = 44,
					CreatedDate = now
				},

				// Money Heist
				new AppFilmActor
				{
					Id = 45,
					AppFilmId = 15,
					AppActorId = 45,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 46,
					AppFilmId = 15,
					AppActorId = 46,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 47,
					AppFilmId = 15,
					AppActorId = 47,
					CreatedDate = now
				},

				// Parasyte The Grey
				new AppFilmActor
				{
					Id = 48,
					AppFilmId = 16,
					AppActorId = 48,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 49,
					AppFilmId = 16,
					AppActorId = 49,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 50,
					AppFilmId = 16,
					AppActorId = 50,
					CreatedDate = now
				},

				//PyramidGame
				new AppFilmActor
				{
					Id = 51,
					AppFilmId = 17,
					AppActorId = 51,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 52,
					AppFilmId = 17,
					AppActorId = 52,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 53,
					AppFilmId = 17,
					AppActorId = 53,
					CreatedDate = now
				},

				//Ripley
				new AppFilmActor
				{
					Id = 54,
					AppFilmId = 18,
					AppActorId = 54,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 55,
					AppFilmId = 18,
					AppActorId = 55,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 56,
					AppFilmId = 18,
					AppActorId = 56,
					CreatedDate = now
				},

				// Ted
				new AppFilmActor
				{
					Id = 57,
					AppFilmId = 19,
					AppActorId = 57,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 58,
					AppFilmId = 19,
					AppActorId = 58,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 59,
					AppFilmId = 19,
					AppActorId = 59,
					CreatedDate = now
				},

				// The Signal
				new AppFilmActor
				{
					Id = 60,
					AppFilmId = 20,
					AppActorId = 60,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 61,
					AppFilmId = 20,
					AppActorId = 61,
					CreatedDate = now
				},

				new AppFilmActor
				{
					Id = 62,
					AppFilmId = 20,
					AppActorId = 62,
					CreatedDate = now
				}

			);
		}
	}
}
