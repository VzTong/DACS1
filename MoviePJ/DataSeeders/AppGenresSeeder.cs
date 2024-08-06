using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;
using MoviePJ.Extensions;

namespace MoviePJ.DataSeeders
{
    public static class AppGenresSeeder
    {
        public static void SeedData(this EntityTypeBuilder<AppGenres> builder)
        {
            var now = new DateTime(year: 2024, month: 01, day: 01);
            // Tạo danh mục cấp 1, Id tăng từ 1 => Length
            var cateLevel1 = new AppGenres[] {
                new AppGenres{
                    Name = "Movie"
                },
                new AppGenres{
                    Name = "Anime"
                }
            };
            for (int i = 0; i < cateLevel1.Length; i++)
            {
                cateLevel1[i].Id = i + 1;
                cateLevel1[i].Slug = cateLevel1[i].Name.Slugify();
                cateLevel1[i].CateLevel = 1;
                cateLevel1[i].HasChild = true;
                cateLevel1[i].CreatedDate = now;
                cateLevel1[i].UpdatedDate = now;
                cateLevel1[i].DisplayOrder = i + 1;
            }
            builder.HasData(cateLevel1);

            // Tạo danh mục cấp 2
            var cateLevel2 = new AppGenres[] {

                // Movie
				new AppGenres{
					ParentCateId = 1,
					Name = "Action",
					Desc = "Films with high stakes and adrenaline, featuring fight scenes, chases, and explosions."
				},
                new AppGenres{
					ParentCateId = 1,
					Name = "Adventure",
					Desc = "The Adventure genre in literature revolves around thrilling and action-packed events."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Comedy",
					Desc = "Movies designed to elicit laughter with humorous situations and characters."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Crime",
					Desc = "Focuses on criminals, crimes, and the law enforcement that pursues them."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Drama",
					Desc = "Serious narratives exploring complex characters and emotional themes."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Fantasy",
					Desc = "Features magical and supernatural elements in a fictional universe."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Historical",
					Desc = "Recreates historical events or follows characters during a historical period."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Horror",
					Desc = "Intends to scare and create an atmosphere of fear and suspense."
				},
                new AppGenres{
					ParentCateId = 1,
					Name = "Melodrama",
					Desc = "Where events, plot, and characters are sensationalized to evoke strong emotions from the audience."
				},
                new AppGenres{
					ParentCateId = 1,
					Name = "Mystery",
					Desc = "Around a puzzling event, situation, or crime that needs to be solved."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Romance",
					Desc = "Centers on love stories and emotional relationships between characters."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Science Fiction",
					Desc = "Explores futuristic, technological, and otherworldly concepts."
				},
                new AppGenres{
					ParentCateId = 1,
					Name = "Slice Of Life",
					Desc = "Aims to portray realistic, often mundane experiences of everyday characters."
				},
                new AppGenres{
					ParentCateId = 1,
					Name = "School",
					Desc = "These narratives focus on the lives of students, teachers, and staff within school settings."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Thriller",
					Desc = "Builds tension and excitement with suspenseful and unexpected plot twists."
				},
				new AppGenres{
					ParentCateId = 1,
					Name = "Western",
					Desc = "Set in the American frontier, often featuring cowboys and outlaws."
				},

				// Anime
				new AppGenres{
                    ParentCateId = 2,
                    Name = "Shonen",
                    Desc = "Aimed at young teen boys, featuring action, adventure, and sports themes."
                },
                new AppGenres{
                    ParentCateId = 2,
                    Name = "Shojo",
                    Desc = "Targets young teen girls, often focusing on romance and relationships."
                },
                new AppGenres{
                    ParentCateId = 2,
                    Name = "Seinen",
                    Desc = "For adult men, with more complex stories and sometimes violent or sexual content."
                },
                new AppGenres{
                    ParentCateId = 2,
                    Name = "Josei",
                    Desc = "Similar to Seinen but for adult women, featuring deeper romantic tales."
                },
                new AppGenres{
                    ParentCateId = 2,
                    Name = "Kodomomuke",
                    Desc = "Anime for children, with educational and entertaining content."
                },
                new AppGenres{
                    ParentCateId = 2,
                    Name = "Historical",
                    Desc = "Recreates historical events or follows characters during a historical period."
                },
                new AppGenres{
                    ParentCateId = 2,
                    Name = "Mecha",
                    Desc = "Centers on robots and machinery, often combined with war and sci-fi elements."
                },
                new AppGenres{
                    ParentCateId = 2,
                    Name = "Isekai",
                    Desc = "Characters are transported to another world, often through reincarnation or Time travel."
                },

            };
            var nextId = cateLevel1.Length + 1;
            for (int i = 0; i < cateLevel2.Length; i++)
            {
                cateLevel2[i].Id = nextId + i;
                cateLevel2[i].Slug = cateLevel2[i].Name.Slugify();
                cateLevel2[i].CateLevel = 2;
                cateLevel2[i].CreatedDate = now;
                cateLevel2[i].UpdatedDate = now;
            }
            builder.HasData(cateLevel2);
        }
    }
}
