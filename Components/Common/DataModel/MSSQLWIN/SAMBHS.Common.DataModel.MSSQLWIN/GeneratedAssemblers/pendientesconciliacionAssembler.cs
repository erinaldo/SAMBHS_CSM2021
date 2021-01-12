//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:40
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
    /// Assembler for <see cref="pendientesconciliacion"/> and <see cref="pendientesconciliacionDto"/>.
    /// </summary>
    public static partial class pendientesconciliacionAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="pendientesconciliacionDto"/> converted from <see cref="pendientesconciliacion"/>.</param>
        static partial void OnDTO(this pendientesconciliacion entity, pendientesconciliacionDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="pendientesconciliacion"/> converted from <see cref="pendientesconciliacionDto"/>.</param>
        static partial void OnEntity(this pendientesconciliacionDto dto, pendientesconciliacion entity);

        /// <summary>
        /// Converts this instance of <see cref="pendientesconciliacionDto"/> to an instance of <see cref="pendientesconciliacion"/>.
        /// </summary>
        /// <param name="dto"><see cref="pendientesconciliacionDto"/> to convert.</param>
        public static pendientesconciliacion ToEntity(this pendientesconciliacionDto dto)
        {
            if (dto == null) return null;

            var entity = new pendientesconciliacion();

            entity.v_IdPendientesConciliacion = dto.v_IdPendientesConciliacion;
            entity.v_NroCuenta = dto.v_NroCuenta;
            entity.v_Anio = dto.v_Anio;
            entity.v_Mes = dto.v_Mes;
            entity.t_Fecha = dto.t_Fecha;
            entity.v_Naturaleza = dto.v_Naturaleza;
            entity.d_Importe = dto.d_Importe;
            entity.i_IdTipoDoc = dto.i_IdTipoDoc;
            entity.v_NumeroDoc = dto.v_NumeroDoc;
            entity.v_Glosa = dto.v_Glosa;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="pendientesconciliacion"/> to an instance of <see cref="pendientesconciliacionDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="pendientesconciliacion"/> to convert.</param>
        public static pendientesconciliacionDto ToDTO(this pendientesconciliacion entity)
        {
            if (entity == null) return null;

            var dto = new pendientesconciliacionDto();

            dto.v_IdPendientesConciliacion = entity.v_IdPendientesConciliacion;
            dto.v_NroCuenta = entity.v_NroCuenta;
            dto.v_Anio = entity.v_Anio;
            dto.v_Mes = entity.v_Mes;
            dto.t_Fecha = entity.t_Fecha;
            dto.v_Naturaleza = entity.v_Naturaleza;
            dto.d_Importe = entity.d_Importe;
            dto.i_IdTipoDoc = entity.i_IdTipoDoc;
            dto.v_NumeroDoc = entity.v_NumeroDoc;
            dto.v_Glosa = entity.v_Glosa;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="pendientesconciliacionDto"/> to an instance of <see cref="pendientesconciliacion"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<pendientesconciliacion> ToEntities(this IEnumerable<pendientesconciliacionDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="pendientesconciliacion"/> to an instance of <see cref="pendientesconciliacionDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<pendientesconciliacionDto> ToDTOs(this IEnumerable<pendientesconciliacion> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
