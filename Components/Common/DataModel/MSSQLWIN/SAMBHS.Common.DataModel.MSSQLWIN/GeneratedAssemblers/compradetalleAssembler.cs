//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/09/25 - 16:18:29
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
    /// Assembler for <see cref="compradetalle"/> and <see cref="compradetalleDto"/>.
    /// </summary>
    public static partial class compradetalleAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="compradetalleDto"/> converted from <see cref="compradetalle"/>.</param>
        static partial void OnDTO(this compradetalle entity, compradetalleDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="compradetalle"/> converted from <see cref="compradetalleDto"/>.</param>
        static partial void OnEntity(this compradetalleDto dto, compradetalle entity);

        /// <summary>
        /// Converts this instance of <see cref="compradetalleDto"/> to an instance of <see cref="compradetalle"/>.
        /// </summary>
        /// <param name="dto"><see cref="compradetalleDto"/> to convert.</param>
        public static compradetalle ToEntity(this compradetalleDto dto)
        {
            if (dto == null) return null;

            var entity = new compradetalle();

            entity.v_IdCompraDetalle = dto.v_IdCompraDetalle;
            entity.v_IdCompra = dto.v_IdCompra;
            entity.v_IdMovimientoDetalle = dto.v_IdMovimientoDetalle;
            entity.v_NroCuenta = dto.v_NroCuenta;
            entity.i_Anticipio = dto.i_Anticipio;
            entity.v_IdProductoDetalle = dto.v_IdProductoDetalle;
            entity.i_IdAlmacen = dto.i_IdAlmacen;
            entity.d_Cantidad = dto.d_Cantidad;
            entity.d_CantidadEmpaque = dto.d_CantidadEmpaque;
            entity.i_IdUnidadMedida = dto.i_IdUnidadMedida;
            entity.d_Precio = dto.d_Precio;
            entity.d_ValorVenta = dto.d_ValorVenta;
            entity.d_Igv = dto.d_Igv;
            entity.d_PrecioVenta = dto.d_PrecioVenta;
            entity.d_isc = dto.d_isc;
            entity.d_otrostributos = dto.d_otrostributos;
            entity.i_IdDestino = dto.i_IdDestino;
            entity.i_IdCentroCostos = dto.i_IdCentroCostos;
            entity.v_NroGuiaRemision = dto.v_NroGuiaRemision;
            entity.d_ValorSolesDetraccion = dto.d_ValorSolesDetraccion;
            entity.d_ValorDolaresDetraccion = dto.d_ValorDolaresDetraccion;
            entity.v_NroPedido = dto.v_NroPedido;
            entity.v_Glosa = dto.v_Glosa;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.d_DescuentoItem = dto.d_DescuentoItem;
            entity.v_DescuentoItem = dto.v_DescuentoItem;
            entity.v_IdAnexo = dto.v_IdAnexo;
            entity.t_FechaCaducidad = dto.t_FechaCaducidad;
            entity.t_FechaFabricacion = dto.t_FechaFabricacion;
            entity.v_NroSerie = dto.v_NroSerie;
            entity.v_NroLote = dto.v_NroLote;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="compradetalle"/> to an instance of <see cref="compradetalleDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="compradetalle"/> to convert.</param>
        public static compradetalleDto ToDTO(this compradetalle entity)
        {
            if (entity == null) return null;

            var dto = new compradetalleDto();

            dto.v_IdCompraDetalle = entity.v_IdCompraDetalle;
            dto.v_IdCompra = entity.v_IdCompra;
            dto.v_IdMovimientoDetalle = entity.v_IdMovimientoDetalle;
            dto.v_NroCuenta = entity.v_NroCuenta;
            dto.i_Anticipio = entity.i_Anticipio;
            dto.v_IdProductoDetalle = entity.v_IdProductoDetalle;
            dto.i_IdAlmacen = entity.i_IdAlmacen;
            dto.d_Cantidad = entity.d_Cantidad;
            dto.d_CantidadEmpaque = entity.d_CantidadEmpaque;
            dto.i_IdUnidadMedida = entity.i_IdUnidadMedida;
            dto.d_Precio = entity.d_Precio;
            dto.d_ValorVenta = entity.d_ValorVenta;
            dto.d_Igv = entity.d_Igv;
            dto.d_PrecioVenta = entity.d_PrecioVenta;
            dto.d_isc = entity.d_isc;
            dto.d_otrostributos = entity.d_otrostributos;
            dto.i_IdDestino = entity.i_IdDestino;
            dto.i_IdCentroCostos = entity.i_IdCentroCostos;
            dto.v_NroGuiaRemision = entity.v_NroGuiaRemision;
            dto.d_ValorSolesDetraccion = entity.d_ValorSolesDetraccion;
            dto.d_ValorDolaresDetraccion = entity.d_ValorDolaresDetraccion;
            dto.v_NroPedido = entity.v_NroPedido;
            dto.v_Glosa = entity.v_Glosa;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.d_DescuentoItem = entity.d_DescuentoItem;
            dto.v_DescuentoItem = entity.v_DescuentoItem;
            dto.v_IdAnexo = entity.v_IdAnexo;
            dto.t_FechaCaducidad = entity.t_FechaCaducidad;
            dto.t_FechaFabricacion = entity.t_FechaFabricacion;
            dto.v_NroSerie = entity.v_NroSerie;
            dto.v_NroLote = entity.v_NroLote;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="compradetalleDto"/> to an instance of <see cref="compradetalle"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<compradetalle> ToEntities(this IEnumerable<compradetalleDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="compradetalle"/> to an instance of <see cref="compradetalleDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<compradetalleDto> ToDTOs(this IEnumerable<compradetalle> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
