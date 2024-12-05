using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Data;
using SportsRentalManagement.Models;
using System;
using System.Linq;
using System.IO;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SportsRentalManagement.Controllers
{
    public class ReportesController : Controller
    {
        private readonly AppDBContext _context;

        public ReportesController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? equipoId, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var equipos = _context.Equipos.ToList();
            var reservas = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .AsQueryable();

            if (equipoId.HasValue)
            {
                reservas = reservas.Where(r => r.EquipoId == equipoId.Value);
            }

            if (fechaInicio.HasValue)
            {
                reservas = reservas.Where(r => r.FechaInicio >= fechaInicio.Value);
            }

            if (fechaFin.HasValue)
            {
                reservas = reservas.Where(r => r.FechaFin <= fechaFin.Value);
            }

            // Obtener la lista de reservas filtradas
            var reporte = reservas.ToList();

            ViewBag.Equipos = equipos;
            ViewData["EquipoId"] = equipoId;
            ViewData["FechaInicio"] = fechaInicio?.ToString("yyyy-MM-dd");
            ViewData["FechaFin"] = fechaFin?.ToString("yyyy-MM-dd");

            return View(reporte);
        }

        public IActionResult DescargarExcel(int? equipoId, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var reservas = ObtenerReservasFiltradas(equipoId, fechaInicio, fechaFin);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reporte de Reservas");

                // Agregar encabezados
                worksheet.Cell(1, 1).Value = "Equipo";
                worksheet.Cell(1, 2).Value = "Usuario";
                worksheet.Cell(1, 3).Value = "Fecha Inicio";
                worksheet.Cell(1, 4).Value = "Fecha Fin";
                worksheet.Cell(1, 5).Value = "Duración (días)";
                worksheet.Cell(1, 6).Value = "Ingreso Generado";

                // Dar formato a los encabezados
                var rango = worksheet.Range(1, 1, 1, 6);
                rango.Style.Font.Bold = true;
                rango.Style.Fill.BackgroundColor = XLColor.LightGray;

                // Agregar datos
                int row = 2;
                foreach (var reserva in reservas)
                {
                    worksheet.Cell(row, 1).Value = reserva.Equipo.Nombre;
                    worksheet.Cell(row, 2).Value = reserva.Usuario.Nombre;
                    worksheet.Cell(row, 3).Value = reserva.FechaInicio.ToShortDateString();
                    worksheet.Cell(row, 4).Value = reserva.FechaFin.ToShortDateString();
                    worksheet.Cell(row, 5).Value = (reserva.FechaFin - reserva.FechaInicio).Days;
                    worksheet.Cell(row, 6).Value = (reserva.FechaFin - reserva.FechaInicio).Days * reserva.Equipo.PrecioPorDia;
                    row++;
                }

                // Autoajustar columnas
                worksheet.Columns().AdjustToContents();

                // Generar el archivo
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteReservas.xlsx");
                }
            }
        }

        public IActionResult DescargarPDF(int? equipoId, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var reservas = ObtenerReservasFiltradas(equipoId, fechaInicio, fechaFin);

            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                // Agregar título
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Paragraph title = new Paragraph("Reporte de Reservas", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                // Crear tabla
                PdfPTable table = new PdfPTable(6);
                table.WidthPercentage = 100;

                // Agregar encabezados
                table.AddCell("Equipo");
                table.AddCell("Usuario");
                table.AddCell("Fecha Inicio");
                table.AddCell("Fecha Fin");
                table.AddCell("Duración (días)");
                table.AddCell("Ingreso Generado");

                // Agregar datos
                foreach (var reserva in reservas)
                {
                    table.AddCell(reserva.Equipo.Nombre);
                    table.AddCell(reserva.Usuario.Nombre);
                    table.AddCell(reserva.FechaInicio.ToShortDateString());
                    table.AddCell(reserva.FechaFin.ToShortDateString());
                    table.AddCell((reserva.FechaFin - reserva.FechaInicio).Days.ToString());
                    table.AddCell(((reserva.FechaFin - reserva.FechaInicio).Days * reserva.Equipo.PrecioPorDia).ToString("C"));
                }

                document.Add(table);
                document.Close();

                return File(ms.ToArray(), "application/pdf", "ReporteReservas.pdf");
            }
        }

        private IEnumerable<Reserva> ObtenerReservasFiltradas(int? equipoId, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var reservas = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .AsQueryable();

            if (equipoId.HasValue)
            {
                reservas = reservas.Where(r => r.EquipoId == equipoId.Value);
            }

            if (fechaInicio.HasValue)
            {
                reservas = reservas.Where(r => r.FechaInicio >= fechaInicio.Value);
            }

            if (fechaFin.HasValue)
            {
                reservas = reservas.Where(r => r.FechaFin <= fechaFin.Value);
            }

            return reservas.ToList();
        }
    }
}