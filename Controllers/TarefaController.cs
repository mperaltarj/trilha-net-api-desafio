using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoDesafioMvc.Context;
using ProjetoDesafioMvc.Models;

namespace ProjetoDesafioMvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController: ControllerBase
    {
        private readonly OrganizadorContext _context;
        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id) // funcionando
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }
        [HttpPut("{Id}")] // Funcionando
        public IActionResult Atualizar(int Id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(Id);

            if (tarefaBanco == null)
            return NotFound();

            if (tarefa.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
                
            if (tarefa.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Date = tarefa.Date;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefaBanco);
        }
        [HttpDelete("{id}")] // Funcionando
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
            return NotFound();

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            return NoContent();

        }
        [HttpGet("ObterTodos")] // Funcionando
        public IActionResult ObterTodos()
        {
            var tarefa = _context.Tarefas.ToList();
            return Ok(tarefa);
        }
        [HttpGet("ObterPorTitulo")] // funcionando
        public IActionResult ObterPorTitula(string titulo)
        {
            var tarefas = _context.Tarefas.Where(t => t.Titulo == titulo).ToList();
            
            if (tarefas.Count == 0)
            return NotFound();

            return Ok(tarefas);
        }
        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data) // funcionando
        {
            var tarefas = _context.Tarefas.Where(t => t.Date.Date == data.Date).ToList();

            if (tarefas.Count == 0)
            return NotFound();

            return Ok(tarefas);
        }
        [HttpGet ("ObterPorStatus")] // funcionando
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas.Where(t => t.Status == status).ToList();
            if (tarefas.Count == 0)
                return NotFound();
            return Ok(tarefas);
        }
         [HttpPost("Criar")]
        public IActionResult Criar(Tarefa tarefa) // funcionando
        {
            if (tarefa.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return Ok(tarefa);
        }
    }
}