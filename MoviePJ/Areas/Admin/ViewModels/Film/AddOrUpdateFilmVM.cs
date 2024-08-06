using MoviePJ.Entities;
using MoviePJ.Attributes;
using MoviePJ.Consts;
using MoviePJ.WebConfig.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MoviePJ.ViewModels.Film;

namespace MoviePJ.Areas.Admin.ViewModels.Film
{
    public class AddOrUpdateFilmVM
    {
        public AddOrUpdateFilmVM()
        {
            AppGenresFilms = new HashSet<AppGenresFilm>();
            AppFilmmakers = new HashSet<AppFilmmaker>();
            AppFilmActors = new HashSet<AppFilmActor>();
            AppStudioFilms = new HashSet<AppStudioFilm>();
            AppEpisodes = new HashSet<AppEpisode>();
        }

        public int? Id { get; set; }
        
        [AppRequired]
        [AppMaxLength(DB.AppFilm.NAME_LENGTH)]
        public string Name { get; set; }

        [AppMaxLength(DB.AppFilm.ANOTHERNAME_LENGTH)]
        public string? AnotherName { get; set; }

		public string? Desc { get; set; }

        public string? Slug { get; set; }
        
        public List<int>? GenreId { get; set; }  // id thể loại input

        public List<int>? MakerId { get; set; }  // id đạo diễn input

        public List<int>? ActorId { get; set; }  // id diễn viên input

        public List<int>? StudioId { get; set; }  // id studio input
        
        public string? Cover { get; set; }
        public IFormFile? CoverUpload { get; set; }
        public int ReleaseYear { get; set; }
        public int? Time { get; set; }
        public int? EpisodeCount { get; set; }
        public string? TrailerPath { get; set; }
        public IFormFile? TrailerPathFile { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }

		public IFormFile? PathEp1_Upload { get; set; }
		public IFormFile? PathEp2_Upload { get; set; }
		public IFormFile? PathEp3_Upload { get; set; }
		public IFormFile? PathEp4_Upload { get; set; }
		public IFormFile? PathEp5_Upload { get; set; }
		public IFormFile? PathEp6_Upload { get; set; }
		public IFormFile? PathEp7_Upload { get; set; }
		public IFormFile? PathEp8_Upload { get; set; }
		public IFormFile? PathEp9_Upload { get; set; }
		public IFormFile? PathEp10_Upload { get; set; }
		public IFormFile? PathEp11_Upload { get; set; }
		public IFormFile? PathEp12_Upload { get; set; }
		public IFormFile? PathEp13_Upload { get; set; }
		public IFormFile? PathEp14_Upload { get; set; }
		public IFormFile? PathEp15_Upload { get; set; }
		public IFormFile? PathEp16_Upload { get; set; }
		public IFormFile? PathEp17_Upload { get; set; }
		public IFormFile? PathEp18_Upload { get; set; }
		public IFormFile? PathEp19_Upload { get; set; }
		public IFormFile? PathEp20_Upload { get; set; }
		public IFormFile? PathEp21_Upload { get; set; }
		public IFormFile? PathEp22_Upload { get; set; }
		public IFormFile? PathEp23_Upload { get; set; }
		public IFormFile? PathEp24_Upload { get; set; }

		public int? StatusId { get; set; }
        public ICollection<AppGenresFilm> AppGenresFilms { get; set; }
        public ICollection<AppFilmmaker> AppFilmmakers { get; set; }
        public ICollection<AppFilmActor> AppFilmActors { get; set; }
        public ICollection<AppStudioFilm> AppStudioFilms { get; set; }
        public ICollection<AppEpisode> AppEpisodes { get; set; }

    }
}
