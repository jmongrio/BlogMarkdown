using BlogMarkDown.Models;
using BlogMarkDown.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace BlogMarkDown.Controllers
{
    public class BlogController : Controller
    {
        private readonly string postsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Posts");

        public IActionResult Index()
        {
            var files = Directory.GetFiles(postsFolder, "*.md");
            var posts = files.Select(MarkdownService.LoadPost)
                             .OrderByDescending(p => p.LastModified)
                             .ToList();
            return View(posts);
        }

        public IActionResult Post(string slug)
        {
            var filePath = Path.Combine(postsFolder, slug + ".md");
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var post = MarkdownService.LoadPost(filePath);
            return View(post);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPostInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Title) || string.IsNullOrWhiteSpace(input.MarkdownContent))
            {
                ModelState.AddModelError("", "El título y el contenido no pueden estar vacíos.");
                return View(input);
            }

            var slug = input.Title.ToLower().Replace(" ", "-");
            var filePath = Path.Combine(postsFolder, slug + ".md");

            System.IO.File.WriteAllText(filePath, input.MarkdownContent);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string slug)
        {
            var filePath = Path.Combine(postsFolder, slug + ".md");
            if (!System.IO.File.Exists(filePath)) return NotFound();

            var markdown = System.IO.File.ReadAllText(filePath);

            var input = new BlogPostInput
            {
                Title = slug.Replace("-", " "), // Para mostrarlo legible
                MarkdownContent = markdown
            };

            ViewBag.Slug = slug;
            return View(input);
        }

        [HttpPost]
        public IActionResult Edit(string slug, BlogPostInput input)
        {
            if (string.IsNullOrWhiteSpace(input.MarkdownContent))
            {
                ModelState.AddModelError("", "El contenido no puede estar vacío.");
                ViewBag.Slug = slug;
                return View(input);
            }

            var filePath = Path.Combine(postsFolder, slug + ".md");
            if (!System.IO.File.Exists(filePath)) return NotFound();

            System.IO.File.WriteAllText(filePath, input.MarkdownContent);

            return RedirectToAction("Post", new { slug });
        }

        [HttpGet]
        public IActionResult Media()
        {
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "posts");
            var imageFiles = Directory.GetFiles(imageFolder)
                .Select(Path.GetFileName)
                .ToList();

            ViewBag.Images = imageFiles;
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No se seleccionó ninguna imagen.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "posts");
            var extension = Path.GetExtension(image.FileName);
            var id = Guid.NewGuid().ToString("N");
            var fileName = $"{id}{extension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return RedirectToAction("Media");
        }

        public IActionResult Posts()
        {
            var postsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Posts");
            var postFiles = Directory.GetFiles(postsFolder, "*.md")
                .Select(Path.GetFileName)
                .ToList();

            ViewBag.Posts = postFiles;
            return View();
        }

        [HttpPost]
        public IActionResult DownloadSelected(List<string> selectedFiles)
        {
            if (selectedFiles == null || !selectedFiles.Any())
                return BadRequest("No se seleccionaron archivos.");

            var postsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Posts");
            var zipFileName = $"posts_{DateTime.Now:yyyyMMddHHmmss}.zip";
            var zipPath = Path.Combine(Path.GetTempPath(), zipFileName);

            using (var zip = new FileStream(zipPath, FileMode.Create))
            using (var archive = new System.IO.Compression.ZipArchive(zip, System.IO.Compression.ZipArchiveMode.Create))
            {
                foreach (var file in selectedFiles)
                {
                    var filePath = Path.Combine(postsFolder, file);
                    if (System.IO.File.Exists(filePath))
                    {
                        archive.CreateEntryFromFile(filePath, file);
                    }
                }
            }

            var zipBytes = System.IO.File.ReadAllBytes(zipPath);
            return File(zipBytes, "application/zip", zipFileName);
        }

        [HttpGet]
        public IActionResult DownloadSingle(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return BadRequest();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Posts", fileName);
            if (!System.IO.File.Exists(path)) return NotFound();

            var content = System.IO.File.ReadAllBytes(path);
            return File(content, "text/markdown", fileName);
        }

        [HttpPost]
        public IActionResult DeletePost(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return BadRequest();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Posts", fileName);
            if (!System.IO.File.Exists(path))
                return NotFound();

            System.IO.File.Delete(path);
            TempData["Message"] = $"Se eliminó el post: {fileName}";
            return RedirectToAction("Posts");
        }

        [HttpPost]
        public IActionResult DeleteImage(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                TempData["Message"] = "Nombre de imagen inválido.";
                return RedirectToAction("Media");
            }

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "posts", imageName);

            if (System.IO.File.Exists(imagePath))
            {
                try
                {
                    System.IO.File.Delete(imagePath);
                    TempData["Message"] = $"Imagen '{imageName}' eliminada correctamente.";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = $"Error al eliminar la imagen: {ex.Message}";
                }
            }
            else
            {
                TempData["Message"] = $"No se encontró la imagen '{imageName}'.";
            }

            return RedirectToAction("Media"); // O la vista que muestra la galería
        }
    }
}