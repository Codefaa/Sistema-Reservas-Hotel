using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLCliente
    {
        DALCliente dal = new DALCliente();
        public List<BECliente> LeerClientes()
        {
            return dal.LeerClientes();
        }
        public void AgregarCliente(BECliente unCliente)
        {
            dal.AgregarCliente(unCliente);
        }
        public void BajaCliente(BECliente unCliente)
        {
            dal.BajaCliente(unCliente);
        }
        public void ModificarCliente(BECliente unCliente)
        {
            dal.ModificarCliente(unCliente);
        }
        public List<BECliente> BuscarClienteSinReserva()
        {
            return dal.BuscarClienteSinReserva();
        }
        public List<BECliente> BuscarCliente(string nombreCliente)
        {
            return dal.BuscarCliente(nombreCliente);
        }
    }
}
