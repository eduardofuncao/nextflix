using Microsoft.AspNetCore.Mvc;
using NextFlix.Models;
using NextFlix.Services;

namespace NextFlix.Controllers
{
    public class MediaController : Controller
    {
        private readonly MediaService _mediaService;

        public MediaController(MediaService mediaService)
        {
            _mediaService = mediaService;
        }

        // Listagem de mídia (Substituindo Index por Lista)
        public IActionResult Lista()
        {
            var mediaList = _mediaService.GetAllMedia(); 
            return View("Lista", mediaList); // Agora chamamos a view Lista.cshtml
        }

        // GET: Criar nova mídia
        public IActionResult Create()
        {
            return View(new Media());
        }

        // POST: Criar nova mídia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,ReleaseDate,Director,Genre,IsWatched,Rating,Type,Review")] Media media)
        {
            if (ModelState.IsValid)
            {
                _mediaService.AddMedia(media); // Adiciona o filme
                return RedirectToAction(nameof(Lista)); // Redireciona para a listagem de mídias (Lista)
            }

            // Exibe os erros de validação no console
            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Exibe os erros no console do servidor
                }
            }

            return View(media); // Retorna à view de criação se o ModelState for inválido
        }

        // GET: Media/Edit/5
        public IActionResult Edit(int id)
        {
            var media = _mediaService.GetMediaById(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media); // Retorna a view com o filme existente
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Director,Genre,IsWatched,Rating,Review,Type")] Media media)
        {
            if (id != media.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _mediaService.UpdateMedia(media); // Atualiza o filme existente
                return RedirectToAction(nameof(Lista)); // Redireciona para a lista de filmes
            }

            // Exibir erros de validação, se houver
            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(media); // Retorna para a view de edição se o ModelState não for válido
        }

        // GET: Media/Delete/5
        public IActionResult Delete(int id)
        {
            var media = _mediaService.GetMediaById(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media); // Retorna a view de confirmação
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _mediaService.RemoveMedia(id); // Remove o filme pela ID
            return RedirectToAction(nameof(Lista)); // Redireciona para a lista após excluir
        }

        // GET: Media/Rate/5
        public IActionResult Rate(int id)
        {
            var media = _mediaService.GetMediaById(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media); // Carrega a view de avaliação
        }

        // POST: Media/Rate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rate(int id, [Bind("Id,IsWatched,Rating,Review")] Media media)
        {
            if (id != media.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _mediaService.UpdateMedia(media); // Atualiza a avaliação do filme/série
                return RedirectToAction(nameof(Lista)); // Redireciona para a página de listagem após avaliação
            }
            return View(media); // Se o ModelState não for válido, retorna à view de avaliação
        }

        // GET: Media/Details/5
        public IActionResult Details(int id)
        {
            var media = _mediaService.GetMediaById(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media); // Retorna a view com os detalhes do filme
        }
    }
}
