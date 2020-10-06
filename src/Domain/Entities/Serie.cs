using System;

namespace Domain.Entities
{
    public class Serie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Episodes { get; set; }
        public DateTime Release { get; set; }


        public Serie(string name, int episodes, DateTime release)
        {
            SetName(name);
            SetEpisodes(episodes);
            SetRelease(release);
        }

        public Serie(int id, string name, int episodes, DateTime release)
            : this(name, episodes, release)
        {
            SetId(id);
        }


        private void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "can't be less than zero.");

            Id = id;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Can't be null or whitespace.", nameof(name));

            Name = name;
        }

        public void SetEpisodes(int episodes)
        {
            if (episodes < 0)
                throw new ArgumentOutOfRangeException(nameof(episodes), "can't be less than zero.");

            Episodes = episodes;
        }

        // TODO - yes :/
        public void SetRelease(DateTime release)
        {
            Release = release;
        }

    }
}