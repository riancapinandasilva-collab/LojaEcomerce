using LojaEcomerce.Models;

namespace LojaEcomerce.interfaces
{
    public interface IUsuarioRepositorio
    {
        //A interface não contém có´digo apenas a promessa do que deve
        //ser feito ( como contrato)
        LoginViewModel Validar(string email, string senha);
    }
}
