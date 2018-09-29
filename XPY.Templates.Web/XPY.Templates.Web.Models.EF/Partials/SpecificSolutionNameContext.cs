using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$ {
    public partial class $ext_safeprojectname$Context : DbContext {
        public $ext_safeprojectname$Context() {
        }

        public $ext_safeprojectname$Context(DbContextOptions<$ext_safeprojectname$Context> options)
            : base(options) {
        }
    }
}
