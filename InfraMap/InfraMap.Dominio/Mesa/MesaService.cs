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
        private IModeloMaquinaRepositorio modeloMaquinaRepositorio;
        private IMaquinaPessoalRepositorio maquinaPessoalRepositorio;

        public MesaService(IMesaRepositorio mesaRepositorio, IUsuarioRepositorio usuarioRepositorio, IMaquinaRepositorio maquinaRepositorio, IRamalRepositorio ramalRepositorio, IModeloMaquinaRepositorio modeloMaquinaRepositorio, IMaquinaPessoalRepositorio maquinaPessoalRepositorio)
        {
            this.mesaRepositorio = mesaRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
            this.maquinaRepositorio = maquinaRepositorio;
            this.ramalRepositorio = ramalRepositorio;
            this.modeloMaquinaRepositorio = modeloMaquinaRepositorio;
            this.maquinaPessoalRepositorio = maquinaPessoalRepositorio;
        }

        public void AdicionarColaborador(int id, string login)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(id);
            var colaborador = this.usuarioRepositorio.BuscarPorLogin(login);
            if (colaborador == null)
            {
                throw new ArgumentException("Colaborador não encontrado!");
            }

            if (this.mesaRepositorio.BuscarMesaPorColaborador(colaborador.Login) != null)
            {
                throw new UsuarioEmOutraMesaException("Colaborador " + colaborador.Login + " já está em outra mesa!");
            }

            mesa.AdicionarColaborador(colaborador);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void TrocarColaborador(int id, string login)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(id);
            var mesaAtual = this.mesaRepositorio.BuscarMesaPorColaborador(login);
            if (mesaAtual != null)
            {
                mesa.AdicionarColaborador(mesaAtual.Colaborador);
                mesaAtual.RemoverColaborador();
                mesaRepositorio.Atualizar(mesa);
                mesaRepositorio.Atualizar(mesaAtual);
            }
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

        public void AdicionarMaquina(int idMesa, MaquinaPessoal maquinaPessoal)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            maquinaPessoal.Maquina.ModeloMaquina = this.modeloMaquinaRepositorio.BuscarPorId((int)maquinaPessoal.Maquina.ModeloMaquina_Id);

            var novaMaquinaPessoal = this.maquinaPessoalRepositorio.Adicionar(maquinaPessoal);
            this.maquinaRepositorio.Adicionar(maquinaPessoal.Maquina);
            mesa.AdicionarMaquina(novaMaquinaPessoal);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void RemoverMaquina(int idMesa)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            if (mesa.MaquinaPessoal == null)
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
