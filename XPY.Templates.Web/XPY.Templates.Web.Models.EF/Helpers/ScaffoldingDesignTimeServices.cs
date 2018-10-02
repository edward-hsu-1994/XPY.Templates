using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$.Helpers {
    /// <summary>
    /// DB First 設計階段服務
    /// </summary>
    public class ScaffoldingDesignTimeServices : IDesignTimeServices {
    public void ConfigureDesignTimeServices(IServiceCollection services) {
        var options = ReverseEngineerOptions.DbContextAndEntities;
        services.AddHandlebarsScaffolding(options);
    }
}
}
