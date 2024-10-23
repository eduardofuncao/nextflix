using NextFlix.Models;
using System.Collections.Generic;
using System.Linq;

namespace NextFlix.Services
{
    public class MediaService
    {
        private readonly List<Media> _mediaList;
        
        public MediaService()
        {
            _mediaList = new List<Media>(); // Inicializa a lista de mídia
        }

        // Método para retornar todas as mídias
        public List<Media> GetAllMedia()
        {
            return _mediaList;
        }

        // Retorna uma mídia por ID
        public Media GetMediaById(int id)
        {
            return _mediaList.FirstOrDefault(m => m.Id == id);
        }

        // Adiciona uma nova mídia à lista
        public void AddMedia(Media media)
        {
            media.Id = _mediaList.Count > 0 ? _mediaList.Max(m => m.Id) + 1 : 1; // Simulando auto-incremento de ID
            _mediaList.Add(media);
        }

        // Atualiza uma mídia existente
        public void UpdateMedia(Media media)
        {
            var existingMedia = GetMediaById(media.Id);
            if (existingMedia != null)
            {
                existingMedia.Title = media.Title;
                existingMedia.ReleaseDate = media.ReleaseDate;
                existingMedia.Director = media.Director;
                existingMedia.Genre = media.Genre;
                existingMedia.IsWatched = media.IsWatched;
                existingMedia.Rating = media.Rating;
                existingMedia.Review = media.Review;
                existingMedia.Type = media.Type;
            }
        }


        // Remove uma mídia por ID
        public void RemoveMedia(int id)
        {
            var media = GetMediaById(id);
            if (media != null)
            {
                _mediaList.Remove(media); // Remove o item da lista
            }
        }

    }
}
