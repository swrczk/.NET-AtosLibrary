using System;
using System.Globalization;
using AtosLibrary.Application.Features.DeleteBookItem;
using AtosLibrary.Application.Features.EditBookItem;
using AtosLibrary.Application.Features.EditReader;
using AtosLibrary.Application.Features.RegistrationBook;
using AtosLibrary.Application.Features.RegistrationBookItem;
using AtosLibrary.Application.Features.RegistrationReader;
using AtosLibrary.Application.Features.RentBook;
using AtosLibrary.Application.Features.ReserveBook;
using AtosLibrary.Application.Features.ReserveBookNew;
using AtosLibrary.Application.Features.ReturnBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;
using AtosLibrary.Domain.BookItem;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Domain.Reservation;
using AtosLibrary.Infrastructure.SQLDataBase;
using AtosLibrary.Presentation.Book;
using AtosLibrary.Presentation.BookItem;
using AtosLibrary.Presentation.BookReservation;
using AtosLibrary.Presentation.Reader;
using AtosLibrary.Presentation.Reservation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AtosLibrary.WebHost
{
    using AtosLibrary.Application.Features.DeleteBook;
    using AtosLibrary.Application.Features.DeleteReader;
    using AtosLibrary.Application.Features.UpdateBook;
    using AtosLibrary.Application.Features.UpdateReader;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();


            services.AddScoped<ICommandHandler<RegistrationBookCommand>, RegistrationBookCommandHandler>();
            services.AddScoped<ICommandHandler<RegistrationReaderCommand>, RegistrationReaderCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteReaderCommand>, DeleteReaderCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateReaderCommand>, UpdateReaderCommandHandler>();
            services.AddScoped<ICommandHandler<EditReaderCommand>, EditReaderCommandHandler>();
            services.AddScoped<ICommandHandler<ReserveBookCommand>, ReserveBookCommandHandler>();
            services.AddScoped<ICommandHandler<EditBookCommand>, EditBookCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteBookCommand>, DeleteBookCommandHandler>();
            services.AddScoped<ICommandHandler<ReserveBookNewCommand>, ReserveBookNewCommandHandler>();
            services.AddScoped<ICommandHandler<RentBookCommand>, RentBookCommandHandler>();
            services.AddScoped<ICommandHandler<ReturnBookCommand>, ReturnBookCommandHandler>();

            services.AddScoped<ICommandHandler<RegistrationBookItemCommand>, RegistrationBookItemCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteBookItemCommand>, DeleteBookItemCommandHandler>();
            services.AddScoped<ICommandHandler<EditBookItemCommand>, EditBookItemCommandHandler>();

            services.AddScoped<IBookFactory, BookFactory>();
            services.AddScoped<IBookRepository, BookRepositoryDB>();

            services.AddScoped<IReaderFactory, ReaderFactory>();
            services.AddScoped<IReaderRepository, ReaderRepositoryDB>();

            services.AddScoped<IReservationFactory, ReservationFactory>();
            services.AddScoped<IReservationRepository, ReservationRepositoryDB>();

            services.AddScoped<IBookItemFactory, BookItemFactory>();
            services.AddScoped<IBookItemRepository, BookItemRepositoryDB>();

            services.AddDbContext<AtosLibraryContext>(option =>
                                                        option.UseSqlServer(Configuration
                                                            .GetConnectionString("AtosLibraryDatabase")));

            /* to uncomment change BookRepositoryDB, ReaderRepositoryDB, ReservationRepositoryDB to BookRepository, ReaderRepository, ReservationRepository
            services.AddSingleton<IInMemoryDb<BookEntity>, InMemoryBook>();
            services.AddSingleton<IInMemoryDb<ReaderEntity>, InMemoryReader>();
            services.AddSingleton<IInMemoryDb<ReservationEntity>, InMemoryReservation>();
            */

            services.AddScoped<IReaderPresentationRepository, ReaderPresentationRepository>();
            services.AddScoped<IBookPresentationRepository, BookPresentationRepository>(); 
            services.AddScoped<IReservationPresentationRepository, ReservationPresentationRepository>();
            services.AddScoped<IBookReservationPresentationRepository, BookReservationPresentationRepository>();
            services.AddScoped<IBookItemPresentationRepository, BookItemPresentationRepository>();
            
            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseStaticFiles(new StaticFileOptions {
                OnPrepareResponse = ctx =>
                {
                    // Cache static files for 30 days
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=2592000");
                    ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
