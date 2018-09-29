using System;
using System.Collections.Generic;
using System.Text;
using $ext_safeprojectname$.Models.EF;
using XWidget.EFLogic;

namespace $safeprojectname$ {
    public class $ext_safeprojectname$Manager : LogicManagerBase<$ext_safeprojectname$Context> {
        public $ext_safeprojectname$Manager($ext_safeprojectname$Context dbcontext) : base(dbcontext) { }
    }
}
