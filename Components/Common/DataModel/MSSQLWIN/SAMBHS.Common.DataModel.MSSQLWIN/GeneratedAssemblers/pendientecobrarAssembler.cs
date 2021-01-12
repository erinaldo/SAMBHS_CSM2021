//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:56
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
    /// Assembler for <see cref="pendientecobrar"/> and <see cref="pendientecobrarDto"/>.
    /// </summary>
    public static partial class pendientecobrarAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="pendientecobrarDto"/> converted from <see cref="pendientecobrar"/>.</param>
        static partial void OnDTO(this pendientecobrar entity, pendientecobrarDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="pendientecobrar"/> converted from <see cref="pendientecobrarDto"/>.</param>
        static partial void OnEntity(this pendientecobrarDto dto, pendientecobrar entity);

        /// <summary>
        /// Converts this instance of <see cref="pendientecobrarDto"/> to an instance of <see cref="pendientecobrar"/>.
        /// </summary>
        /// <param name="dto"><see cref="pendientecobrarDto"/> to convert.</param>
        public static pendientecobrar ToEntity(this pendientecobrarDto dto)
        {
            if (dto == null) return null;

            var entity = new pendientecobrar();

            entity.v_IdPendienteCobrar = dto.v_IdPendienteCobrar;
            entity.v_NroCuenta = dto.v_NroCuenta;
            entity.i_IdTipoDocumento = dto.i_IdTipoDocumento;
            entity.v_NroDocumento = dto.v_NroDocumento;
            entity.v_IdCliente = dto.v_IdCliente;
            entity.v_NroRucProveedor = dto.v_NroRucProveedor;
            entity.t_FechaRegistro = dto.t_FechaRegistro;
            entity.t_FechaReferencia = dto.t_FechaReferencia;
            entity.i_IdMoneda = dto.i_IdMoneda;
            entity.d_ImporteSaldo = dto.d_ImporteSaldo;
            entity.d_ImporteSaldoDolares = dto.d_ImporteSaldoDolares;
            entity.i_FlagTipoMovimiento = dto.i_FlagTipoMovimiento;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="pendientecobrar"/> to an instance of <see cref="pendientecobrarDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="pendientecobrar"/> to convert.</param>
        public static pendientecobrarDto ToDTO(this pendientecobrar entity)
        {
            if (entity == null) return null;

            var dto = new pendientecobrarDto();

            dto.v_IdPendienteCobrar = entity.v_IdPendienteCobrar;
            dto.v_NroCuenta = entity.v_NroCuenta;
            dto.i_IdTipoDocumento = entity.i_IdTipoDocumento;
            dto.v_NroDocumento = entity.v_NroDocumento;
            dto.v_IdCliente = entity.v_IdCliente;
            dto.v_NroRucProveedor = entity.v_NroRucProveedor;
            dto.t_FechaRegistro = entity.t_FechaRegistro;
            dto.t_FechaReferencia = entity.t_FechaReferencia;
            dto.i_IdMoneda = entity.i_IdMoneda;
            dto.d_ImporteSaldo = entity.d_ImporteSaldo;
            dto.d_ImporteSaldoDolares = entity.d_ImporteSaldoDolares;
            dto.i_FlagTipoMovimiento = entity.i_FlagTipoMovimiento;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="pendientecobrarDto"/> to an instance of <see cref="pendientecobrar"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<pendientecobrar> ToEntities(this IEnumerable<pendientecobrarDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="pendientecobrar"/> to an instance of <see cref="pendientecobrarDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<pendientecobrarDto> ToDTOs(this IEnumerable<pendientecobrar> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
