//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:48
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
    /// Assembler for <see cref="nbs_formatounicofacturacion"/> and <see cref="nbs_formatounicofacturacionDto"/>.
    /// </summary>
    public static partial class nbs_formatounicofacturacionAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="nbs_formatounicofacturacionDto"/> converted from <see cref="nbs_formatounicofacturacion"/>.</param>
        static partial void OnDTO(this nbs_formatounicofacturacion entity, nbs_formatounicofacturacionDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="nbs_formatounicofacturacion"/> converted from <see cref="nbs_formatounicofacturacionDto"/>.</param>
        static partial void OnEntity(this nbs_formatounicofacturacionDto dto, nbs_formatounicofacturacion entity);

        /// <summary>
        /// Converts this instance of <see cref="nbs_formatounicofacturacionDto"/> to an instance of <see cref="nbs_formatounicofacturacion"/>.
        /// </summary>
        /// <param name="dto"><see cref="nbs_formatounicofacturacionDto"/> to convert.</param>
        public static nbs_formatounicofacturacion ToEntity(this nbs_formatounicofacturacionDto dto)
        {
            if (dto == null) return null;

            var entity = new nbs_formatounicofacturacion();

            entity.v_IdFormatoUnicoFacturacion = dto.v_IdFormatoUnicoFacturacion;
            entity.v_IdCliente = dto.v_IdCliente;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Mes = dto.v_Mes;
            entity.v_Correlativo = dto.v_Correlativo;
            entity.v_NroFormato = dto.v_NroFormato;
            entity.t_FechaRegistro = dto.t_FechaRegistro;
            entity.v_IdClienteFacturar = dto.v_IdClienteFacturar;
            entity.d_Total = dto.d_Total;
            entity.i_Facturado = dto.i_Facturado;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="nbs_formatounicofacturacion"/> to an instance of <see cref="nbs_formatounicofacturacionDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="nbs_formatounicofacturacion"/> to convert.</param>
        public static nbs_formatounicofacturacionDto ToDTO(this nbs_formatounicofacturacion entity)
        {
            if (entity == null) return null;

            var dto = new nbs_formatounicofacturacionDto();

            dto.v_IdFormatoUnicoFacturacion = entity.v_IdFormatoUnicoFacturacion;
            dto.v_IdCliente = entity.v_IdCliente;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Mes = entity.v_Mes;
            dto.v_Correlativo = entity.v_Correlativo;
            dto.v_NroFormato = entity.v_NroFormato;
            dto.t_FechaRegistro = entity.t_FechaRegistro;
            dto.v_IdClienteFacturar = entity.v_IdClienteFacturar;
            dto.d_Total = entity.d_Total;
            dto.i_Facturado = entity.i_Facturado;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="nbs_formatounicofacturacionDto"/> to an instance of <see cref="nbs_formatounicofacturacion"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<nbs_formatounicofacturacion> ToEntities(this IEnumerable<nbs_formatounicofacturacionDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="nbs_formatounicofacturacion"/> to an instance of <see cref="nbs_formatounicofacturacionDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<nbs_formatounicofacturacionDto> ToDTOs(this IEnumerable<nbs_formatounicofacturacion> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
