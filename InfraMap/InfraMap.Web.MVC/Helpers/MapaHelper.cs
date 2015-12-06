using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfraMap.Web.MVC.Models;
using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloRamal;

namespace InfraMap.Web.MVC.Helpers
{
    public class MapaHelper
    {
        public AndarModel BuscarAndarPorSede(string sede, string nomeAndar)
        {
            var sedeRepositorio = FabricaDeModulos.CriarSedeRepositorio();
            var andarRepositorio = FabricaDeModulos.CriarAndarRepositorio();
            var sedeDb = sedeRepositorio.BuscarSedePorNome(sede);
            var andar = sedeDb.Andares.FirstOrDefault(t => t.Descricao.Equals(nomeAndar));
            var model = new AndarModel()
            {
                Descricao = sede,
                Id = andar.Id
            };

            foreach (var mesa in andar.Mesas)
            {
                model.Mesas.Add(MesaModelHelper.EntidadeParaModel(mesa));
            }

            return model;
        }

        public void AdicionarColaborador(int id, string nome)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var usuarioRepositorio = FabricaDeModulos.CriarUsuarioRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(id);
            mesa.Colaborador = usuarioRepositorio.BuscarPorNome(nome);
            if (mesa.Colaborador == null)
            {
                throw new Exception("Colaborador não encontrado!");
            }

            mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarMaquina(int idMesa, string maquina, string tipoMaquina)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var maquinaRepositorio = FabricaDeModulos.CriarMaquinaRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            var novaMaquina = new Maquina()
            {
                Nome = maquina,
                Tipo = tipoMaquina
            };

            maquinaRepositorio.Adicionar(novaMaquina);
            mesa.Maquina = novaMaquina;
            mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarRamal(int idMesa, string ramal, string tipo)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var ramalRepositorio = FabricaDeModulos.CriarRamalRepositorio();

            var entidade = new Ramal()
            {
                Numero = ramal,
                Tipo = tipo
            };

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            ramalRepositorio.Adicionar(entidade);
            mesa.Ramal = entidade;
            mesaRepositorio.Atualizar(mesa);
        }
    }
}