using OA_Teste_Sozinho.Server;
using Microsoft.AspNetCore.Mvc;
using OA_Teste_Sozinho.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class GameController : Controller
{
    private readonly AppDbContext db;
    
    public GameController(AppDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var Jogos = await db.Jogos.ToListAsync();
        return Ok(Jogos);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var jogo = await db.Jogos.SingleOrDefaultAsync(x => x.ID == Convert.ToInt32(id));
        return Ok(jogo);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Post([FromBody] Game jogo)
    {
        try
        {
            var newGame = new Game
            {
                ID = jogo.ID,
                Jogo_Nome = jogo.Jogo_Nome,
                Genero_ID = Convert.ToInt32(jogo.Genero_ID),
            };

            db.Add(newGame);
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
    public async Task<IActionResult> Put([FromBody] Game Game_Modificado)
    {
        db.Entry(Game_Modificado).State = EntityState.Modified;
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
    public async Task<ActionResult<Game>> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var jogo = await db.Jogos.FindAsync(id);
        if (jogo == null)
        {
            return NotFound();
        }
        db.Jogos.Remove(jogo);
        await db.SaveChangesAsync();
        return jogo;
    }

    private bool GameExists(int id)
    {
        return db.Jogos.Any(e => e.ID == id);
    }

}