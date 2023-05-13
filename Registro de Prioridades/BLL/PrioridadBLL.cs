﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Registro_de_Prioridades.DAL;
using Registro_de_Prioridades.Entidades;
using System.Diagnostics.Contracts;

namespace Registro_de_Prioridades.BLL
{
    public class PrioridadBLL
    {
        private Context _context;
        public PrioridadBLL(Context Context) { 
            _context = Context; 
        }
        public bool Existe(int PrioridadId)
        {
            return _context.Prioridad.Any(s => s.PrioridadId == PrioridadId);
        }
        private bool Insertar(Prioridad prioridad)
        {
            _context.Prioridad.Add(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Modificar(Prioridad prioridad)
        {
            _context.Update(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }
        public bool Guardar(Prioridad prioridad)
        {
            if (!Existe(prioridad.PrioridadId))
                return Insertar(prioridad);
            else 
                return Modificar(prioridad);
        }
        public bool Eliminar(Prioridad prioridad)
        {
            _context.Prioridad.Remove(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;    
        }
        public Prioridad? Buscar(int PrioridadId)
        {
            return _context.Prioridad
                .AsNoTracking()
                .FirstOrDefault(s => s.PrioridadId == PrioridadId);
        }
        public List<Prioridad> GetList(Expression<Func<Prioridad, bool >> Criterio)
        {
            return _context.Prioridad
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
        public bool Validar(string? descripcion)
        {
            bool confirmar = false;
            confirmar = _context.Prioridad.Any(e => e.Descripcion.ToLower() == descripcion.ToLower());
            return confirmar;
        }

    }
}
