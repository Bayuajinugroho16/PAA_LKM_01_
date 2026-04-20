using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAA_LKM_01.Models;
using PAA_LKM_01.DTOs;
using System;
using System.Threading.Tasks;

namespace PAA_LKM_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RentalsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Rentals
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rentals = await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Camera)
                .Select(r => new
                {
                    r.Id,
                    CustomerId = r.Customer != null ? r.Customer.Id : 0,
                    CustomerName = r.Customer != null ? r.Customer.Name : "",
                    CustomerEmail = r.Customer != null ? r.Customer.Email : "",
                    CameraId = r.Camera != null ? r.Camera.Id : 0,
                    CameraBrand = r.Camera != null ? r.Camera.Brand : "",
                    CameraModel = r.Camera != null ? r.Camera.Model : "",
                    r.RentalDate,
                    r.ReturnDate,
                    r.TotalPrice,
                    r.Status,
                    r.CreatedAt,
                    r.UpdatedAt
                })
                .ToListAsync();

            return Ok(new ApiResponse<object>
            {
                Status = "success",
                Data = rentals
            });
        }

        // POST: api/Rentals
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RentalCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiErrorResponse { Message = "Data tidak valid" });
            }

            var camera = await _context.Cameras.FindAsync(dto.CameraId);
            if (camera == null)
            {
                return BadRequest(new ApiErrorResponse { Message = "Kamera tidak ditemukan" });
            }

            var customer = await _context.Customers.FindAsync(dto.CustomerId);
            if (customer == null)
            {
                return BadRequest(new ApiErrorResponse { Message = "Customer tidak ditemukan" });
            }

            if (camera.Stock <= 0)
            {
                return BadRequest(new ApiErrorResponse { Message = "Stok kamera habis" });
            }

            var rental = new Rental
            {
                CustomerId = dto.CustomerId,
                CameraId = dto.CameraId,
                RentalDate = DateTime.UtcNow,
                ReturnDate = DateTime.UtcNow.AddDays(dto.Days),
                TotalPrice = camera.PricePerDay * dto.Days,
                Status = "active",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            camera.Stock--;
            camera.UpdatedAt = DateTime.UtcNow;

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            // Return data tanpa circular reference
            var result = new
            {
                rental.Id,
                rental.CustomerId,
                CustomerName = customer.Name,
                rental.CameraId,
                CameraBrand = camera.Brand,
                CameraModel = camera.Model,
                rental.RentalDate,
                rental.ReturnDate,
                rental.TotalPrice,
                rental.Status,
                rental.CreatedAt,
                rental.UpdatedAt
            };

            return Ok(new ApiResponse<object>
            {
                Status = "success",
                Data = result,
                Message = "Penyewaan berhasil dibuat"
            });
        }
    }
}