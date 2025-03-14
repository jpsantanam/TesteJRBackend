using apiToDo.Models;
using apiToDo.Repository;
using apiToDo.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using apiToDo.Models.Exceptions;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        
        private readonly TarefaRepository _tarefaRepository;

        public TarefasController(TarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public ActionResult LstTarefas()
        {
            try
            {
                return Ok(_tarefaRepository.LstTarefas());
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public ActionResult SelecionarTarefaPorId(Guid id)
        {
            try
            {
                return Ok(_tarefaRepository.SelecionarTarefaPorId(id));
            }
            catch (TarefaNaoEncontrada ex) //Verifica se a exceção lançada é do tipo personalizado TarefaNaoEncontrada
            {
                return NotFound(ex.Message); //Retorna a mensagem de erro com o código 404
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPost]
        public ActionResult InserirTarefas([FromBody] TarefaDto tarefaDto)
        {
            try
            {
                _tarefaRepository.InserirTarefa(tarefaDto);
                return Ok(_tarefaRepository.LstTarefas());

            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarTarefa(Guid id)
        {
            try
            {
                _tarefaRepository.DeletarTarefa(id);
                return Ok(_tarefaRepository.LstTarefas());
            }
            catch(TarefaNaoEncontrada ex) //Verifica se a exceção lançada é do tipo personalizado TarefaNaoEncontrada
            {
                return NotFound(ex.Message); //Retorna a mensagem de erro com o código 404
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPut]
        public ActionResult AtualizarTarefa([FromBody] Tarefa request)
        {
            try
            {
                _tarefaRepository.AtualizarTarefa(request);
                return Ok(_tarefaRepository.LstTarefas());
            }
            catch (TarefaNaoEncontrada ex) //Verifica se a exceção lançada é do tipo personalizado TarefaNaoEncontrada
            {
                return NotFound(ex.Message); //Retorna a mensagem de erro com o código 404
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
