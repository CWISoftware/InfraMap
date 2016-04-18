using InfraMap.Dominio.Mesa;
using InfraMap.Infraestrutura.Ef.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Autenticacao;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;
using InfraMap.Dominio.Sede;
using InfraMap.Dominio.Sede.Andar;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Web.MVC.Helpers
{
    public class Factory
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

        public static IModeloMaquinaRepositorio CriarModeloMaquinaRepositorio()
        {
            return new ModeloMaquinaRepositorio();
        }

        public static IMaquinaPessoalRepositorio CriarMaquinaPessoalRepositorio()
        {
            return new MaquinaPessoalRepositorio();
        }

        public static ServicoAutenticacao CriarServicoAutenticacao()
        {
            return new ServicoAutenticacao(CriarUsuarioRepositorio());
        }

        public static MesaService CriarMesaService()
        {
            return new MesaService(CriarMesaRepositorio(), CriarUsuarioRepositorio(),
                    CriarMaquinaRepositorio(), CriarRamalRepositorio(), CriarModeloMaquinaRepositorio(), CriarMaquinaPessoalRepositorio());
        }
    }
}
