using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppEpisodeSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppEpisode> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
            var dataEp = new AppEpisode[40 * 24]; // Create an array with 40 films, each having 24 episodes

            int idCounter = 1;

            for (var i = 0; i < 40; i++) // 40 films
            {
                for (var j = 1; j <= 24; j++) // 24 episodes per film
                {
                    var episode = new AppEpisode
                    {
                        Id = idCounter++,
                        EpNumber = j,
                        FilmId = i + 1,
                        Path = "",
                        CreatedDate = now
                    };

                    // Assign paths based on FilmId and EpNumber

                    //todo  Movie
                    //! Single
                    // Paddington
                    if (episode.FilmId == 7 && episode.EpNumber == 1)
                    {
                        episode.Path = "upload/MovieSingle/Paddington/Paddington_Movie480p.mp4";
                    }

                    // Series
                    // Hellbound Village
                    else if (episode.FilmId == 13 && episode.EpNumber == 1)
                    {
                        episode.Path = "upload/MovieSeries/HellboundVillage/Episode/Hellbound_Village_Episode01.mp4";
                    }

                    //todo Anime
                    //! Single
                    // Belle
                    else if (episode.FilmId == 21 && episode.EpNumber == 1)
                    {
                        episode.Path = "upload/AnimeSingle/Belle/Belle_Movie480p.mp4";
                    }

                    // Grave Of The Fireflies
                    else if (episode.FilmId == 22 && episode.EpNumber == 1)
                    {
                        episode.Path = "upload/AnimeSingle/GraveOfTheFireflies/Grave_Of_The_Fireflies_Movie480p.mp4";
                    }

                    // Howls Moving Catsle
                    else if (episode.FilmId == 23 && episode.EpNumber == 1)
                    {
                        episode.Path = "upload/AnimeSingle/HowlsMovingCatsle/Howls_Moving_Catsle_Movie480p.mp4";
                    }

                    // Suzume Door Locking
                    else if (episode.FilmId == 29 && episode.EpNumber == 1)
                    {
                        episode.Path = "upload/AnimeSingle/SuzumeDoorLocking/Suzume_Door_Locking_Movie480p.mp4";
                    }

                    //!Series
                    // A Sign Of Affection
                    else if (episode.FilmId == 31)
                    {
                        switch (episode.EpNumber)
                        {
                            case 1: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode01.mp4"; break;
                            case 2: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode02.mp4"; break;
                            case 3: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode03.mp4"; break;
                            case 4: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode04.mp4"; break;
                            case 5: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode05.mp4"; break;
                            case 6: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode06.mp4"; break;
                            case 7: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode07.mp4"; break;
                            case 8: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode08.mp4"; break;
                            case 9: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode09.mp4"; break;
                            case 10: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode10.mp4"; break;
                            case 11: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode11.mp4"; break;
                            case 12: episode.Path = "upload/AnimeSeries/ASignOfAffection/Episode/A_Sign_Of_Affection_Episode12.mp4"; break;
                        }
                    }

                    // Chainsaw Man
                    else if (episode.FilmId == 32 && episode.EpNumber == 1)
                    {
                        episode.Path = "upload/AnimeSeries/ChainsawMan/Episode/Chaisaw_Man_Episode01.mp4";
                    }

                    // Conan Detective
                    else if (episode.FilmId == 33)
                    {
                        if (episode.EpNumber == 1)
                        {
                            episode.Path = "upload/AnimeSeries/ConanDetective/Episode/Conan_Detective_Episode01.mp4";
                        }
                        else if (episode.EpNumber == 2)
                        {
                            episode.Path = "upload/AnimeSeries/ConanDetective/Episode/Conan_Detective_Episode02.mp4";
                        }
                    }

                    // Demon Slayer
                    else if (episode.FilmId == 34)
                    {
                        if (episode.EpNumber == 1)
                        {
                            episode.Path = "upload/AnimeSeries/DemonSlayer/Episode/Demon_Slayer_Episode01.mp4";
                        }
                        else if (episode.EpNumber == 2)
                        {
                            episode.Path = "upload/AnimeSeries/DemonSlayer/Episode/Demon_Slayer_Episode02.mp4";
                        }
                    }

                    // Doraemon
                    else if (episode.FilmId == 35)
                    {
                        if (episode.EpNumber == 1)
                        {
                            episode.Path = "upload/AnimeSeries/Doraemon/Episode/Doraemon_Episode01.mp4";
                        }
                        else if (episode.EpNumber == 2)
                        {
                            episode.Path = "upload/AnimeSeries/Doraemon/Episode/Doraemon_Episode02.mp4";
                        }
                    }

                    // Drug Store Soliloquy
                    else if (episode.FilmId == 36)
                    {
                        if (episode.EpNumber == 1)
                        {
                            episode.Path = "upload/AnimeSeries/DrugStoreSoliloquy/Episode/Drug_Stores_Soliloquy_Episode01.mp4";
                        }
                        else if (episode.EpNumber == 2)
                        {
                            episode.Path = "upload/AnimeSeries/DrugStoreSoliloquy/Episode/Drug_Stores_Soliloquy_Episode02.mp4";
                        }
                    }

                    // One Piece
                    else if (episode.FilmId == 37)
                    {
                        if (episode.EpNumber == 1)
                        {
                            episode.Path = "upload/AnimeSeries/OnePiece/Episode/One_Piece_Episode01.mp4";
                        }
                        else if (episode.EpNumber == 2)
                        {
                            episode.Path = "upload/AnimeSeries/OnePiece/Episode/One_Piece_Episode02.mp4";
                        }
                    }

                    // Sorcery Fight
                    else if (episode.FilmId == 38)
                    {
                        if (episode.EpNumber == 1)
                        {
                            episode.Path = "upload/AnimeSeries/SorceryFight/Episode/Sorcery_Fight_Episode01.mp4";
                        }
                        else if (episode.EpNumber == 2)
                        {
                            episode.Path = "upload/AnimeSeries/SorceryFight/Episode/Sorcery_Fight_Episode02.mp4";
                        }
                    }

                    // Tokyo Ghoul
                    else if (episode.FilmId == 39)
                    {
                        if (episode.EpNumber == 1)
                        {
                            episode.Path = "upload/AnimeSeries/TokyoGhoul/Episode/Tokyo_Ghoul_Episode01.mp4";
                        }
                        else if (episode.EpNumber == 2)
                        {
                            episode.Path = "upload/AnimeSeries/TokyoGhoul/Episode/Tokyo_Ghoul_Episode02.mp4";
                        }
                    }

                    // Your Lie In April
                    else if (episode.FilmId == 40 && episode.EpNumber == 1)
                    {
                            episode.Path = "upload/AnimeSeries/YourLieInApril/Episode/Your_Lie_In_April_Episode01.mp4";
                    }

                    dataEp[(i * 24) + (j - 1)] = episode; // Store the episode in the array
                }
            }

            builder.HasData(dataEp);

        }
	}
}
