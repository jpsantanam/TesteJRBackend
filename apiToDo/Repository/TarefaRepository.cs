using apiToDo.DTO;
using apiToDo.Models;
using apiToDo.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Repository
{
    public class TarefaRepository
    {
        private readonly List<Tarefa> _tarefas;

        public TarefaRepository()
        {
            _tarefas = new List<Tarefa>
            {
                new() { IdTarefa = Guid.NewGuid(), DsTarefa = "Fazer Compras" },
                new() { IdTarefa = Guid.NewGuid(), DsTarefa = "Fazer Atividade Faculdade" },
                new() { IdTarefa = Guid.NewGuid(), DsTarefa = "Subir Projeto de Teste no GitHub" }
            };
        }

        public List<Tarefa> LstTarefas()
        {
            return _tarefas;
        }

        public Tarefa SelecionarTarefaPorId(Guid idTarefa)
        {
            var tarefa = _tarefas.FirstOrDefault(x => x.IdTarefa == idTarefa); //Busca a tarefa na lista de tarefas

            if (tarefa is null) //Verifica se a tarefa foi encontrada
            {
                throw new TarefaNaoEncontrada($"Nenhuma tarefa encontrada com o id {idTarefa}."); //Caso não tenha sido encontrada, lança a exceção personalizada TarefaNaoEncontrada
            }

            return tarefa; //Retorna a tarefa encontrada
        }


        public void InserirTarefa(TarefaDto tarefaDto)
        {
            Tarefa novaTarefa = new() { IdTarefa = Guid.NewGuid(), DsTarefa = tarefaDto.DsTarefa };

            _tarefas.Add(novaTarefa);

        }

        public void DeletarTarefa(Guid idTarefa)
        {
            var tarefa = SelecionarTarefaPorId(idTarefa); //Chama o método GetTarefaById para retornar a tarefa, caso ela exista
            _tarefas.Remove(tarefa); //Remove a tarefa da lista
        }

        public void AtualizarTarefa(Tarefa request)
        {
            var tarefa = SelecionarTarefaPorId(request.IdTarefa); //Chama o método GetTarefaById para retornar a tarefa, caso ela exista
            tarefa.DsTarefa = request.DsTarefa; //Atualiza a descrição da tarefa
        }
    }
}