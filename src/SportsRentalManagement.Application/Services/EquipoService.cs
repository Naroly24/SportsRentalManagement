using System;
using System.Collections.Generic;
using SportsRentalManagement.Domain.Interfaces;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly IEquipoRepository _equipoRepository;

        public EquipoService(IEquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }

        public IEnumerable<Equipo> ObtenerTodosLosEquipos()
        {
            return _equipoRepository.ObtenerTodos();
        }

        public Equipo ObtenerEquipoPorId(int id)
        {
            return _equipoRepository.ObtenerPorId(id);
        }

        public void AgregarEquipo(Equipo equipo)
        {
            _equipoRepository.Agregar(equipo);
        }

        public void ActualizarEquipo(Equipo equipo)
        {
            _equipoRepository.Actualizar(equipo);
        }

        public void EliminarEquipo(int id)
        {
            _equipoRepository.Eliminar(id);
        }
    }

    public interface IEquipoService
    {
        IEnumerable<Equipo> ObtenerTodosLosEquipos();
        Equipo ObtenerEquipoPorId(int id);
        void AgregarEquipo(Equipo equipo);
        void ActualizarEquipo(Equipo equipo);
        void EliminarEquipo(int id);
    }
}