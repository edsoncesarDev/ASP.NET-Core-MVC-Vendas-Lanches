using Lanches_Mac1.Areas.Admin.Servicos;
using Lanches_Mac1.Context;
using Lanches_Mac1.Models;
using Lanches_Mac1.Repository;
using Lanches_Mac1.Repository.Interfaces;
using Lanches_Mac1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace Lanches_Mac1
{
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
            //Serviço de comunicação ao banco de dados.
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Serviço Identity
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                //default password settings.
                options.Password.RequireDigit = false; //informe a senha
                options.Password.RequireLowercase = false; //informe um caractere minúsculo
                options.Password.RequireNonAlphanumeric = false; //informe um alfanumérico
                options.Password.RequireUppercase = false; //informe um caractere maiúsculo
                options.Password.RequiredLength = 6; //informe uma senha com o tamanho minímo de 6 caracteres
                options.Password.RequiredUniqueChars = 1; // 
            });

            services.Configure<ConfigurationImagens>(Configuration.GetSection("ConfigurationPastaImagens"));

            //Injeção de dependência
            //Ao solicitar uma instância referênciando a Interface (ILancheRepository), o container nativo da injeção de dependência
            //irá criar uma instância da classe (LancheRepository), e irá injetar os dados no construtor que estiver solicitando a instância do Repository (ILancheRepository).
            services.AddTransient<ILancheRepository, LancheRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<RelatorioVendasService>();
            services.AddScoped<GraficoVendasService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    politica => {
                        politica.RequireRole("Admin");
                    });

            });

            //Serviços de Configuração para o funcionamento de Session
            services.AddMemoryCache();
            services.AddSession();
                // Recuperando uma instância de HttpContextAcessor para obter informações sobre autenticação da requisição atual
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddControllersWithViews();
            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Cria os perfis
            seedUserRoleInitial.SeedRoles();

            //Cria os usuários e atribui ao perfil
            seedUserRoleInitial.SeedUsers();

            //Ativando Session
            app.UseSession();

            //Após incluir o serviço Idenity, adicionamos app.UseAuthentication();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               //Área Admin
                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "categoriaFiltro",
                    pattern: "Lanche/{action}/{categoria?}",
                    defaults: new { controller = "Lanche", action = "List", });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
