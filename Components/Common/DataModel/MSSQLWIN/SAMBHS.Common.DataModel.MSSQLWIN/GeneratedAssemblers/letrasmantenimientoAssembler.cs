//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:40
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using SAMBHS.Common.DataModel;

namespace SAMBHS.Common.BE
{

    /// <summary>
    /// Assembler for <see cref="letrasmantenimiento"/> and <see cref="letrasmantenimientoDto"/>.
    /// </summary>
    public static partial class letrasmantenimientoAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="letrasmantenimientoDto"/> converted from <see cref="letrasmantenimiento"/>.</param>
        static partial void OnDTO(this letrasmantenimiento entity, letrasmantenimientoDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="letrasmantenimiento"/> converted from <see cref="letrasmantenimientoDto"/>.</param>
        static partial void OnEntity(this letrasmantenimientoDto dto, letrasmantenimiento entity);

        /// <summary>
        /// Converts this instance of <see cref="letrasmantenimientoDto"/> to an instance of <see cref="letrasmantenimiento"/>.
        /// </summary>
        /// <param name="dto"><see cref="letrasmantenimientoDto"/> to convert.</param>
        public static letrasmantenimiento ToEntity(this letrasmantenimientoDto dto)
        {
            if (dto == null) return null;

            var entity = new letrasmantenimiento();

            entity.v_IdLetrasMantenimiento = dto.v_IdLetrasMantenimiento;
            entity.v_IdCliente = dto.v_IdCliente;
            entity.t_FechaRegistro = dto.t_FechaRegistro;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Correlativo = dto.v_Correlativo;
            entity.i_IdTipoMantenimiento = dto.i_IdTipoMantenimiento;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="letrasmantenimiento"/> to an instance of <see cref="letrasmantenimientoDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="letrasmantenimiento"/> to convert.</param>
        public static letrasmantenimientoDto ToDTO(this letrasmantenimiento entity)
        {
            if (entity == null) return null;

            var dto = new letrasmantenimientoDto();

            dto.v_IdLetrasMantenimiento = entity.v_IdLetrasMantenimiento;
            dto.v_IdCliente = entity.v_IdCliente;
            dto.t_FechaRegistro = entity.t_FechaRegistro;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Correlativo = entity.v_Correlativo;
            dto.i_IdTipoMantenimiento = entity.i_IdTipoMantenimiento;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="letrasmantenimientoDto"/> to an instance of <see cref="letrasmantenimiento"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<letrasmantenimiento> ToEntities(this IEnumerable<letrasmantenimientoDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="letrasmantenimiento"/> to an instance of <see cref="letrasmantenimientoDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<letrasmantenimientoDto> ToDTOs(this IEnumerable<letrasmantenimiento> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
