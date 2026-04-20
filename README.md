# Camera Rental API - PAA LKM 01

## Deskripsi
REST API untuk sistem penyewaan kamera. Dibuat untuk memenuhi tugas LKM 01 mata kuliah Pemrograman Antarmuka Aplikasi.

**Domain:** Penyewaan Kamera

## Teknologi
- C# / .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Swagger

## Cara Menjalankan Project

### Prasyarat
- .NET 9 SDK
- PostgreSQL

### Langkah-langkah
1. Clone repository
2. Buat database di PostgreSQL: `CREATE DATABASE PAA_LKM_01;`
3. Jalankan file `database.sql` di database tersebut
4. Update connection string di `appsettings.json`
5. Jalankan `dotnet restore` lalu `dotnet run`
6. Buka `https://localhost:7066/swagger`

## Daftar Endpoint

| Method | URL | Deskripsi |
|--------|-----|-----------|
| GET | `/api/Cameras` | List semua kamera |
| GET | `/api/Cameras/{id}` | Detail kamera |
| POST | `/api/Cameras` | Tambah kamera |
| PUT | `/api/Cameras/{id}` | Update kamera |
| DELETE | `/api/Cameras/{id}` | Hapus kamera |
| GET | `/api/Rentals` | List semua rental |
| POST | `/api/Rentals` | Buat rental baru |

## Format Response

### Sukses
```json
{
  "status": "success",
  "data": { ... }
}
