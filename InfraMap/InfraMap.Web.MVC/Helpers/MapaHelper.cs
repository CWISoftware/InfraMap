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
            mesa.Colaborador_Id = usuarioRepositorio.BuscarPorNome(nome).Id;
            if (mesa.Colaborador_Id == 0)
            {
                throw new Exception("Colaborador não encontrado!");
            }

            mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarMaquina(int idMesa, string maquina, int tipoMaquina)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var maquinaRepositorio = FabricaDeModulos.CriarMaquinaRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            TipoMaquina tipo = (TipoMaquina) tipoMaquina;
            var novaMaquina = new Maquina()
            {
                Nome = maquina,
                Tipo = tipo.ToString()
            };

            maquinaRepositorio.Adicionar(novaMaquina);
            mesa.Maquina_Id = novaMaquina.Id;
            mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarRamal(int idMesa, string ramal, int tipoRamal)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var ramalRepositorio = FabricaDeModulos.CriarRamalRepositorio();
            TipoRamal tipo = (TipoRamal) tipoRamal;
            var entidade = new Ramal()
            {
                Numero = ramal,
                Tipo = tipo.ToString()
            };

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            ramalRepositorio.Adicionar(entidade);
            mesa.Ramal_Id = entidade.Id;
            mesaRepositorio.Atualizar(mesa);
        }
    }
}