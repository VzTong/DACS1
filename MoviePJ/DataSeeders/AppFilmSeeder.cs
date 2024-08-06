using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
	public static class AppFilmSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppFilm> builder)
		{
			var now = new DateTime(year: 2024, month: 04, day: 01);
			builder.HasData(
				
				//todo Movie
				//!Single
				// Blade Runner
				new AppFilm
				{
					Id = 1,
					Name = "Blade Runner",
					AnotherName = "Tội phạm nhân bản",
					Desc = "Blade Runner 2049 is a sequel to the 1982 sci-fi film. Three decades ago, the original film was the director's brainchild. Ridley Scott. Adapted from the novel Androids Dream of Electric Sheep? by Philip K. Dick., the classic plot tells the story of a police officer Rick Deckard (Harrison Ford) whose mission is to hunt down and destroy renegade cyborgs. Wanting to quit, Deckard was forced to return because of the popularity of the four people. These guys have hijacked a ship and are on their way back to Earth.",
					Slug = "blade-runner",
					Cover = "upload/MovieSingle/BladeRunner/Cover_BladeRunner.jpg",
					ReleaseYear = 2017,
					Time = 163,
					TrailerPath = "upload/MovieSingle/BladeRunner/Blade_Runner_2049Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 2,
					CreatedDate = now
				},

				// Dad, I'm Sorry
				new AppFilm
				{
					Id = 2,
					Name = "Dad, I'm Sorry",
					AnotherName = "Old Father, Bố Già",
					Desc = "Ba Sang makes daily sacrifices to support his dysfunctional family, which includes his siblings and his YouTuber son.",
					Slug = "dad-im-sorry",
					Cover = "upload/MovieSingle/DadImSorry/Cover_DadImSorry.jpeg",
					ReleaseYear = 2021,
					Time = 128,
					TrailerPath = "upload/MovieSingle/DadImSorry/DadImSorry_Trailer480p.mp4",
					Country = "Vietnam",
					Language = "Vietnamese",
					StatusId = 2,
					CreatedDate = now
				},

				// Into The Wild
				new AppFilm
				{
					Id = 3,
					Name = "Into The Wild",
					AnotherName = "Miền hoang dã",
					Desc = "After graduating from Emory University in 1992, former student and talented athlete Christopher decided to donate $24,000 in his savings account to charity and go to Alaska to live in harmony with nature. course.",
					Slug = "into-the-wild",
					Cover = "upload/MovieSingle/IntoTheWild/Cover_IntoTheWild.jpg",
					ReleaseYear = 2007,
					Time = 105,
					TrailerPath = "upload/MovieSingle/IntoTheWild/Into_the_Wild_2007_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 2,
					CreatedDate = now
				},

				// IT
				new AppFilm
				{
					Id = 4,
					Name = "IT",
					AnotherName = "Chú Hề Ma Quái",
					Desc = "Set in a fictional town in Derry, Maine, United States, where seven children are captured and forced to form a group called The Loser Club. These children are raised by a demon pretending to be a monkey named Pennywise.",
					Slug = "it",
					Cover = "upload/MovieSingle/IT/Cover_IT.jpeg",
					ReleaseYear = 2017,
					Time = 135,
					TrailerPath = "upload/MovieSingle/IT/IT_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 2,
					CreatedDate = now
				},

				// My Best Summer
				new AppFilm
				{
					Id = 5,
					Name = "My Best Summer",
					AnotherName = "With You",
					Desc = "The story of Canh Canh and Du Hoai, two high school students who reluctantly became friends because of their names, spending 3 years of high school together. In the movie Ha Lam Dau plays the female lead Canh Canh, a \"study student\", although her academic performance is not good but she always tries to strive. Ha Lam Dau with mushroom hair in a loose white and blue uniform and a lovely face, very suitable for the character's image. Makes viewers feel like they're being transported back to their own student days.",
					Slug = "my-best-summer",
					Cover = "upload/MovieSingle/MyBestSummer/Cover_MyBestSummer.jpg",
					ReleaseYear = 2019,
					Time = 110,
					TrailerPath = "upload/MovieSingle/MyBestSummer/My_Best_Summer_Trailer480p.mp4",
					Country = "China",
					Language = "Chinese",
					StatusId = 2,
					CreatedDate = now
				},

				// Oblivion
				new AppFilm
				{
					Id = 6,
					Name = "Oblivion",
					AnotherName = "Lãng quên",
					Desc = "A council sends a veteran soldier to a distant planet, where he comes to destroy the remains of an alien race. The appearance of an unexpected visitor causes him to question what he knows about the planet, his mission, and himself.",
					Slug = "olivion",
					Cover = "upload/MovieSingle/Oblivion/Cover_Oblivion.jpg",
					ReleaseYear = 2013,
					Time = 124,
					TrailerPath = "upload/MovieSingle/Oblivion/Oblivion_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 2,
					CreatedDate = now
				},

				// Paddington
				new AppFilm
				{
					Id = 7,
					Name = "Paddington",
					AnotherName = "Chú gấu Paddington",
					Desc = "Paddington tells the story of a bear cub with a great passion for England, who travels alone to London to find a home.",
					Slug = "paddington",
					Cover = "upload/MovieSingle/Paddington/Cover_Paddington.jpeg",
					ReleaseYear = 2014,
					Time = 95,
					TrailerPath = "upload/MovieSingle/Paddington/Paddington_Trailer480p.mp4",
					Country = "United Kingdom",
					Language = "English (UK)",
					StatusId = 2,
					CreatedDate = now
				},

				// Spaceman
				new AppFilm
				{
					Id = 8,
					Name = "Spaceman",
					AnotherName = "Phi hành gia",
					Desc = "Spaceman 2024 is an innovative American science fiction drama, directed by Johan Renck and written by Colby Day, based on the novel \"Spaceman of Bohemia\" by Jaroslav Kalfař. in 2017. The film brings together a cast including Adam Sandler, Carey Mulligan, Kunal Nayyar, Isabella Rossellini and Paul Dano. The story revolves around an astronaut sent on a mission to the Inner Solar System, where he faces a special creature that opens his eyes to life on Earth. Having spent half a year alone in space near the limits of the universe, the astronaut, portrayed by Sandler, must face difficulties and find ways to adapt when returning to Earth. During his journey, he discovers an ancient creature hidden deep on his ship, which becomes an important part of his life and experiences. Spaceman 2024 promises to bring deep emotions and reflections on the meaning of life and human presence in the vast universe.",
					Slug = "spaceman",
					Cover = "upload/MovieSingle/Spaceman/Cover_Spaceman.jpg",
					ReleaseYear = 2024,
					Time = 107,
					TrailerPath = "upload/MovieSingle/Spaceman/Spaceman_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 2,
					CreatedDate = now
				},

				// The Velveteen Rabbit
				new AppFilm
				{
					Id = 9,
					Name = "The Velveteen Rabbit",
					AnotherName = "Chú thỏ nhung",
					Desc = "Based on the classic book by Margery Williams, \"The Velveteen Rabbit\" celebrates the magic of unconditional love. When William receives a new favorite toy for Christmas, he discovers a lifelong friend and unlocks a world of magic.",
					Slug = "the-velveteen-rabbit",
					Cover = "upload/MovieSingle/TheVelveteenRabbit/Cover_TheVelveteenRabbit.jpg",
					ReleaseYear = 2023,
					Time = 44,
					TrailerPath = "upload/MovieSingle/TheVelveteenRabbit/The_Velveteen_Rabbit_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 2,
					CreatedDate = now
				},

				// The Walk
				new AppFilm
				{
					Id = 10,
					Name = "The Walk",
					AnotherName = "Bước đi thế kỷ",
					Desc = "The Walk - The Walk of the Century is a biographical film about the life of French tightrope artist Phillipe Petit, who always wanted to \"walk on the clouds\". The story of the film recreates his performance of walking on a wire across the Twin Towers in 1974, something no one had done before. To do this, he spent 6 years practicing and preparing, risking his life and overcoming legal obstacles. The Walk - The Walk of the Century was made by Robert Zemeckis, director of the Back To The Future trilogy.",
					Slug = "the-walk",
					Cover = "upload/MovieSingle/TheWalk/Cover_TheWalk.jpg",
					ReleaseYear = 2015,
					Time = 123,
					TrailerPath = "upload/MovieSingle/TheWalk/The_Walk_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 2,
					CreatedDate = now
				},

				//!Series
				// Constellation
				new AppFilm
				{
					Id = 11,
					Name = "Constellation",
					AnotherName = "Vũ Trụ Xa Lạ",
					Desc = "When a fatal accident occurs on the International Space Station, a lone astronaut makes a brave journey back to Earth only to discover important parts of her life including her daughter. little girl has changed.",
					Slug = "constellation",
					Cover = "upload/MovieSeries/Constellation/Cover_Constellation.jpg",
					ReleaseYear = 2024,
					Time = 50,
					EpisodeCount = 8,
					TrailerPath = "upload/MovieSeries/Constellation/Constellation_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 2,
					CreatedDate = now
				},

				// Harry Potter and the Philosopher's Stone
				new AppFilm
				{
					Id = 12,
					Name = "Harry Potter and the Philosopher's Stone",
					AnotherName = "Harry Potter và Hòn đá Phù thủy",
					Desc = "Harry Potter discovered he was a wizard and was invited to Hogwarts to study magic. This is a completely new world for him. He must learn to adapt and he quickly realizes that not all witches can be trusted.",
					Slug = "harry-potter",
					Cover = "upload/MovieSeries/HarryPotter/Cover_HarryPotter.jpg",
					ReleaseYear = 2001,
					Time = 150,
					EpisodeCount = 1,
					TrailerPath = "upload/MovieSeries/HarryPotter/Harry_Potter_Trailer480p.mp4",
					Country = "United Kingdom",
					Language = "English (UK)",
					StatusId = 2,
					CreatedDate = now
				},
				
				// Hellbound Village
				new AppFilm
				{
					Id = 13,
					Name = "Hellbound Village",
					AnotherName = "Tết Ở Làng Địa Ngục",
					Desc = "The content of the movie Tet In Hell Village revolves around horrifying haunting cases that occurred in Hell Village, where legend has it that the descendants of a once-famous bandit reside. After committing a series of heinous crimes, the robbers chose to hide incognito in a remote village, hidden among the rugged mountains.",
					Slug = "hellbound-village",
					Cover = "upload/MovieSeries/HellboundVillage/Cover_HellboundVillage.jpg",
					ReleaseYear = 2023,
					Time = 45,
					EpisodeCount = 12,
					TrailerPath = "upload/MovieSeries/HellboundVillage/Hellbound_Village_Trailer480p.mp4",
					Country = "Vietnam",
					Language = "Vietnamese",
					StatusId = 1,
					CreatedDate = now
				},

				// Lupin
				new AppFilm
				{
					Id = 14,
					Name = "Lupin",
					AnotherName = "Lupin",
					Desc = "Based on the adventures of Arsène Lupin, a legendary thief, the TV series \"Lupin\" brought a new story with the main character Assane Diop, a gentleman thief..",
					Slug = "lupin",
					Cover = "upload/MovieSeries/Lupin/Cover_Lupin.jpg",
					ReleaseYear = 2021,
					Time = 50,
					EpisodeCount = 5,
					TrailerPath = "upload/MovieSeries/Lupin/Lupin_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 1,
					CreatedDate = now
				},

				// Money Heist
				new AppFilm
				{
					Id = 15,
					Name = "Money Heist",
					AnotherName = "Phi Vụ Triệu Đô",
					Desc = "Eight robbers hold hostages in the Spanish Royal Mint while the mastermind manipulates the police to carry out his plan.",
					Slug = "money-heist",
					Cover = "upload/MovieSeries/MoneyHeist/Cover_MoneyHeist.jpg",
					ReleaseYear = 2017,
					Time = 50,
					EpisodeCount = 13,
					TrailerPath = "upload/MovieSeries/MoneyHeist/Money_Heist_Trailer480p.mp4",
					Country = "Spain",
					Language = "Spanish",
					StatusId = 1,
					CreatedDate = now
				},

				// Parasyte The Grey
				new AppFilm
				{
					Id = 16,
					Name = "Parasyte The Grey",
					AnotherName = "Ký Sinh Trùng",
					Desc = "When brutal, unknown parasites take over humans as hosts and gain control, humanity must rise up to fight this escalating threat.",
					Slug = "parasyte-the-grey",
					Cover = "upload/MovieSeries/ParasyteTheGrey/Cover_ParasyteTheGrey.jpg",
					ReleaseYear = 2024,
					Time = 60,
					EpisodeCount = 6,
					TrailerPath = "upload/MovieSeries/ParasyteTheGrey/Parasyte_The_Grey_Trailer480p.mp4",
					Country = "Korea",
					Language = "Korean",
					StatusId = 1,
					CreatedDate = now
				},

				// Pyramid Game
				new AppFilm
				{
					Id = 17,
					Name = "Pyramid Game",
					AnotherName = "Trò Chơi Kim Tự Tháp",
					Desc = "Every month, students at Baekyeon Girls' High School participate in a poll to determine their popularity. Result? This brutal ranking system dominates the entire social structure of the school. Sung Su Ji, a new transfer student, was rated 0 points. Starting from the lowest position, she became the target of school violence.",
					Slug = "pyramid-game",
					Cover = "upload/MovieSeries/PyramidGame/Cover_PyramidGame.jpg",
					ReleaseYear = 2024,
					Time = 60,
					EpisodeCount = 6,
					TrailerPath = "upload/MovieSeries/PyramidGame/Pyramid_Game_Trailer480p.mp4",
					Country = "Korea",
					Language = "Korean",
					StatusId = 1,
					CreatedDate = now
				},

				// Ripley
				new AppFilm
				{
					Id = 18,
					Name = "Ripley",
					AnotherName = "Ripley",
					Desc = "A grifter named Ripley living in New York during the 1960s is hired by a wealthy man to bring his vagabond son home from Italy.",
					Slug = "ripley",
					Cover = "upload/MovieSeries/Ripley/Cover_Ripley.jpg",
					ReleaseYear = 2024,
					Time = 50,
					EpisodeCount = 8,
					TrailerPath = "upload/MovieSeries/Ripley/Ripley_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 1,
					CreatedDate = now
				},

				// Ted
				new AppFilm
				{
					Id = 19,
					Name = "Ted",
					AnotherName = "Gấu Ted",
					Desc = "In 1993, the peak of Ted the Bear's famous popularity had passed, leaving him to live with his best friend, John Bennett, a 16-year-old boy who lived in a bunkhouse. Boston floor workers, along with their parents and cousins. Ted may not be the best influence for John, but when something important happens, he's willing to put himself in a difficult situation to help his friend and his family.",
					Slug = "ted",
					Cover = "upload/MovieSeries/Ted/Cover_Ted.jpg",
					ReleaseYear = 2012,
					Time = 106,
					EpisodeCount = 7,
					TrailerPath = "upload/MovieSeries/Ted/Ted_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 1,
					CreatedDate = now
				},

				// The Signal
				new AppFilm
				{
					Id = 20,
					Name = "The Signal",
					AnotherName = "Bí Mật Từ Không Gian",
					Desc = "When an astronaut mysteriously vanishes during a mission, her husband goes to investigate while navigating life as a single parent to their daughter.",
					Slug = "the-signal",
					Cover = "upload/MovieSeries/TheSignal/Cover_TheSignal.jpg",
					ReleaseYear = 2024,
					Time = 60,
					EpisodeCount = 4,
					TrailerPath = "upload/MovieSeries/TheSignal/The_Signal_Trailer480p.mp4",
					Country = "United States",
					Language = "English (US)",
					StatusId = 1,
					CreatedDate = now
				},

				//todo Anime
				//!Single
				// Belle
				new AppFilm
				{
					Id = 21,
					Name = "Belle",
					AnotherName = "Ryuusoba",
					Desc = "In the virtual world of U, a beloved singer becomes attached to the hated Dragon, leading to an adventure that begins to touch their real lives.",
					Slug = "belle",
					Cover = "upload/AnimeSingle/Belle/Cover_Belle.jpg",
					ReleaseYear = 2021,
					Time = 121,
					TrailerPath = "upload/AnimeSingle/Belle/Belle_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// Grave Of The Fireflies
				new AppFilm
				{
					Id = 22,
					Name = "Grave Of The Fireflies",
					AnotherName = "Hotaru No Haka",
					Desc = "Set in the final stages of World War 2 in Japan, the film tells the poignant but touching story of the brotherhood of two orphans Seita and his younger sister Setsuko.",
					Slug = "grave-of-the-fireflies",
					Cover = "upload/AnimeSingle/GraveOfTheFireflies/Cover_GraveOfTheFireflies.jpg",
					ReleaseYear = 1988,
					Time = 88,
					TrailerPath = "upload/AnimeSingle/GraveOfTheFireflies/Grave_Of_The_Fireflies_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// Howls Moving Catsle
				new AppFilm
				{
					Id = 23,
					Name = "Howls Moving Catsle",
					AnotherName = "Howl no Ugoku Shiro",
					Desc = "Sophie Hatter is a beautiful, average girl who has been left to maintain her family's hat shop. However, one day, she was cursed by a witch and turned into an old woman.",
					Slug = "howls-moving-catsle",
					Cover = "upload/AnimeSingle/HowlsMovingCatsle/Cover_HowlsMovingCatsle.jpg",
					ReleaseYear = 2004,
					Time = 117,
					TrailerPath = "upload/AnimeSingle/HowlsMovingCatsle/Howls_Moving_Catsle_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// Josee The Tiger And The Fish
				new AppFilm
				{
					Id = 24,
					Name = "Josee The Tiger And The Fish",
					AnotherName = "Josee to Tora to Sakana",
					Desc = "The story mainly revolves around Tsuneo and Josee's relationship. Tsuneo is a university student, and Josee is a young girl who rarely leaves the house because she cannot walk like a normal person. The two of them accidentally met when Tsuneo saw Josee's grandmother taking her for an early morning walk.",
					Slug = "josee-the-tiger-and-the-fish",
					Cover = "upload/AnimeSingle/JoseeTheTigerAndTheFish/Cover_JoseeTheTigerAndTheFish.jpg",
					ReleaseYear = 2020,
					Time = 100,
					TrailerPath = "upload/AnimeSingle/JoseeTheTigerAndTheFish/Josee_The_Tiger_And_The_Fish_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// Kiki Delivery Service
				new AppFilm
				{
					Id = 25,
					Name = "Kiki Delivery Service",
					AnotherName = "Majo no Takkyuubin",
					Desc = "The film begins at the moment when Kiki, a trainee witch, is old enough to leave her family and go to another place, where she must live alone for a year so she can become a real witch. Kiki sets off in the evening with everyone cheering her on, using her mother's broom, and carrying her cat Jiji and some essentials.",
					Slug = "kiki-delivery-service",
					Cover = "upload/AnimeSingle/KikiDeliveryService/Cover_KikiDeliveryService.jpg",
					ReleaseYear = 1989,
					Time = 103,
					TrailerPath = "upload/AnimeSingle/KikiDeliveryService/Kiki_Delivery_Service_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// My Neighbour Totoro			
				new AppFilm
				{
					Id = 26,
					Name = "My Neighbour Totoro",
					AnotherName = "Tonari no Totoro",
					Desc = "When two girls move to the country to be near their ailing mother, they have adventures with the wondrous forest spirits who live nearby.",
					Slug = "my-neighbour-totoro",
					Cover = "upload/AnimeSingle/MyNeighbourTotoro/Cover_MyNeighbourTotoro.jpg",
					ReleaseYear = 1988,
					Time = 86,
					TrailerPath = "upload/AnimeSingle/MyNeighbourTotoro/My_Neighbor_Totoro_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// Ponyo	
				new AppFilm
				{
					Id = 27,
					Name = "Ponyo",
					AnotherName = "Gake no Ue no Ponyo",
					Desc = "Five-year-old boy Sosuke befriends Ponyo - a goldfish princess who earnestly wants to become human.",
					Slug = "ponyo",
					Cover = "upload/AnimeSingle/Ponyo/Cover_Ponyo.jpg",
					ReleaseYear = 2008,
					Time = 100,
					TrailerPath = "upload/AnimeSingle/Ponyo/Ponyo_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// Stand By Me Doraemon
				new AppFilm
				{
					Id = 28,
					Name = "Stand By Me Doraemon",
					AnotherName = "Doraemon Đôi Bạn Thân",
					Desc = "After reminiscing about his late grandmother, Nobita Nobi wishes to see her again and asks Doraemon to take them to the past. After the two's healthy reunion, Nobita's grandmother confesses that she hopes to meet his future bride.",
					Slug = "stand-by-me-doraemon",
					Cover = "upload/AnimeSingle/StandByMeDoraemon/Cover_StandByMeDoraemon.jpg",
					ReleaseYear = 2020,
					Time = 95,
					TrailerPath = "upload/AnimeSingle/StandByMeDoraemon/Stand_By_Me_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// Suzume Door Locking
				new AppFilm
				{
					Id = 29,
					Name = "Suzume Door Locking",
					AnotherName = "Suzume no Tojimari",
					Desc = "Suzume, a 17 year old girl living in a quiet town in Kyushu, encounters a young man traveling who tells her \"I'm looking for a door\". She followed him and discovered a weathered door in the mountain ruins, as if it was the only thing left after the collapse.",
					Slug = "suzume-door-locking",
					Cover = "upload/AnimeSingle/SuzumeDoorLocking/Cover_SuzumeDoorLocking.jpg",
					ReleaseYear = 2023,
					Time = 122,
					TrailerPath = "upload/AnimeSingle/SuzumeDoorLocking/SuzumeDoorLocking_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				// Twilight
				new AppFilm
				{
					Id = 30,
					Name = "Twilight",
					AnotherName = "Hakubo",
					Desc = "Hakubo follows young people living in the \"now and present\" in Iwaki, Fukushima Prefecture after the March 11, 2011 Tohoku earthquake and tsunami.",
					Slug = "twilight",
					Cover = "upload/AnimeSingle/Twilight/Cover_Twilight.jpg",
					ReleaseYear = 2019,
					Time = 52,
					TrailerPath = "upload/AnimeSingle/Twilight/Twilight_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 2,
					CreatedDate = now
				},

				//!Series
				// A Sign Of Affection
				new AppFilm
				{
					Id = 31,
					Name = "A Sign Of Affection",
					AnotherName = "Yubisaki to Renren",
					Desc = "Yuki is a college student who has been deaf since childhood. She meets her friend who loves to travel, Itsuomi. The two of them communicate and develop feelings.",
					Slug = "asignofaffection",
					Cover = "upload/AnimeSeries/ASignOfAffection/Cover_ASignOfAffection.jpg",
					ReleaseYear = 2024,
					Time = 25,
					EpisodeCount = 12,
					TrailerPath = "upload/AnimeSeries/ASignOfAffection/A_Sign_Of_Affection_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// Chainsaw Man				
				new AppFilm
				{
					Id = 32,
					Name = "Chainsaw Man",
					AnotherName = "Thợ Săn Quỷ",
					Desc = "Following a betrayal, a young man left for dead is reborn as a powerful devil-human hybrid after merging with his pet devil and is soon enlisted into an organization dedicated to hunting devils.",
					Slug = "chainsaw-man",
					Cover = "upload/AnimeSeries/ChainsawMan/Cover_ChaisawMan.jpg",
					ReleaseYear = 2022,
					Time = 25,
					EpisodeCount = 12,
					TrailerPath = "upload/AnimeSeries/ChainsawMan/Chaisaw_Man_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// Conan Detective
				new AppFilm
				{
					Id = 33,
					Name = "Conan Detective",
					AnotherName = "Meitantei Conan",
					Desc = "At the beginning of the story, 17-year-old high school student Shinichi Kudo is transformed into a boy named Conan Edogawa. Shinichi in the first part of Detective Conan is described as an excellent school detective. During a trip to the \"Tropical\" park with his childhood friend Ran Mori, he accidentally witnessed a murder case, Kishida - a passenger in the game Express Train was brutally killed man.",
					Slug = "conan-detective",
					Cover = "upload/AnimeSeries/ConanDetective/Cover_Conan.jpg",
					ReleaseYear = 2022,
					Time = 30,
					EpisodeCount = 1120,
					TrailerPath = "upload/AnimeSeries/ConanDetective/Conan_Trailer.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// Demon Slayer
				new AppFilm
				{
					Id = 34,
					Name = "Demon Slayer",
					AnotherName = "Thanh Gươm Diệt Quỷ",
					Desc = "Tanjirou makes a living selling charcoal to support his family. One day, a demon murdered his entire family, leaving only his younger sister Nezuko, but she was turned into a demon. Determined to treat his sister, Tanjirou and Nezuko began their journey to find the whereabouts of the demon that attacked their family in order to break the curse.",
					Slug = "demon-slayer",
					Cover = "upload/AnimeSeries/DemonSlayer/Cover_DemonSlayer.jpg",
					ReleaseYear = 2019,
					Time = 25,
					EpisodeCount = 26,
					TrailerPath = "upload/AnimeSeries/DemonSlayer/Demon_Slayer_Trailer.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// Doraemon
				new AppFilm
				{
					Id = 35,
					Name = "Doraemon",
					AnotherName = "Mèo Máy Doraemon",
					Desc = "The stories in Doraemon often have a common formula, which revolves around the troubles that often happen to the fourth-grade boy Nobita, the second main character of the series. Doraemon has a magical bag in front of his stomach with all kinds of future treasures.",
					Slug = "doraemon",
					Cover = "upload/AnimeSeries/Doraemon/Cover_Doraemon.jpg",
					ReleaseYear = 2005,
					Time = 20,
					EpisodeCount = 810,
					TrailerPath = "upload/AnimeSeries/Doraemon/Doraemon_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// Drug Store Soliloquy
				new AppFilm
				{
					Id = 36,
					Name = "Drug Store Soliloquy",
					AnotherName = "The Apothecary Diaries",
					Desc = "Obsessed with poisons and pharmaceuticals, a servant in the Emperor's palace uses his experience as a medicine man in the red light district to solve mysterious hidden missions.",
					Slug = "drug-store-soliloquy",
					Cover = "upload/AnimeSeries/DrugStoreSoliloquy/Cover_DrugStoreSoliloquy.jpg",
					ReleaseYear = 2023,
					Time = 25,
					EpisodeCount = 24,
					TrailerPath = "upload/AnimeSeries/DrugStoreSoliloquy/Drug_Store_Soliloquy_Trailer.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// One Piece
				new AppFilm
				{
					Id = 37,
					Name = "One Piece",
					AnotherName = "Vua Hải Tặc",
					Desc = "Monkey D. Luffy and the Straw Hat pirates sailed through the Grand Line. He desires to find the One Piece treasure and become the new pirate king.",
					Slug = "one-piece",
					Cover = "upload/AnimeSeries/OnePiece/Cover_OnePiece.jpg",
					ReleaseYear = 1999,
					Time = 25,
					EpisodeCount = 1101,
					TrailerPath = "upload/AnimeSeries/OnePiece/One_Piece_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// Sorcery Fight
				new AppFilm
				{
					Id = 38,
					Name = "Sorcery Fight",
					AnotherName = "Jujutsu Kaisen",
					Desc = "A boy swallows a cursed talisman - the finger of a demon - and becomes cursed himself. He enters a shaman's school to be able to locate the demon's other body parts and thus exorcise himself.",
					Slug = "sorcery-fight",
					Cover = "upload/AnimeSeries/SorceryFight/Cover_SorceryFight.jpg",
					ReleaseYear = 2020,
					Time = 25,
					EpisodeCount = 24,
					TrailerPath = "upload/AnimeSeries/SorceryFight/Sorcery_Fight_Trailer.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// Tokyo Ghoul
				new AppFilm
				{
					Id = 39,
					Name = "Tokyo Ghoul",
					AnotherName = "Tokyo Kushu",
					Desc = "Tokyo Ghoul is a dark story about the city of Tokyo, where a series of cyber attacks occur caused by demons masquerading as humans.",
					Slug = "tokyo-ghoul",
					Cover = "upload/AnimeSeries/TokyoGhoul/Cover_TokyoGhol.jpg",
					ReleaseYear = 2014,
					Time = 25,
					EpisodeCount = 12,
					TrailerPath = "upload/AnimeSeries/TokyoGhoul/Tokyo_Ghoul_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				},

				// Your Lie In April
				new AppFilm
				{
					Id = 40,
					Name = "Your Lie In April",
					AnotherName = "Shigatsu wa Kimi no Uso",
					Desc = "The story is about Arima Kosei, a piano prodigy. But since the trauma caused by his mother's death, Kosei has been unable to hear any sounds.",
					Slug = "your-lie-in-april",
					Cover = "upload/AnimeSeries/YourLieInApril/Cover_YourLieInApril.jpg",
					ReleaseYear = 2014,
					Time = 25,
					EpisodeCount = 22,
					TrailerPath = "upload/AnimeSeries/YourLieInApril/Your_Lie_In_April_Trailer480p.mp4",
					Country = "Japan",
					Language = "Japanese",
					StatusId = 1,
					CreatedDate = now
				}
			);
		}
	}
}
