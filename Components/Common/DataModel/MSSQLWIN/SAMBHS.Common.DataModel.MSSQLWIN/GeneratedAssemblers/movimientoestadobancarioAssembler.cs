//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:38
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
    /// Assembler for <see cref="movimientoestadobancario"/> and <see cref="movimientoestadobancarioDto"/>.
    /// </summary>
    public static partial class movimientoestadobancarioAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="movimientoestadobancarioDto"/> converted from <see cref="movimientoestadobancario"/>.</param>
        static partial void OnDTO(this movimientoestadobancario entity, movimientoestadobancarioDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="movimientoestadobancario"/> converted from <see cref="movimientoestadobancarioDto"/>.</param>
        static partial void OnEntity(this movimientoestadobancarioDto dto, movimientoestadobancario entity);

        /// <summary>
        /// Converts this instance of <see cref="movimientoestadobancarioDto"/> to an instance of <see cref="movimientoestadobancario"/>.
        /// </summary>
        /// <param name="dto"><see cref="movimientoestadobancarioDto"/> to convert.</param>
        public static movimientoestadobancario ToEntity(this movimientoestadobancarioDto dto)
        {
            if (dto == null) return null;

            var entity = new movimientoestadobancario();

            entity.v_IdMovimientoEstadoBancario = dto.v_IdMovimientoEstadoBancario;
            entity.v_IdReferencia = dto.v_IdReferencia;
            entity.v_NroCuenta = dto.v_NroCuenta;
            entity.v_Anio = dto.v_Anio;
            entity.v_Mes = dto.v_Mes;
            entity.t_Fecha = dto.t_Fecha;
            entity.d_Cargo = dto.d_Cargo;
            entity.d_Abono = dto.d_Abono;
            entity.i_IdTipoDocumento = dto.i_IdTipoDocumento;
            entity.v_NumeroDocumento = dto.v_NumeroDocumento;
            entity.v_Concepto = dto.v_Concepto;
            entity.v_CodAsiento = dto.v_CodAsiento;
            entity.v_NumeroAsiento = dto.v_NumeroAsiento;
            entity.i_IdTipoDocRef = dto.i_IdTipoDocRef;
            entity.v_NroDocumentoRef = dto.v_NroDocumentoRef;
            entity.i_Mes = dto.i_Mes;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="movimientoestadobancario"/> to an instance of <see cref="movimientoestadobancarioDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="movimientoestadobancario"/> to convert.</param>
        public static movimientoestadobancarioDto ToDTO(this movimientoestadobancario entity)
        {
            if (entity == null) return null;

            var dto = new movimientoestadobancarioDto();

            dto.v_IdMovimientoEstadoBancario = entity.v_IdMovimientoEstadoBancario;
            dto.v_IdReferencia = entity.v_IdReferencia;
            dto.v_NroCuenta = entity.v_NroCuenta;
            dto.v_Anio = entity.v_Anio;
            dto.v_Mes = entity.v_Mes;
            dto.t_Fecha = entity.t_Fecha;
            dto.d_Cargo = entity.d_Cargo;
            dto.d_Abono = entity.d_Abono;
            dto.i_IdTipoDocumento = entity.i_IdTipoDocumento;
            dto.v_NumeroDocumento = entity.v_NumeroDocumento;
            dto.v_Concepto = entity.v_Concepto;
            dto.v_CodAsiento = entity.v_CodAsiento;
            dto.v_NumeroAsiento = entity.v_NumeroAsiento;
            dto.i_IdTipoDocRef = entity.i_IdTipoDocRef;
            dto.v_NroDocumentoRef = entity.v_NroDocumentoRef;
            dto.i_Mes = entity.i_Mes;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="movimientoestadobancarioDto"/> to an instance of <see cref="movimientoestadobancario"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<movimientoestadobancario> ToEntities(this IEnumerable<movimientoestadobancarioDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="movimientoestadobancario"/> to an instance of <see cref="movimientoestadobancarioDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<movimientoestadobancarioDto> ToDTOs(this IEnumerable<movimientoestadobancario> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
