using OA_Teste_Sozinho.Server;
using Microsoft.AspNetCore.Mvc;
using OA_Teste_Sozinho.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class GeneroController : Controller
{
    private readonly AppDbContext db;
    
    public GeneroController(AppDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var Generos = await db.Generos.ToListAsync();
        return Ok(Generos);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var Generinho = await db.Generos.SingleOrDefaultAsync(x => x.ID == Convert.ToInt32(id));
        return Ok(Generinho);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Post([FromBody] Genero Generinho)
    {
        try
        {
            var new_Genero = new Genero
            {
                ID = Generinho.ID,
                Genero_Nome = Generinho.Genero_Nome,
                Jogo_ID = Generinho.Jogo_ID,
            };

            db.Add(new_Genero);
            await db.SaveChangesAsync();
            return Ok();
        }
        catch(Exception e)
        {
            return View(e);
        }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Put([FromBody] Genero Genero_Modificado)
    {
        db.Entry(Genero_Modificado).State = EntityState.Modified;
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw (ex);
        }
        return NoContent();
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<ActionResult<Genero>> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var Generinho = await db.Generos.FindAsync(id);
        if (Generinho == null)
        {
            return NotFound();
        }
        db.Generos.Remove(Generinho);
        await db.SaveChangesAsync();
        return Generinho;
    }

    private bool Genero_Exists(int id)
    {
        return db.Generos.Any(e => e.ID == id);
    }

}