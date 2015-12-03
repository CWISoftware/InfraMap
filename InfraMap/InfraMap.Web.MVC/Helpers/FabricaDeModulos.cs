using InfraMap.Dominio.Repositorio;
using InfraMap.Dominio.Servicos;
using InfraMap.Infraestrutura.Ef.Repositorios;
using InfraMap.Infraestrutura.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Web.MVC.Helpers
{
    public class FabricaDeModulos
    {

        public static IUsuarioRepositorio CriarUsuarioRepositorio()
        {
            return new UsuarioRepositorio();
        }

        public static IServicoCriptografia CriarServicoCriptografia()
        {
            return new ServicoCriptografia();
        }

        public static ServicoAutenticacao CriarServicoAutenticacao()
        {
            return new ServicoAutenticacao(CriarUsuarioRepositorio(), CriarServicoCriptografia());
        }
    }
}
