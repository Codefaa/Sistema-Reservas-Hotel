using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLComponentes
    {
        public List<BEComposite> getRoles()
        {
            DALComposite DALcomposite = new DALComposite();
            return DALcomposite.getRoles();
        }
    }
}
