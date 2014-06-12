using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Models;

namespace Repositorio.Interfaces

{
    public interface IFactorRepository
    {
        Factor GetByID(int id);
    }
}