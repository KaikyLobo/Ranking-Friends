using RankingAmigos.Modelos;
using RankingAmigos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RankingAmigos.Servicos
{
    public class AmigoServico
    {
        private readonly AmigoRepositorio repositorio = new AmigoRepositorio();

        public List<Amigo> Listar()
        {
            return repositorio.Listar();
        }

        public void Adicionar(string nome, int posicao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new RegraNegocioException("Informe o nome do amigo.");

            if (posicao < 1)
                throw new RegraNegocioException("A posição deve ser maior que zero.");

            List<Amigo> amigos = repositorio.Listar();

            if (posicao > amigos.Count + 1)
                throw new RegraNegocioException("A posição não pode ser maior que " + (amigos.Count + 1) + ".");

            foreach (Amigo amigo in amigos)
            {
                if (amigo.Posicao >= posicao)
                {
                    amigo.Posicao++;
                }
            }

            Amigo novo = new Amigo
            {
                Nome = nome.Trim(),
                Posicao = posicao
            };

            repositorio.AdicionarComReordenacao(novo, amigos);
        }

        public void Atualizar(Amigo amigo)
        {
            if (string.IsNullOrWhiteSpace(amigo.Nome))
                throw new RegraNegocioException("Informe o nome do amigo.");

            if (amigo.Posicao < 1)
                throw new RegraNegocioException("A posição deve ser maior que zero.");

            List<Amigo> amigos = repositorio.Listar();

            Amigo antigo = amigos.FirstOrDefault(x => x.Id == amigo.Id);

            if (antigo == null)
                throw new RegraNegocioException("Amigo não encontrado.");

            if (amigo.Posicao > amigos.Count)
                throw new RegraNegocioException("A posição não pode ser maior que " + amigos.Count + ".");

            if (amigo.Posicao < antigo.Posicao)
            {
                foreach (Amigo item in amigos)
                {
                    if (item.Id != amigo.Id &&
                        item.Posicao >= amigo.Posicao &&
                        item.Posicao < antigo.Posicao)
                    {
                        item.Posicao++;
                    }
                }
            }
            else if (amigo.Posicao > antigo.Posicao)
            {
                foreach (Amigo item in amigos)
                {
                    if (item.Id != amigo.Id &&
                        item.Posicao <= amigo.Posicao &&
                        item.Posicao > antigo.Posicao)
                    {
                        item.Posicao--;
                    }
                }
            }

            Amigo amigoAtualizado = amigos.First(x => x.Id == amigo.Id);
            amigoAtualizado.Nome = amigo.Nome.Trim();
            amigoAtualizado.Posicao = amigo.Posicao;

            repositorio.AtualizarVarios(amigos);
        }

        public void Excluir(int id)
        {
            List<Amigo> amigos = repositorio.Listar();

            Amigo amigo = amigos.FirstOrDefault(x => x.Id == id);

            if (amigo == null)
                throw new RegraNegocioException("Amigo não encontrado.");

            List<Amigo> amigosAtualizados = amigos
                .Where(x => x.Id != id)
                .ToList();

            foreach (Amigo item in amigosAtualizados)
            {
                if (item.Posicao > amigo.Posicao)
                {
                    item.Posicao--;
                }
            }

            repositorio.ExcluirEAtualizar(id, amigosAtualizados);
        }
    }
}