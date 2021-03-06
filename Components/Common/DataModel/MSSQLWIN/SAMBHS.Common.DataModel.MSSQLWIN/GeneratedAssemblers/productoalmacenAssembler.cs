//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/10/03 - 14:23:39
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
    /// Assembler for <see cref="productoalmacen"/> and <see cref="productoalmacenDto"/>.
    /// </summary>
    public static partial class productoalmacenAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="productoalmacenDto"/> converted from <see cref="productoalmacen"/>.</param>
        static partial void OnDTO(this productoalmacen entity, productoalmacenDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="productoalmacen"/> converted from <see cref="productoalmacenDto"/>.</param>
        static partial void OnEntity(this productoalmacenDto dto, productoalmacen entity);

        /// <summary>
        /// Converts this instance of <see cref="productoalmacenDto"/> to an instance of <see cref="productoalmacen"/>.
        /// </summary>
        /// <param name="dto"><see cref="productoalmacenDto"/> to convert.</param>
        public static productoalmacen ToEntity(this productoalmacenDto dto)
        {
            if (dto == null) return null;

            var entity = new productoalmacen();

            entity.v_IdProductoAlmacen = dto.v_IdProductoAlmacen;
            entity.i_IdAlmacen = dto.i_IdAlmacen;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_ProductoDetalleId = dto.v_ProductoDetalleId;
            entity.d_StockMinimo = dto.d_StockMinimo;
            entity.d_StockMaximo = dto.d_StockMaximo;
            entity.d_StockActual = dto.d_StockActual;
            entity.d_SeparacionTotal = dto.d_SeparacionTotal;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.v_NroPedido = dto.v_NroPedido;
            entity.t_FechaCaducidad = dto.t_FechaCaducidad;
            entity.v_NroSerie = dto.v_NroSerie;
            entity.v_NroLote = dto.v_NroLote;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="productoalmacen"/> to an instance of <see cref="productoalmacenDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="productoalmacen"/> to convert.</param>
        public static productoalmacenDto ToDTO(this productoalmacen entity)
        {
            if (entity == null) return null;

            var dto = new productoalmacenDto();

            dto.v_IdProductoAlmacen = entity.v_IdProductoAlmacen;
            dto.i_IdAlmacen = entity.i_IdAlmacen;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_ProductoDetalleId = entity.v_ProductoDetalleId;
            dto.d_StockMinimo = entity.d_StockMinimo;
            dto.d_StockMaximo = entity.d_StockMaximo;
            dto.d_StockActual = entity.d_StockActual;
            dto.d_SeparacionTotal = entity.d_SeparacionTotal;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.v_NroPedido = entity.v_NroPedido;
            dto.t_FechaCaducidad = entity.t_FechaCaducidad;
            dto.v_NroSerie = entity.v_NroSerie;
            dto.v_NroLote = entity.v_NroLote;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="productoalmacenDto"/> to an instance of <see cref="productoalmacen"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<productoalmacen> ToEntities(this IEnumerable<productoalmacenDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="productoalmacen"/> to an instance of <see cref="productoalmacenDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<productoalmacenDto> ToDTOs(this IEnumerable<productoalmacen> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
