# Camera Rental API - PAA LKM 01

## Deskripsi
REST API untuk sistem penyewaan kamera.

## Teknologi
- C# / .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Swagger

## Cara Menjalankan
1. Clone repository
2. Buat database `PAA_LKM_01` di PostgreSQL
3. Jalankan `database.sql`
4. Update connection string di `appsettings.json`
5. `dotnet run`
6. Buka `https://localhost:7066/swagger`

## Endpoint

| Method | URL | Deskripsi |
|--------|-----|-----------|
| GET | `/api/Cameras` | List semua kamera |
| GET | `/api/Cameras/{id}` | Detail kamera |
| POST | `/api/Cameras` | Tambah kamera |
| PUT | `/api/Cameras/{id}` | Update kamera |
| DELETE | `/api/Cameras/{id}` | Hapus kamera |
| GET | `/api/Rentals` | List semua rental |
| POST | `/api/Rentals` | Buat rental baru |

## Link Video
[Video Presentasi]()

## Author
- Nama: [Bayu Aji Nugroho]
- NIM: [242410102090]
- Kelas: [PAA (A)]