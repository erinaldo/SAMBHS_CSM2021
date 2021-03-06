using SAMBHS.Common.DataModel;
using System.Linq;
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/19 - 12:50:55
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

namespace SAMBHS.Common.BE
{

    /// <summary>
    /// Assembler for <see cref="almacen"/> and <see cref="almacenDto"/>.
    /// </summary>
    public static partial class almacenAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="almacenDto"/> converted from <see cref="almacen"/>.</param>
        static partial void OnDTO(this almacen entity, almacenDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="almacen"/> converted from <see cref="almacenDto"/>.</param>
        static partial void OnEntity(this almacenDto dto, almacen entity);

        /// <summary>
        /// Converts this instance of <see cref="almacenDto"/> to an instance of <see cref="almacen"/>.
        /// </summary>
        /// <param name="dto"><see cref="almacenDto"/> to convert.</param>
        public static almacen ToEntity(this almacenDto dto)
        {
            if (dto == null) return null;

            var entity = new almacen();

            entity.i_IdAlmacen = dto.i_IdAlmacen;
            entity.v_Nombre = dto.v_Nombre;
            entity.v_Direccion = dto.v_Direccion;
            entity.v_Telefono = dto.v_Telefono;
            entity.v_NombreComercial = dto.v_NombreComercial;
            entity.v_NumeroSerieTicket = dto.v_NumeroSerieTicket;
            entity.v_CodigoEstablecimiento = dto.v_CodigoEstablecimiento;
            entity.v_Observacion = dto.v_Observacion;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.i_ValidarStockAlmacen = dto.i_ValidarStockAlmacen;
            entity.v_Ubigueo = dto.v_Ubigueo;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="almacen"/> to an instance of <see cref="almacenDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="almacen"/> to convert.</param>
        public static almacenDto ToDTO(this almacen entity)
        {
            if (entity == null) return null;

            var dto = new almacenDto();

            dto.i_IdAlmacen = entity.i_IdAlmacen;
            dto.v_Nombre = entity.v_Nombre;
            dto.v_Direccion = entity.v_Direccion;
            dto.v_Telefono = entity.v_Telefono;
            dto.v_NombreComercial = entity.v_NombreComercial;
            dto.v_NumeroSerieTicket = entity.v_NumeroSerieTicket;
            dto.v_CodigoEstablecimiento = entity.v_CodigoEstablecimiento;
            dto.v_Observacion = entity.v_Observacion;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.i_ValidarStockAlmacen = entity.i_ValidarStockAlmacen;
            dto.v_Ubigueo = entity.v_Ubigueo;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="almacenDto"/> to an instance of <see cref="almacen"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<almacen> ToEntities(this IEnumerable<almacenDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="almacen"/> to an instance of <see cref="almacenDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<almacenDto> ToDTOs(this IEnumerable<almacen> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}