//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:10:16
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SAMBHS.Common.BE
{
    [DataContract()]
    public partial class productodetalleDto
    {
        [DataMember()]
        public String v_IdProductoDetalle { get; set; }

        [DataMember()]
        public String v_IdProducto { get; set; }

        [DataMember()]
        public String v_IdColor { get; set; }

        [DataMember()]
        public String v_IdTalla { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Eliminado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_InsertaFecha { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ActualizaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_ActualizaFecha { get; set; }

        [DataMember()]
        public List<guiaremisiondetalleDto> guiaremisiondetalle { get; set; }

        [DataMember()]
        public List<importaciondetalleproductoDto> importaciondetalleproducto { get; set; }

        [DataMember()]
        public colorDto color { get; set; }

        [DataMember()]
        public productoDto producto { get; set; }

        [DataMember()]
        public tallaDto talla { get; set; }

        [DataMember()]
        public List<productoalmacenDto> productoalmacen { get; set; }

        [DataMember()]
        public List<listapreciodetalleDto> listapreciodetalle { get; set; }

        [DataMember()]
        public List<nbs_formatounicofacturaciondetalleDto> nbs_formatounicofacturaciondetalle { get; set; }

        [DataMember()]
        public List<nbs_ordentrabajodetalleDto> nbs_ordentrabajodetalle { get; set; }

        [DataMember()]
        public List<movimientodetallerecetafinalDto> movimientodetallerecetafinal_v_IdProdTerminado { get; set; }

        [DataMember()]
        public List<movimientodetallerecetafinalDto> movimientodetallerecetafinal_v_IdProdInsumo { get; set; }

        [DataMember()]
        public List<productorecetasalidaDto> productorecetasalida { get; set; }

        [DataMember()]
        public List<productorecetaDto> productoreceta_v_IdProdInsumo { get; set; }

        [DataMember()]
        public List<productorecetaDto> productoreceta_v_IdProdTerminado { get; set; }

        public productodetalleDto()
        {
        }

        public productodetalleDto(String v_IdProductoDetalle, String v_IdProducto, String v_IdColor, String v_IdTalla, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, List<guiaremisiondetalleDto> guiaremisiondetalle, List<importaciondetalleproductoDto> importaciondetalleproducto, colorDto color, productoDto producto, tallaDto talla, List<productoalmacenDto> productoalmacen, List<listapreciodetalleDto> listapreciodetalle, List<nbs_formatounicofacturaciondetalleDto> nbs_formatounicofacturaciondetalle, List<nbs_ordentrabajodetalleDto> nbs_ordentrabajodetalle, List<movimientodetallerecetafinalDto> movimientodetallerecetafinal_v_IdProdTerminado, List<movimientodetallerecetafinalDto> movimientodetallerecetafinal_v_IdProdInsumo, List<productorecetasalidaDto> productorecetasalida, List<productorecetaDto> productoreceta_v_IdProdInsumo, List<productorecetaDto> productoreceta_v_IdProdTerminado)
        {
			this.v_IdProductoDetalle = v_IdProductoDetalle;
			this.v_IdProducto = v_IdProducto;
			this.v_IdColor = v_IdColor;
			this.v_IdTalla = v_IdTalla;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.guiaremisiondetalle = guiaremisiondetalle;
			this.importaciondetalleproducto = importaciondetalleproducto;
			this.color = color;
			this.producto = producto;
			this.talla = talla;
			this.productoalmacen = productoalmacen;
			this.listapreciodetalle = listapreciodetalle;
			this.nbs_formatounicofacturaciondetalle = nbs_formatounicofacturaciondetalle;
			this.nbs_ordentrabajodetalle = nbs_ordentrabajodetalle;
			this.movimientodetallerecetafinal_v_IdProdTerminado = movimientodetallerecetafinal_v_IdProdTerminado;
			this.movimientodetallerecetafinal_v_IdProdInsumo = movimientodetallerecetafinal_v_IdProdInsumo;
			this.productorecetasalida = productorecetasalida;
			this.productoreceta_v_IdProdInsumo = productoreceta_v_IdProdInsumo;
			this.productoreceta_v_IdProdTerminado = productoreceta_v_IdProdTerminado;
        }
    }
}
