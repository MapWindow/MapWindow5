using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Mvp
{
    public interface IPresenter<in TModel> where TModel : class
    {
        void Run(TModel model);
    }
}
