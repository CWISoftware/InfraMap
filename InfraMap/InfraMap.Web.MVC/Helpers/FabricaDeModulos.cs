using InfraMap.Dominio.ModuloAndar;
using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloMesa;
using InfraMap.Dominio.ModuloRamal;
using InfraMap.Dominio.ModuloSede;
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

        public static IMesaRepositorio CriarMesaRepositorio()
        {
            return new MesaRepositorio();
        }

        public static IMaquinaRepositorio CriarMaquinaRepositorio()
        {
            return new MaquinaRepositorio();
        }

        public static IRamalRepositorio CriarRamalRepositorio()
        {
            return new RamalRepositorio();
        }

        public static IAndarRepositorio CriarAndarRepositorio()
        {
            return new AndarRepositorio();
        }

        public static ISedeRepositorio CriarSedeRepositorio()
        {
            return new SedeRepositorio();
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
