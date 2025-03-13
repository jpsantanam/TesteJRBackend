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

        public void DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                List<TarefaDTO> lstResponse = lstTarefas();
                var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                TarefaDTO Tarefa2 = lstResponse.Where(x => x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                lstResponse.Remove(Tarefa2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
