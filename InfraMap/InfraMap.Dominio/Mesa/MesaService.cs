using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Dominio.Mesa
{
    public class MesaService
    {
        private IMesaRepositorio mesaRepositorio;
        private IUsuarioRepositorio usuarioRepositorio;
        private IMaquinaRepositorio maquinaRepositorio;
        private IRamalRepositorio ramalRepositorio;

        public MesaService(IMesaRepositorio mesaRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            this.mesaRepositorio = mesaRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public MesaService(IMesaRepositorio mesaRepositorio, IMaquinaRepositorio maquinaRepositorio)
        {
            this.mesaRepositorio = mesaRepositorio;
            this.maquinaRepositorio = maquinaRepositorio;
        }

        public MesaService(IMesaRepositorio mesaRepositorio, IRamalRepositorio ramalRepositorio)
        {
            this.mesaRepositorio = mesaRepositorio;
            this.ramalRepositorio = ramalRepositorio;
        }

        public void AdicionarColaborador(int id, string login)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(id);
            var colaborador = this.usuarioRepositorio.BuscarPorLogin(login);
            if (colaborador == null)
            {
                throw new Exception("Colaborador não encontrado!");
            }

            mesa.AdicionarColaborador(colaborador);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void RemoverColaborador(int idMesa)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            if (mesa.Colaborador == null)
            {
                throw new Exception("Esta mesa não tem colaborador!");
            }

            mesa.RemoverColaborador();
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarMaquina(int idMesa, string maquina, int tipoMaquina)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            var tipo = (TipoMaquina)tipoMaquina;
            var novaMaquina = new Maquina.Maquina()
            {
                Nome = maquina,
                Tipo = tipo.ToString()
            };

            this.maquinaRepositorio.Adicionar(novaMaquina);
            mesa.AdicionarMaquina(novaMaquina);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void RemoverMaquina(int idMesa)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            if (mesa.Maquina == null)
            {
                throw new Exception("Esta mesa não possui maquina!");
            }

            mesa.RemoverMaquina();
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarRamal(int idMesa, string ramal, int tipoRamal)
        {
            var tipo = (TipoRamal)tipoRamal;
            var entidade = new Ramal.Ramal
            {
                Numero = ramal,
                Tipo = tipo.ToString()
            };

            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            this.ramalRepositorio.Adicionar(entidade);
            mesa.AdicionarRamal(entidade);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void RemoverRamal(int idMesa)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            if (mesa.Ramal == null)
            {
                throw new Exception("Esta mesa não possui ramal!");
            }

            mesa.RemoverRamal();
            this.mesaRepositorio.Atualizar(mesa);
        }
    }
}
