using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAA_LKM_01.Models;
using PAA_LKM_01.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace PAA_LKM_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamerasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CamerasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cameras
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int perPage = 10)
        {
            var query = _context.Cameras.AsQueryable();
            var total = await query.CountAsync();
            var cameras = await query
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            var response = new ApiResponse<object>
            {
                Status = "success",
                Data = cameras,
                Meta = new MetaData
                {
                    Total = total,
                    Page = page,
                    PerPage = perPage
                }
            };

            return Ok(response);
        }

        // GET: api/cameras/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var camera = await _context.Cameras.FindAsync(id);

            if (camera == null)
            {
                return NotFound(new ApiErrorResponse { Message = "Kamera tidak ditemukan" });
            }

            return Ok(new ApiResponse<Camera>
            {
                Status = "success",
                Data = camera
            });
        }

        // POST: api/cameras
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CameraCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiErrorResponse { Message = "Data tidak valid" });
            }

            var camera = new Camera
            {
                Brand = dto.Brand,
                Model = dto.Model,
                PricePerDay = dto.PricePerDay,
                Stock = dto.Stock,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Cameras.Add(camera);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = camera.Id }, new ApiResponse<Camera>
            {
                Status = "success",
                Data = camera
            });
        }

        // PUT: api/cameras/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CameraUpdateDto dto)
        {
            var camera = await _context.Cameras.FindAsync(id);

            if (camera == null)
            {
                return NotFound(new ApiErrorResponse { Message = "Kamera tidak ditemukan" });
            }

            if (!string.IsNullOrEmpty(dto.Brand))
                camera.Brand = dto.Brand;

            if (!string.IsNullOrEmpty(dto.Model))
                camera.Model = dto.Model;

            if (dto.PricePerDay.HasValue)
                camera.PricePerDay = dto.PricePerDay.Value;

            if (dto.Stock.HasValue)
                camera.Stock = dto.Stock.Value;

            camera.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<Camera>
            {
                Status = "success",
                Data = camera
            });
        }

        // DELETE: api/cameras/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var camera = await _context.Cameras.FindAsync(id);

            if (camera == null)
            {
                return NotFound(new ApiErrorResponse { Message = "Kamera tidak ditemukan" });
            }

            _context.Cameras.Remove(camera);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<object>
            {
                Status = "success",
                Data = null,
                Message = "Kamera berhasil dihapus"
            });
        }
    }
}
