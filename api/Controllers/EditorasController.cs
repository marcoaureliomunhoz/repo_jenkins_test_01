using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace biblio_api.Controllers
{
    /// <summary>
    /// API de Editoras
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EditorasController : ControllerBase
    {
        private readonly BiblioDbContext _db;

        /// <summary>
        /// Construtor
        /// </summary>
        public EditorasController(BiblioDbContext db)
        {
            _db = db;    
        }

        /// <summary>
        /// Retorna uma lista de Editoras
        /// </summary>
        // GET api/editoras
        [HttpGet]
        public ActionResult<IEnumerable<Editora>> Get()
        {
            return _db.Editoras.ToList();
        }

        /// <summary>
        /// Retorna uma Editora
        /// </summary>
        /// <param name="id"></param> 
        // GET api/editoras/5
        [HttpGet("{id}")]
        public ActionResult<Editora> Get(int id)
        {
            return _db.Editoras.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Salva uma nova Editora
        /// </summary>
        /// <param name="novaEditora"></param> 
        // POST api/editoras
        [HttpPost]
        public void Post([FromBody] Editora novaEditora)
        {
            var editora = new Editora(novaEditora.Nome);
            _db.Editoras.Add(editora);
            _db.SaveChanges();
        }

        /// <summary>
        /// Salva as alterações em um Editora já existente
        /// </summary>
        /// <param name="id"></param> 
        /// <param name="editoraAlterada"></param>         
        // PUT api/editoras/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Editora editoraAlterada)
        {
            var editora = _db.Editoras.FirstOrDefault(x => x.Id == id);
            editora.AlterarNome(editoraAlterada.Nome);
            _db.SaveChanges();
        }

        /// <summary>
        /// Exclui uma Editora
        /// </summary>
        /// <param name="id"></param> 
        // DELETE api/editoras/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var editora = _db.Editoras.FirstOrDefault(x => x.Id == id);
            _db.Remove(editora);
            _db.SaveChanges();
        }
    }
}
