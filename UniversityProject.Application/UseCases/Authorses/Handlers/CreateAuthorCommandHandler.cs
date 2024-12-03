using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Authorses.Handlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommands, Author>
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public CreateAuthorCommandHandler(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Author> Handle(CreateAuthorCommands request, CancellationToken cancellationToken)
        {
            // Muallif ma'lumotlarini yaratish
            var data = new Author()
            {
                FullName = request.FullName,
                BirthDate = request.Year,
                BioWikipediya = request.BioWikipediya,
                CreatedAt = DateTime.UtcNow,
                DeletedAt = null,
                CountryId = request.CountryId
            };
            
            // Fayl mavjudligini tekshirish
            if (request.Picture != null)
            {
                // WebRootPath ni tekshirish
                if (string.IsNullOrEmpty(_env.WebRootPath))
                {
                    // wwwroot katalogi yo'q bo'lsa, uni yaratish
                    var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    if (!Directory.Exists(rootPath))
                    {
                        Directory.CreateDirectory(rootPath);
                    }
                    _env.WebRootPath = rootPath; // Yangi yaratilgan yo'lni o'rnatish
                }

                var files = request.Picture;
                var validExtensions = new[] { ".jpg", ".png", ".jpeg" };

                // Fayl turi va hajmini tekshirish
                if (!validExtensions.Contains(Path.GetExtension(files.FileName).ToLower()))
                {
                    throw new Exception("Noto'g'ri fayl turi. Faqat JPG, PNG va JPEG formatlariga ruxsat berilgan.");
                }

                if (files.Length > 5 * 1024 * 1024) // Maksimal hajm: 5 MB
                {
                    throw new Exception("Fayl hajmi 5 MB dan oshmasligi kerak.");
                }

                // Fayl yo'lini yaratish
                var path = Path.Combine(_env.WebRootPath, "AuthorImage");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Fayl nomini generatsiya qilish
                var fileName = $"{Guid.NewGuid()}-AuthorImage{Path.GetExtension(files.FileName)}";
                var filePath = Path.Combine(path, fileName);
                
                // Faylni saqlash
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }
                
                data.PictureUrl = fileName;
            }

            // Ma'lumotlar bazasiga saqlash
            await _context.Authors.AddAsync(data);
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
