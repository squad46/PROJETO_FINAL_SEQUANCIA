using Andor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Andor.Controllers
{
    public class TrabalhoController : Controller
    {
        private readonly Contexto _context;

        public TrabalhoController(Contexto context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            ViewData["trabalhos"] = _context.Trabalhos.OrderByDescending(x => x.DataCadastro).ToList(); // cria lista de trabalhos


            return View();
        }


        [HttpGet]
        public IActionResult Detalhes(int id, int pessoaId)
        {
      
            var trabalho = _context.Trabalhos.Where(p => p.Id == id).ToList();
            var pessoa   = _context.Pessoas.Where(p => p.Id == pessoaId).ToList();
            ViewData["_trabalhos"] = trabalho;
            ViewData["_pessoas"]   = pessoa;
          
            return View();

        }
    }



}
