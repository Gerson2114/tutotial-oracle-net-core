using OracleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleApplication.Intefaces
{
    public interface IUsuario
    {
        List<usuario> usuarios();
    }
}
