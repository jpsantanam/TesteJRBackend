using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        private List<TarefaDTO> _tarefas;

        public Tarefas()
        {
            _tarefas = new List<TarefaDTO>
            {
                new TarefaDTO { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
                new TarefaDTO { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade Faculdade" },
                new TarefaDTO { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
            };
        }

        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return _tarefas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InserirTarefa(TarefaDTO Request)
        {
            try
            {
                _tarefas.Add(Request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarTarefa(int idTarefa)
        {
            var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == idTarefa); //Percorre a lista de tarefas e retorna a primeira ocorrência (se tiver) ou nulo
            
            if (tarefa is null) //Verifica se a tarefa foi encontrada
            {
                throw new TarefaNaoEncontrada($"Nenhuma tarefa encontrada com o id {idTarefa}."); //Lança uma exceção personalizada
            }

            _tarefas.Remove(tarefa); //Remove a tarefa encontrada
        }
    }
}
