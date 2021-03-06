//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:45
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
    /// Assembler for <see cref="liquidacioncompradetalle"/> and <see cref="liquidacioncompradetalleDto"/>.
    /// </summary>
    public static partial class liquidacioncompradetalleAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="liquidacioncompradetalleDto"/> converted from <see cref="liquidacioncompradetalle"/>.</param>
        static partial void OnDTO(this liquidacioncompradetalle entity, liquidacioncompradetalleDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="liquidacioncompradetalle"/> converted from <see cref="liquidacioncompradetalleDto"/>.</param>
        static partial void OnEntity(this liquidacioncompradetalleDto dto, liquidacioncompradetalle entity);

        /// <summary>
        /// Converts this instance of <see cref="liquidacioncompradetalleDto"/> to an instance of <see cref="liquidacioncompradetalle"/>.
        /// </summary>
        /// <param name="dto"><see cref="liquidacioncompradetalleDto"/> to convert.</param>
        public static liquidacioncompradetalle ToEntity(this liquidacioncompradetalleDto dto)
        {
            if (dto == null) return null;

            var entity = new liquidacioncompradetalle();

            entity.v_IdLiquidacionCompraDetalle = dto.v_IdLiquidacionCompraDetalle;
            entity.v_IdLiquidacionCompra = dto.v_IdLiquidacionCompra;
            entity.v_IdMovimientoDetalle = dto.v_IdMovimientoDetalle;
            entity.v_NroCuenta = dto.v_NroCuenta;
            entity.v_IdProductoDetalle = dto.v_IdProductoDetalle;
            entity.i_IdAlmacen = dto.i_IdAlmacen;
            entity.d_Cantidad = dto.d_Cantidad;
            entity.d_CantidadEmpaque = dto.d_CantidadEmpaque;
            entity.i_IdUnidadMedida = dto.i_IdUnidadMedida;
            entity.d_Precio = dto.d_Precio;
            entity.d_ValorVenta = dto.d_ValorVenta;
            entity.d_Igv = dto.d_Igv;
            entity.d_PrecioVenta = dto.d_PrecioVenta;
            entity.i_IdDestino = dto.i_IdDestino;
            entity.v_NroPedido = dto.v_NroPedido;
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
        /// Converts this instance of <see cref="liquidacioncompradetalle"/> to an instance of <see cref="liquidacioncompradetalleDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="liquidacioncompradetalle"/> to convert.</param>
        public static liquidacioncompradetalleDto ToDTO(this liquidacioncompradetalle entity)
        {
            if (entity == null) return null;

            var dto = new liquidacioncompradetalleDto();

            dto.v_IdLiquidacionCompraDetalle = entity.v_IdLiquidacionCompraDetalle;
            dto.v_IdLiquidacionCompra = entity.v_IdLiquidacionCompra;
            dto.v_IdMovimientoDetalle = entity.v_IdMovimientoDetalle;
            dto.v_NroCuenta = entity.v_NroCuenta;
            dto.v_IdProductoDetalle = entity.v_IdProductoDetalle;
            dto.i_IdAlmacen = entity.i_IdAlmacen;
            dto.d_Cantidad = entity.d_Cantidad;
            dto.d_CantidadEmpaque = entity.d_CantidadEmpaque;
            dto.i_IdUnidadMedida = entity.i_IdUnidadMedida;
            dto.d_Precio = entity.d_Precio;
            dto.d_ValorVenta = entity.d_ValorVenta;
            dto.d_Igv = entity.d_Igv;
            dto.d_PrecioVenta = entity.d_PrecioVenta;
            dto.i_IdDestino = entity.i_IdDestino;
            dto.v_NroPedido = entity.v_NroPedido;
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
        /// Converts each instance of <see cref="liquidacioncompradetalleDto"/> to an instance of <see cref="liquidacioncompradetalle"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<liquidacioncompradetalle> ToEntities(this IEnumerable<liquidacioncompradetalleDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="liquidacioncompradetalle"/> to an instance of <see cref="liquidacioncompradetalleDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<liquidacioncompradetalleDto> ToDTOs(this IEnumerable<liquidacioncompradetalle> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
