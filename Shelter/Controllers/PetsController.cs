using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shelter.Models;

namespace Shelter.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class PetsV1Controller : ControllerBase
  {
    private readonly ShelterContext _db;

    public PetsV1Controller(ShelterContext db)
    {
      _db = db;
    }
  }

  [ApiVersion("2.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class PetsV2Controller : ControllerBase
  {
    private readonly ShelterContext _db;

    public PetsV2Controller(ShelterContext db)
    {
      _db = db;
    }

    // GET api/pets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> Get()
    {
      return await _db.Pets.ToListAsync();
    }

    // GET: api/Pets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPet(int id)
    {
        var pet = await _db.Pets.FindAsync(id);

        if (pet == null)
        {
            return NotFound();
        }

        return pet;
    }

    // PUT: api/Pets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Pet pet)
    {
      if (id != pet.PetId)
      {
        return BadRequest();
      }

      _db.Entry(pet).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PetExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/Pets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
      var pet = await _db.Pets.FindAsync(id);
      if (pet == null)
      {
        return NotFound();
      }

      _db.Pets.Remove(pet);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // POST api/pets
    [HttpPost]
    public async Task<ActionResult<Pet>> Post(Pet pet)
    {
      _db.Pets.Add(pet);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPet), new { id = pet.PetId }, pet);
    }
    private bool PetExists(int id)
    {
      return _db.Pets.Any(e => e.PetId == id);
    }
  }
}


// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Shelter.Models;

// namespace Shelter.Controllers
// {
//   [Route("api/[controller]")]
//   [ApiController]
//   public class PetsController : ControllerBase
//   {
//     private readonly ShelterContext _db;

//     public PetsController(ShelterContext db)
//     {
//       _db = db;
//     }

//     // GET api/pets
//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<Pet>>> Get()
//     {
//       return await _db.Pets.ToListAsync();
//     }

//     // GET: api/Pets/5
//     [HttpGet("{id}")]
//     public async Task<ActionResult<Pet>> GetPet(int id)
//     {
//         var pet = await _db.Pets.FindAsync(id);

//         if (pet == null)
//         {
//             return NotFound();
//         }

//         return pet;
//     }

//     // PUT: api/Pets/5
//     [HttpPut("{id}")]
//     public async Task<IActionResult> Put(int id, Pet pet)
//     {
//       if (id != pet.PetId)
//       {
//         return BadRequest();
//       }

//       _db.Entry(pet).State = EntityState.Modified;

//       try
//       {
//         await _db.SaveChangesAsync();
//       }
//       catch (DbUpdateConcurrencyException)
//       {
//         if (!PetExists(id))
//         {
//           return NotFound();
//         }
//         else
//         {
//           throw;
//         }
//       }

//       return NoContent();
//     }

//     // DELETE: api/Pets/5
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeletePet(int id)
//     {
//       var pet = await _db.Pets.FindAsync(id);
//       if (pet == null)
//       {
//         return NotFound();
//       }

//       _db.Pets.Remove(pet);
//       await _db.SaveChangesAsync();

//       return NoContent();
//     }

//     // POST api/pets
//     [HttpPost]
//     public async Task<ActionResult<Pet>> Post(Pet pet)
//     {
//       _db.Pets.Add(pet);
//       await _db.SaveChangesAsync();

//       return CreatedAtAction(nameof(GetPet), new { id = pet.PetId }, pet);
//     }
//     private bool PetExists(int id)
//     {
//       return _db.Pets.Any(e => e.PetId == id);
//     }
//   }
// }