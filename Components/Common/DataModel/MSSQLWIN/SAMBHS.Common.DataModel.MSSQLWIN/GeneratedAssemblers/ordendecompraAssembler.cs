//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/09/22 - 11:53:28
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
    /// Assembler for <see cref="ordendecompra"/> and <see cref="ordendecompraDto"/>.
    /// </summary>
    public static partial class ordendecompraAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ordendecompraDto"/> converted from <see cref="ordendecompra"/>.</param>
        static partial void OnDTO(this ordendecompra entity, ordendecompraDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ordendecompra"/> converted from <see cref="ordendecompraDto"/>.</param>
        static partial void OnEntity(this ordendecompraDto dto, ordendecompra entity);

        /// <summary>
        /// Converts this instance of <see cref="ordendecompraDto"/> to an instance of <see cref="ordendecompra"/>.
        /// </summary>
        /// <param name="dto"><see cref="ordendecompraDto"/> to convert.</param>
        public static ordendecompra ToEntity(this ordendecompraDto dto)
        {
            if (dto == null) return null;

            var entity = new ordendecompra();

            entity.v_IdOrdenCompra = dto.v_IdOrdenCompra;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Mes = dto.v_Mes;
            entity.v_Correlativo = dto.v_Correlativo;
            entity.i_IdTipoDocumento = dto.i_IdTipoDocumento;
            entity.v_SerieDocumento = dto.v_SerieDocumento;
            entity.v_CorrelativoDocumento = dto.v_CorrelativoDocumento;
            entity.v_DocumentoInterno = dto.v_DocumentoInterno;
            entity.t_FechaRegistro = dto.t_FechaRegistro;
            entity.v_IdProveedor = dto.v_IdProveedor;
            entity.i_PreciosAfectosIgv = dto.i_PreciosAfectosIgv;
            entity.i_PreciosIncluyeIgv = dto.i_PreciosIncluyeIgv;
            entity.i_IdIgv = dto.i_IdIgv;
            entity.i_NodeId = dto.i_NodeId;
            entity.i_IdAreaSolicita = dto.i_IdAreaSolicita;
            entity.i_IdFormaPago = dto.i_IdFormaPago;
            entity.i_IdEntidadBancaria = dto.i_IdEntidadBancaria;
            entity.i_NroDias = dto.i_NroDias;
            entity.v_NroCheque = dto.v_NroCheque;
            entity.i_IdMoneda = dto.i_IdMoneda;
            entity.t_FechaEntrega = dto.t_FechaEntrega;
            entity.d_TipoCambio = dto.d_TipoCambio;
            entity.i_IdEstado = dto.i_IdEstado;
            entity.d_SubTotal = dto.d_SubTotal;
            entity.d_IGV = dto.d_IGV;
            entity.d_Total = dto.d_Total;
            entity.v_AdjuntarAnexo = dto.v_AdjuntarAnexo;
            entity.v_Importante = dto.v_Importante;
            entity.v_LugarEntrega = dto.v_LugarEntrega;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.i_IdTipoOrdenCompra = dto.i_IdTipoOrdenCompra;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ordendecompra"/> to an instance of <see cref="ordendecompraDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="ordendecompra"/> to convert.</param>
        public static ordendecompraDto ToDTO(this ordendecompra entity)
        {
            if (entity == null) return null;

            var dto = new ordendecompraDto();

            dto.v_IdOrdenCompra = entity.v_IdOrdenCompra;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Mes = entity.v_Mes;
            dto.v_Correlativo = entity.v_Correlativo;
            dto.i_IdTipoDocumento = entity.i_IdTipoDocumento;
            dto.v_SerieDocumento = entity.v_SerieDocumento;
            dto.v_CorrelativoDocumento = entity.v_CorrelativoDocumento;
            dto.v_DocumentoInterno = entity.v_DocumentoInterno;
            dto.t_FechaRegistro = entity.t_FechaRegistro;
            dto.v_IdProveedor = entity.v_IdProveedor;
            dto.i_PreciosAfectosIgv = entity.i_PreciosAfectosIgv;
            dto.i_PreciosIncluyeIgv = entity.i_PreciosIncluyeIgv;
            dto.i_IdIgv = entity.i_IdIgv;
            dto.i_NodeId = entity.i_NodeId;
            dto.i_IdAreaSolicita = entity.i_IdAreaSolicita;
            dto.i_IdFormaPago = entity.i_IdFormaPago;
            dto.i_IdEntidadBancaria = entity.i_IdEntidadBancaria;
            dto.i_NroDias = entity.i_NroDias;
            dto.v_NroCheque = entity.v_NroCheque;
            dto.i_IdMoneda = entity.i_IdMoneda;
            dto.t_FechaEntrega = entity.t_FechaEntrega;
            dto.d_TipoCambio = entity.d_TipoCambio;
            dto.i_IdEstado = entity.i_IdEstado;
            dto.d_SubTotal = entity.d_SubTotal;
            dto.d_IGV = entity.d_IGV;
            dto.d_Total = entity.d_Total;
            dto.v_AdjuntarAnexo = entity.v_AdjuntarAnexo;
            dto.v_Importante = entity.v_Importante;
            dto.v_LugarEntrega = entity.v_LugarEntrega;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.i_IdTipoOrdenCompra = entity.i_IdTipoOrdenCompra;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ordendecompraDto"/> to an instance of <see cref="ordendecompra"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<ordendecompra> ToEntities(this IEnumerable<ordendecompraDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="ordendecompra"/> to an instance of <see cref="ordendecompraDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ordendecompraDto> ToDTOs(this IEnumerable<ordendecompra> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
