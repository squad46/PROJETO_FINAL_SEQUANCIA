using Andor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Andor.Controllers
{
    public class MoradiaController : Controller
    {
        private readonly Contexto _context;

        public MoradiaController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Detalhes");
        }

        [HttpGet]
        public IActionResult Detalhes(int id, int pessoaId)
        {
            var moradia = _context.Moradias.Where(p => p.Id == id).ToList();
            var pessoa = _context.Pessoas.Where(p => p.Id == pessoaId).ToList();
            ViewData["_moradias"] = moradia;
            ViewData["_pessoas"] = pessoa;
            return View();
        }


        public IActionResult Novo()
        {
            ViewData["Id_pessoa"] = Request.Cookies["id"];
            return View();
        }


        [HttpPost]
        public IActionResult Novo([Bind("Id,Id_pessoa,Name,Descricao,Tipo,Preco,Endereco,Numero,CEP,UF,Cidade,NomeContato,TelefoneContato,EmailContato,DataCadastro")] Moradia moradia,
            IList<IFormFile> img1, IList<IFormFile> img2, IList<IFormFile> img3, IList<IFormFile> img4)
        {

            var idPessoa = moradia.Id_pessoa;
            IFormFile imagemEnviada = img1.FirstOrDefault();
            if (imagemEnviada != null)
            {
                _context.Add(moradia);
                _context.SaveChanges();
            }
            else
            {
                var msg = "Imagem de capa deve ser escolhida";
                ViewData["Id_pessoa"] = Request.Cookies["id"];
                ViewBag.mensagem = msg;
                return View();
                //return Redirect("~/Moradia/Novo?Id_pessoa=" + idPessoa);
            }
            SalvaImagens(img1, moradia.Id);
            SalvaImagens(img2, moradia.Id);
            SalvaImagens(img3, moradia.Id);
            SalvaImagens(img4, moradia.Id);
            /*
            if (imagemEnviada != null)
            {
                imagemEnviada.ContentType.ToLower().StartsWith("image/");
                if (imagemEnviada.ContentType == "image/jpeg" || imagemEnviada.ContentType == "image/png")
                {
                    MemoryStream ms = new MemoryStream(); // salva imagem de moradia
                    imagemEnviada.OpenReadStream().CopyTo(ms);
                    Imagem imagemEntity = new Imagem()
                    {
                        Id_tipo = moradia.Id,
                        Tipo = "moradia",
                        Nome = imagemEnviada.Name,
                        Dados = ms.ToArray(),
                        ContentType = imagemEnviada.ContentType
                    };
                    _context.Imagens.Add(imagemEntity);
                    _context.SaveChanges();
                }
            }
            */
            return Redirect("~/Pessoa/Details/" + Request.Cookies["id"]);
        }
        public void SalvaImagens(IList<IFormFile> img, int moradia) // Salva imagens
        {
            IFormFile imagemEnviada = img.FirstOrDefault();

            if (imagemEnviada != null)
            {
                imagemEnviada.ContentType.ToLower().StartsWith("image/");
                if (imagemEnviada.ContentType == "image/jpeg" || imagemEnviada.ContentType == "image/png")
                {
                    MemoryStream ms = new MemoryStream(); // salva imagem de moradia
                    imagemEnviada.OpenReadStream().CopyTo(ms);
                    Imagem imagemEntity = new Imagem()
                    {
                        Id_tipo = moradia,
                        Tipo = "moradia",
                        Nome = imagemEnviada.Name,
                        Dados = ms.ToArray(),
                        ContentType = imagemEnviada.ContentType
                    };
                    _context.Imagens.Add(imagemEntity);
                    _context.SaveChanges();
                }
            }
        }
    }
}
