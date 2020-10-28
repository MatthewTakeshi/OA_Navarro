using OA_Teste_Sozinho.Server;
using Microsoft.AspNetCore.Mvc;
using OA_Teste_Sozinho.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class PlataformaController : Controller
{
    private readonly AppDbContext db;
    
    public PlataformaController(AppDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var Plataformas = await db.Plataformas.ToListAsync();
        return Ok(Plataformas);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var Plataforminha = await db.Plataformas.SingleOrDefaultAsync(x => x.ID == Convert.ToInt32(id));
        return Ok(Plataforminha);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Post([FromBody] Plataforma Plataforminha)
    {
        try
        {
            var new_Plataforma = new Plataforma
            {
                ID = Plataforminha.ID,
                Plataforma_Nome = Plataforminha.Plataforma_Nome,
            };

            db.Add(new_Plataforma);
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
    public async Task<IActionResult> Put([FromBody] Plataforma Plataforma_Modificado)
    {
        db.Entry(Plataforma_Modificado).State = EntityState.Modified;
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
    public async Task<ActionResult<Plataforma>> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var Plataforminha = await db.Plataformas.FindAsync(id);
        if (Plataforminha == null)
        {
            return NotFound();
        }
        db.Plataformas.Remove(Plataforminha);
        await db.SaveChangesAsync();
        return Plataforminha;
    }

    private bool Plataforma_Exist(int id)
    {
        return db.Plataformas.Any(e => e.ID == id);
    }

}