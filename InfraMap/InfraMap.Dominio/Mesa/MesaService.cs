using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;
using InfraMap.Dominio.Usuario;
using InfraMap.Dominio.Autenticacao;

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

        public void AdicionarColaborador(int idMesa, string nomeColaborador)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            var colaborador = this.usuarioRepositorio.BuscarPorNome(nomeColaborador);
            if (colaborador == null)
            {
                throw new ArgumentException("Colaborador não encontrado!");
            }
            var mesaColaborador = this.mesaRepositorio.BuscarMesaPorColaborador(colaborador.Login);
            if (mesaColaborador != null)
            {
                throw new UsuarioEmOutraMesaException("Colaborador " + colaborador.Login + " já está em outra mesa!");
            }

            mesa.AdicionarColaborador(colaborador);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void TrocarColaborador(int idMesa, string nomeColaborador)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            var colaborador = this.usuarioRepositorio.BuscarPorNome(nomeColaborador);
            var mesaAtual = this.mesaRepositorio.BuscarMesaPorColaborador(colaborador.Login);
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

            int patrimonio = this.maquinaPessoalRepositorio.BuscarPorPatrimonio(maquinaPessoal);
            if (patrimonio > 0)
            {
                throw new MaquinaEmOutraMesaException("Este patrimônio já está sendo utlizado na Mesa " + patrimonio);
            }
            int etiqueta = this.maquinaPessoalRepositorio.BuscarPorEtiquetaServico(maquinaPessoal);
            if (etiqueta > 0)
            {
                throw new MaquinaEmOutraMesaException("Esta Service Tag já está sendo utlizada na Mesa " + etiqueta);
            }
            var novaMaquinaPessoal = this.maquinaPessoalRepositorio.Adicionar(maquinaPessoal);
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
            var maquinapessoal = mesa.MaquinaPessoal;
            var maquina = mesa.MaquinaPessoal.Maquina;


            mesa.RemoverMaquina();

            this.mesaRepositorio.Atualizar(mesa);

            this.maquinaPessoalRepositorio.Deletar(maquinapessoal);
            this.maquinaRepositorio.Deletar(maquina);
        }

        public void AdicionarRamal(int idMesa, string numeroRamal, int tipoRamal)
        {
            var tipo = (TipoRamal)tipoRamal;
            var ramal = new Ramal.Ramal
            {
                Numero = numeroRamal,
                Tipo = tipo
            };

            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            this.ramalRepositorio.Adicionar(ramal);
            mesa.AdicionarRamal(ramal);
            this.mesaRepositorio.Atualizar(mesa);
        }

        public void RemoverRamal(int idMesa)
        {
            var mesa = this.mesaRepositorio.BuscarPorId(idMesa);
            if (mesa.Ramal == null)
            {
                throw new Exception("Esta mesa não possui ramal!");
            }
            var ramal = mesa.Ramal;

            mesa.RemoverRamal();
            this.mesaRepositorio.Atualizar(mesa);

            this.ramalRepositorio.Deletar(ramal);
        }

        public void SalvarCorDosColaboradores(int[] listaIdColaborador, string gerenteLogin)
        {
            var gerente = this.usuarioRepositorio.BuscarPorLogin(gerenteLogin);
            if (gerente == null)
            {
                throw new ArgumentException("Gerente não encontrado!");
            }
            foreach (int idColaborador in listaIdColaborador)
            {
                var colaborador = this.usuarioRepositorio.BuscarPorId(idColaborador);
                if (colaborador != null)
                {
                    colaborador.Cor = gerente.Cor;
                    colaborador.GerenteId = gerente.Id;
                    this.usuarioRepositorio.Atualizar(colaborador);
                }
            }
        }
    }
}
