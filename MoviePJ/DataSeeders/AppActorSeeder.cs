using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppActorSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppActor> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
			builder.HasData(

				//todo Movie
				//!Single
				// Blade Runner
				new AppActor
				{
					Id = 1,
					FullName = "Ryan Gosling",
					Avatar = "upload/MovieSingle/BladeRunner/Actor/Ryan_Gosling.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 2,
					FullName = "Harrison Ford",
					Avatar = "upload/MovieSingle/BladeRunner/Actor/Harrison_Ford.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 3,
					FullName = "Robin Wright",
					Avatar = "upload/MovieSingle/BladeRunner/Actor/Robin_Wright.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 4,
					FullName = "Sylvia Hoeks",
					Avatar = "upload/MovieSingle/BladeRunner/Actor/Sylvia_Hoeks.jpg",
					CreatedDate = now
				},

				// Dad, I'm Sorry
				new AppActor
				{
					Id = 5,
					FullName = "Lê Giang",
					Avatar = "upload/MovieSingle/DadImSorry/Actor/Le_Giang.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 6,
					FullName = "Trấn Thành",
					Avatar = "upload/MovieSingle/DadImSorry/Actor/Tran_Thanh.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 7,
					FullName = "Tuấn Trần",
					Avatar = "upload/MovieSingle/DadImSorry/Actor/Tuan_Tran.jpg",
					CreatedDate = now
				},

				// Into The Wild
				new AppActor
				{
					Id = 8,
					FullName = "Emile Hirsch",
					Avatar = "upload/MovieSingle/IntoTheWild/Actor/Emile_Hirsch.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 9,
					FullName = "Marcia Gay Harden",
					Avatar = "upload/MovieSingle/IntoTheWild/Actor/Marcia_Gay_Harden.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 10,
					FullName = "Vince Vaughn",
					Avatar = "upload/MovieSingle/IntoTheWild/Actor/Vince_Vaughn.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 11,
					FullName = "Kristen Stewart",
					Avatar = "upload/MovieSingle/IntoTheWild/Actor/Kristen_Stewart.jpg",
					CreatedDate = now
				},

				// IT
				new AppActor
				{
					Id = 12,
					FullName = "Jaeden Martell",
					Avatar = "upload/MovieSingle/IT/Actor/Jaeden_Martell.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 13,
					FullName = "Finn Wolfhard",
					Avatar = "upload/MovieSingle/IT/Actor/Finn_Wolfhard.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 14,
					FullName = "Bill Skarsgard",
					Avatar = "upload/MovieSingle/IT/Actor/Bill_Skarsgard.jpg",
					CreatedDate = now
				},

				// My Best Summer
				new AppActor
				{
					Id = 15,
					FullName = "Yu Huai",
					Avatar = "upload/MovieSingle/MyBestSummer/Actor/Yu_Huai.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 16,
					FullName = "He Lan Dou",
					Avatar = "upload/MovieSingle/MyBestSummer/Actor/He_Lan_Dou.jpg",
					CreatedDate = now
				},

				// Oblivion
				new AppActor
				{
					Id = 17,
					FullName = "Tom Cruise",
					Avatar = "upload/MovieSingle/Oblivion/Actor/Tom_Cruise.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 18,
					FullName = "Olga Kurylenko",
					Avatar = "upload/MovieSingle/Oblivion/Actor/Olga_Kurylenko.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 19,
					FullName = "Morgan Freeman",
					Avatar = "upload/MovieSingle/Oblivion/Actor/Morgan_Freeman.jpg",
					CreatedDate = now
				},

				// Paddington
				new AppActor
				{
					Id = 20,
					FullName = "Hugh Bonneville",
					Avatar = "upload/MovieSingle/Paddington/Actor/Hugh_Bonneville.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 21,
					FullName = "Sally Hawkins",
					Avatar = "upload/MovieSingle/Paddington/Actor/Sally_Hawkins.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 22,
					FullName = "Julie Walter",
					Avatar = "upload/MovieSingle/Paddington/Actor/Julie_Walters.jpg",
					CreatedDate = now
				},

				// Spaceman
				new AppActor
				{
					Id = 23,
					FullName = "Adam Sandler",
					Avatar = "upload/MovieSingle/Spaceman/Actor/Adam_Sandler.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 24,
					FullName = "Carey Mulligan",
					Avatar = "upload/MovieSingle/Spaceman/Actor/Carey_Mulligan.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 25,
					FullName = "Kunal Nayyar",
					Avatar = "upload/MovieSingle/Spaceman/Actor/Kunal_Nayyar.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 26,
					FullName = "Lena Olin",
					Avatar = "upload/MovieSingle/Spaceman/Actor/Lena_Olin.jpg",
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppActor
				{
					Id = 27,
					FullName = "Phoenix Laroche",
					Avatar = "upload/MovieSingle/TheVelveteenRabbit/Actor/Phoenix_Laroche.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 28,
					FullName = "Alex Lawther",
					Avatar = "upload/MovieSingle/TheVelveteenRabbit/Actor/Alex_Lawther.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 29,
					FullName = "Helena Bonham Carter",
					Avatar = "upload/MovieSingle/TheVelveteenRabbit/Actor/Helena_Bonham_Carter.jpg",
					CreatedDate = now
				},

				// The Walk
				new AppActor
				{
					Id = 30,
					FullName = "Joseph Gordon Levitt",
					Avatar = "upload/MovieSingle/TheWalk/Actor/Joseph_Gordon_Levitt.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 31,
					FullName = "Ben Kingsley",
					Avatar = "upload/MovieSingle/TheWalk/Actor/Ben_Kingsley.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 32,
					FullName = "Charlotte Le Bon",
					Avatar = "upload/MovieSingle/TheWalk/Actor/Charlotte_Le_Bon.jpg",
					CreatedDate = now
				},

				//!Series
				// Constellation
				new AppActor
				{
					Id = 33,
					FullName = "Noomi Rapace",
					Avatar = "upload/MovieSeries/Constellation/Actor/Noomi_Rapace.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 34,
					FullName = "Jonathan Banks",
					Avatar = "upload/MovieSeries/Constellation/Actor/Jonathan_Banks.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 35,
					FullName = "James Darcy",
					Avatar = "upload/MovieSeries/Constellation/Actor/James_Darcy.jpg",
					CreatedDate = now
				},

				// Harry Potter
				new AppActor
				{
					Id = 36,
					FullName = "Daniel Radcliffe",
					Avatar = "upload/MovieSeries/HarryPotter/Actor/Daniel_Radcliffe.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 37,
					FullName = "Rupert Grint",
					Avatar = "upload/MovieSeries/HarryPotter/Actor/Rupert_Grint.jpg",
					CreatedDate = now
				},
				
				new AppActor
				{
					Id = 38,
					FullName = "Emma Watson",
					Avatar = "upload/MovieSeries/HarryPotter/Actor/Emma_Watson.jpg",
					CreatedDate = now
				},

				// Hellbound Village
				new AppActor
				{
					Id = 39,
					FullName = "Quang Tuấn",
					Avatar = "upload/MovieSeries/HellboundVillage/Actor/Quang_Tuan.jpg",
					CreatedDate = now
				},
				new AppActor
				{
					Id = 40,
					FullName = "Võ Tuấn Phát",
					Avatar = "upload/MovieSeries/HellboundVillage/Actor/Vo_Tan_Phat.jpg",
					CreatedDate = now
				},
				new AppActor
				{
					Id = 41,
					FullName = "Nguyên Thảo",
					Avatar = "upload/MovieSeries/HellboundVillage/Actor/Nguyen_Thao.jpg",
					CreatedDate = now
				},

				// Lupin
				new AppActor
				{
					Id = 42,
					FullName = "Omar Sy",
					Avatar = "upload/MovieSeries/Lupin/Actor/Omar_Sy.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 43,
					FullName = "Ludivine Sagnier",
					Avatar = "upload/MovieSeries/Lupin/Actor/Ludivine_Sagnier.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 44,
					FullName = "Antoine Gouy",
					Avatar = "upload/MovieSeries/Lupin/Actor/Antoine_Gouy.jpg",
					CreatedDate = now
				},

				// Money Heist
				new AppActor
				{
					Id = 45,
					FullName = "Alvaro Marte",
					Avatar = "upload/MovieSeries/MoneyHeist/Actor/Alvaro_Marte.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 46,
					FullName = "Ursula Corbeo",
					Avatar = "upload/MovieSeries/MoneyHeist/Actor/Ursula_Corbero.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 47,
					FullName = "Pedro Alonso",
					Avatar = "upload/MovieSeries/MoneyHeist/Actor/Pedro_Alonso.jpg",
					CreatedDate = now
				},

				//ParasyteTheGrey
				new AppActor
				{
					Id = 48,
					FullName = "Jeon So Nee",
					Avatar = "upload/MovieSeries/ParasyteTheGrey/Actor/Jeon_So_Nee.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 49,
					FullName = "Koo Kyo Hwan",
					Avatar = "upload/MovieSeries/ParasyteTheGrey/Actor/Koo_Kyo_Hwan.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 50,
					FullName = "Kwon Hae Hyo",
					Avatar = "upload/MovieSeries/ParasyteTheGrey/Actor/Kwon_Hae_Hyo.jpg",
					CreatedDate = now
				},

				//Pyramid Game
				new AppActor
				{
					Id = 51,
					FullName = "Kim ji Yeon",
					Avatar = "upload/MovieSeries/PyramidGame/Actor/Kim_Ji_Yeon.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 52,
					FullName = "Jang Da Ah",
					Avatar = "upload/MovieSeries/PyramidGame/Actor/Jang_Da_Ah.jpeg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 53,
					FullName = "Ruy Da in",
					Avatar = "upload/MovieSeries/PyramidGame/Actor/Ruy_Da_In.jpg",
					CreatedDate = now
				},

				//Ripley
				new AppActor
				{
					Id = 54,
					FullName = "Andrew Scott",
					Avatar = "upload/MovieSeries/Ripley/Actor/Andrew_cott.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 55,
					FullName = "Johnny Flynn",
					Avatar = "upload/MovieSeries/Ripley/Actor/Johnny_Flynn.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 56,
					FullName = "Dakota Fanning",
					Avatar = "upload/MovieSeries/Ripley/Actor/Dakota_Fanning.jpg",
					CreatedDate = now
				},

				// Ted
				new AppActor
				{
					Id = 57,
					FullName = "Seth MacFarlane",
					Avatar = "upload/MovieSeries/Ted/Actor/Seth_MacFarlane.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 58,
					FullName = "Jessica Barth",
					Avatar = "upload/MovieSeries/Ted/Actor/Jessica_Barth.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 59,
					FullName = "Patrick Warburton",
					Avatar = "upload/MovieSeries/Ted/Actor/Patrick_Warburton.jpg",
					CreatedDate = now
				},

				// The Signal
				new AppActor
				{
					Id = 60,
					FullName = "Peri Baumeister",
					Avatar = "upload/MovieSeries/TheSignal/Actor/Peri_Baumeister.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 61,
					FullName = "Florian David Fitz",
					Avatar = "upload/MovieSeries/TheSignal/Actor/Florian_David_Fitz.jpg",
					CreatedDate = now
				},

				new AppActor
				{
					Id = 62,
					FullName = "Yuna Bennett",
					Avatar = "upload/MovieSeries/TheSignal/Actor/Yuna_Bennett.jpg",
					CreatedDate = now
				}

				);
		}
	}
}
